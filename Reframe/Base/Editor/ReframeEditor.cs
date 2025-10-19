using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using VRC.SDK3.Avatars.Components;
#if AVATAR_OPTIMIZER_FOUND
using Anatawa12.AvatarOptimizer;
#endif

namespace jp.illusive_isc.IllusoryReframe.IKUSIA
{
    public class ReframeEditor : Editor
    {
        protected class PhysBoneInfo
        {
            public string name;
            public string autodeletePropName;
            public string flgName;
            public int AffectedCount;
            public int PBCount;
            public (string title, string flgName, float countWeight)[] titlesAndNames;
            public int Count;
            public int ColliderCount;
        }

        protected SerializedProperty executeMode;
        protected SerializedProperty paryi_FX;
        protected SerializedProperty menu;
        protected SerializedProperty param;
        protected SerializedProperty paryi_FXDef;
        protected SerializedProperty menuDef;
        protected SerializedProperty paramDef;
        protected SerializedProperty IKUSIA_emote;
        static Dictionary<Type, FieldInfo[]> _propertyFieldCache = new();

        protected void AutoInitializeSerializedProperties(ReframeEditor editorInstance)
        {
            var editorType = editorInstance.GetType();
            if (!_propertyFieldCache.TryGetValue(editorType, out var serializedPropertyFields))
            {
                serializedPropertyFields = editorType
                    .GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                    .Where(f => f.FieldType == typeof(SerializedProperty))
                    .ToArray();
                _propertyFieldCache[editorType] = serializedPropertyFields;
            }

            foreach (var field in serializedPropertyFields)
            {
                try
                {
                    field.SetValue(editorInstance, serializedObject.FindProperty(field.Name));
                }
                catch (Exception) { }
            }
        }

        protected static bool ValidateCreateObj(MenuCommand menuCommand, string name)
        {
            if (menuCommand.context is not GameObject contextGO)
                contextGO = Selection.activeGameObject;
            if (contextGO == null)
                return false;

            if (contextGO.GetComponent<VRCAvatarDescriptor>() == null)
                return false;
            if (
                contextGO.transform.parent != null
                && contextGO.transform.parent.GetComponent<VRCAvatarDescriptor>() != null
            )
                return false;
            if (!contextGO.TryGetComponent<Animator>(out var animator))
                return false;
            if (animator.avatar == null)
                return false;
            if (animator.avatar.name != name)
                return false;
            return true;
        }

        protected static void CreateObj<T>(MenuCommand menuCommand, string name)
            where T : ReframeRuntime
        {
            GameObject go = new(name);
            go.AddComponent<T>();

            GameObjectUtility.SetParentAndAlign(go, menuCommand.context as GameObject);
            Undo.RegisterCreatedObjectUndo(go, "Create " + go.name);
            Selection.activeObject = go;
        }

        protected void PropTransform(PhysBoneInfo physBoneInfo)
        {
            SerializedProperty prop = GetSerializedProperty(physBoneInfo.flgName);

            if (prop != null)
            {
                EditorGUILayout.PropertyField(
                    prop,
                    new GUIContent(
                        $"{physBoneInfo.name}【PB : {physBoneInfo.PBCount},Transform : {physBoneInfo.AffectedCount}】"
                    )
                );
            }
        }

        protected SerializedProperty GetSerializedProperty(string nameFlg)
        {
            var fi = GetType()
                .GetField(
                    nameFlg,
                    BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public
                );
            SerializedProperty prop = null;
            if (fi != null && typeof(SerializedProperty).IsAssignableFrom(fi.FieldType))
                prop = fi.GetValue(this) as SerializedProperty;

            prop ??= serializedObject.FindProperty(nameFlg);
            return prop;
        }

        protected void PropColliders(
            PhysBoneInfo info,
            params (string title, string flgName, float countWeight)[] titlesAndNames
        )
        {
            SerializedProperty titleProp = GetSerializedProperty(info.flgName);
            List<SerializedProperty> PropCollider(string title, string flgName, float countWeight)
            {
                List<SerializedProperty> props = new();
                SerializedProperty prop = GetSerializedProperty(flgName);

                if (prop != null)
                {
                    props.Add(prop);
                    EditorGUILayout.PropertyField(
                        prop,
                        new GUIContent($"{title} : {info.ColliderCount * countWeight}")
                    );
                }
                return props;
            }
            GUILayout.BeginHorizontal();
            GUILayout.Space(30);
            GUILayout.BeginVertical();
            titlesAndNames
                .ToList()
                .ForEach(tuple =>
                {
                    PropCollider(tuple.title, tuple.flgName, tuple.countWeight)
                        .ForEach(p =>
                        {
                            if (titleProp.boolValue)
                                p.boolValue = true;
                        });
                });

            GUILayout.EndVertical();
            GUILayout.EndHorizontal();
        }

        protected void EditData()
        {
            EditorGUILayout.Space();
            GUILayout.TextField(
                "生成する元Asset",
                new GUIStyle
                {
                    fontStyle = FontStyle.Bold,
                    fontSize = 24,
                    normal = new GUIStyleState { textColor = Color.white },
                }
            );
            GUI.enabled = false;
            EditorGUILayout.Space();
            EditorGUILayout.PropertyField(paryi_FXDef, new GUIContent("Animator Controller"));
            EditorGUILayout.PropertyField(menuDef, new GUIContent("Expressions Menu"));
            EditorGUILayout.PropertyField(paramDef, new GUIContent("Expression Parameters"));
            GUI.enabled = true;
            EditorGUILayout.Space();
            GUILayout.TextField(
                "生成されたAsset",
                new GUIStyle
                {
                    fontStyle = FontStyle.Bold,
                    fontSize = 24,
                    normal = new GUIStyleState { textColor = Color.white },
                }
            );
            EditorGUILayout.Space();
            EditorGUILayout.PropertyField(paryi_FX, new GUIContent("Animator Controller"));
            EditorGUILayout.PropertyField(menu, new GUIContent("Expressions Menu"));
            EditorGUILayout.PropertyField(param, new GUIContent("Expression Parameters"));
        }

        protected void ExecuteMode()
        {
            int selected = executeMode.enumValueIndex;
            executeMode.enumValueIndex = EditorGUILayout.Popup(
                "動作モード",
                selected,
                new[] { "非ModularAvatar", "ModularAvatar" }
            );
        }

        protected void DelMenu(SerializedProperty textureResize, SerializedProperty AAORemoveFlg)
        {
            int selected = textureResize.enumValueIndex;
            textureResize.enumValueIndex = EditorGUILayout.Popup(
                "メニュー画像解像度設定",
                selected,
                new[] { "下げる", "削除" }
            );

#if !AVATAR_OPTIMIZER_FOUND
            GUI.enabled = false;
            EditorGUILayout.HelpBox(
                "AAOがインストールされている場合のみ「頬染めを削除」が有効になります。",
                MessageType.Info
            );
#endif
            EditorGUILayout.PropertyField(AAORemoveFlg, new GUIContent("頬染めを削除"));
            GUI.enabled = true;
        }

        protected void QuestDialog(ReframeRuntime target, SerializedProperty questFlg1, string questHelp)
        {
#if AVATAR_OPTIMIZER_FOUND
            if (target.transform.root.GetComponent<TraceAndOptimize>() == null)
                EditorGUILayout.HelpBox(
                    "アバターにTraceAndOptimizeを追加してください",
                    MessageType.Error
                );
#else
            EditorGUILayout.HelpBox(
                "AvatarOptimizerが見つかりませんVCCに追加して有効化してください",
                MessageType.Error
            );
#endif
            EditorGUILayout.HelpBox(questHelp, MessageType.Info);
            EditorGUILayout.PropertyField(questFlg1, new GUIContent("quest用にギミックを削除"));
        }

        protected void RenderProperty(List<PhysBoneInfo> physBoneList)
        {
            physBoneList.ForEach(info =>
            {
                if (info.autodeletePropName != null)
                {
                    var prop = GetSerializedProperty(info.autodeletePropName);
                    if (prop != null && prop.boolValue)
                    {
                        var prop2 = GetSerializedProperty(info.flgName);
                        if (prop2 != null)
                            prop2.boolValue = true;
                    }
                }
                PropTransform(info);
                if (info.titlesAndNames != null)
                    PropColliders(info, info.titlesAndNames);
            });
        }

        protected void Count(
            List<PhysBoneInfo> PhysBoneInfoList,
            int pbCount,
            int pbTCount,
            int pbCCount
        )
        {
            int count = pbCount;
            int count1 = pbTCount;
            int count2 = pbCCount;
            foreach (var physBone in PhysBoneInfoList)
            {
                if (GetSerializedProperty(physBone.flgName).boolValue)
                {
                    count -= physBone.PBCount;
                    count1 -= physBone.AffectedCount;
                }
                if (physBone.titlesAndNames != null)
                    foreach (var (title, flgName, countWeight) in physBone.titlesAndNames)
                        if (GetSerializedProperty(flgName).boolValue)
                            count2 -= (int)(physBone.ColliderCount * countWeight);
            }
            EditorGUILayout.HelpBox(
                "PB数 :" + count + "/8 (8以下に調整してください)",
                count > 8 ? MessageType.Error : MessageType.Info
            );
            EditorGUILayout.HelpBox(
                "影響transform数 :" + count1 + "/64 (64以下に調整してください)",
                count1 > 64 ? MessageType.Error : MessageType.Info
            );
            EditorGUILayout.HelpBox(
                "コライダー干渉数 :" + count2 + "/64 (64以下に調整してください)",
                count2 > 64 ? MessageType.Error : MessageType.Info
            );
        }
    }
}
