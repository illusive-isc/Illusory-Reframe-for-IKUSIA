using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using jp.illusive_isc.IllusoryReframe.IKUSIA.Mizuki;
using UnityEditor;
using UnityEditor.Animations;
using UnityEngine;
using VRC.Dynamics;
using VRC.SDK3.Avatars.Components;
using VRC.SDK3.Avatars.ScriptableObjects;
using static jp.illusive_isc.IllusoryReframe.IKUSIA.Reframe;
using Debug = UnityEngine.Debug;
#if AVATAR_OPTIMIZER_FOUND
using Anatawa12.AvatarOptimizer;
#endif

namespace jp.illusive_isc.IllusoryReframe.IKUSIA
{
    public abstract class ExeAbstract : ScriptableObject
    {
        protected Reframe target { get; set; }

        protected virtual string GetPathDirPrefix() => "Assets/IllusoryReframe/";

        protected virtual string GetFxGuid() => "";

        protected virtual string GetMenuGuid() => "";

        protected virtual string GetParamGuid() => "";
        protected virtual string GetNameSpace() => GetType().Namespace;

        protected string pathDirSuffix = "/FX/";
        protected string pathName = "paryi_FX.controller";
        protected string pathDir;

        public readonly List<string> NotSyncParameters = new()
        {
            "takasa",
            "takasa_Toggle",
            "Action_Mode_Reset",
            "Action_Mode",
            "Mirror",
            "Mirror Toggle",
            "paryi_change_Standing",
            "paryi_change_Crouching",
            "paryi_change_Prone",
            "paryi_floating",
            "paryi_change_all_reset",
            "paryi_change_Mirror_S",
            "paryi_change_Mirror_P",
            "paryi_change_Mirror_H",
            "paryi_change_Mirror_C",
            "paryi_chang_Loco",
            "paryi_Jump",
            "paryi_Jump_cancel",
            "paryi_change_Standing_M",
            "paryi_change_Crouching_M",
            "paryi_change_Prone_M",
            "paryi_floating_M",
            "leg fixed",
            "JumpCollider",
            "SpeedCollider",
            "ColliderON",
            "clairvoyance",
            "TPS",
        };

        protected static List<string> exsistParams = new() { "TRUE", "paryi_AFK" };
        protected static readonly List<string> VRCParameters = new()
        {
            "IsLocal",
            "PreviewMode",
            "Viseme",
            "Voice",
            "GestureLeft",
            "GestureRight",
            "GestureLeftWeight",
            "GestureRightWeight",
            "AngularY",
            "VelocityX",
            "VelocityY",
            "VelocityZ",
            "VelocityMagnitude",
            "Upright",
            "Grounded",
            "Seated",
            "AFK",
            "TrackingType",
            "VRMode",
            "MuteSelf",
            "InStation",
            "Earmuffs",
            "IsOnFriendsList",
            "AvatarVersion",
        };

        public abstract void Execute(VRCAvatarDescriptor descriptor);

        protected long InitializeAssets<Reframe>(
            VRCAvatarDescriptor descriptor,
            string pathDirPrefix
        )
            where Reframe : IKUSIA.Reframe
        {
            var step1 = Stopwatch.StartNew();
            pathDir = pathDirPrefix + descriptor.gameObject.name + pathDirSuffix;
            if (AssetDatabase.LoadAssetAtPath<AnimatorController>(pathDir + pathName) != null)
            {
                AssetDatabase.DeleteAsset(pathDir + pathName);
                AssetDatabase.DeleteAsset(pathDir + "Menu");
                AssetDatabase.DeleteAsset(pathDir + "paryi_paraments.asset");
            }
            if (!Directory.Exists(pathDir))
            {
                Directory.CreateDirectory(pathDir);
            }

            if (!target.paryi_FXDef)
            {
                if (!descriptor.baseAnimationLayers[4].animatorController)
                    descriptor.baseAnimationLayers[4].animatorController =
                        AssetDatabase.LoadAssetAtPath<AnimatorController>(
                            AssetDatabase.GUIDToAssetPath(GetFxGuid())
                        );
                target.paryi_FXDef =
                    descriptor.baseAnimationLayers[4].animatorController as AnimatorController;
            }
            AssetDatabase.CopyAsset(
                AssetDatabase.GetAssetPath(target.paryi_FXDef),
                pathDir + pathName
            );

            target.paryi_FX = AssetDatabase.LoadAssetAtPath<AnimatorController>(pathDir + pathName);

            if (!target.menuDef)
            {
                if (!descriptor.expressionsMenu)
                    descriptor.expressionsMenu = AssetDatabase.LoadAssetAtPath<VRCExpressionsMenu>(
                        AssetDatabase.GUIDToAssetPath(GetMenuGuid())
                    );
                target.menuDef = descriptor.expressionsMenu;
            }

            var iconPath = pathDir + "/icon";
            if (!Directory.Exists(iconPath))
            {
                Directory.CreateDirectory(iconPath);
            }
            target.menu = DuplicateExpressionMenu(
                target.menuDef,
                pathDir,
                iconPath,
                (target as Reframe).questFlg1,
                target.textureResize
            );

            if (!target.paramDef)
            {
                if (!descriptor.expressionParameters)
                    descriptor.expressionParameters =
                        AssetDatabase.LoadAssetAtPath<VRCExpressionParameters>(
                            AssetDatabase.GUIDToAssetPath(GetParamGuid())
                        );
                target.paramDef = descriptor.expressionParameters;
                target.paramDef.name = descriptor.expressionParameters.name;
            }
            target.param = CreateInstance<VRCExpressionParameters>();
            EditorUtility.CopySerialized(target.paramDef, target.param);
            target.param.name = target.paramDef.name;

            SetNotSyncParameter(target.param);
            EditorUtility.SetDirty(target.param);
            AssetDatabase.CreateAsset(target.param, pathDir + target.param.name + ".asset");
            step1.Stop();
            return step1.ElapsedMilliseconds;
        }

        protected long Edit<T>(VRCAvatarDescriptor descriptor, ParamProcessConfig[] configs)
            where T : Reframe
        {
            var step2 = Stopwatch.StartNew();

            foreach (var config in configs)
                if (config.condition)
                    InvokeProcessParamByType(this, config.processType, descriptor);

            var baseLayers = descriptor.baseAnimationLayers;
            var paryi_LocoParam = GetUseParams(
                baseLayers[0].animatorController as AnimatorController
            );

            var paryi_GestureParam = GetUseParams(
                baseLayers[2].animatorController as AnimatorController
            );
            var paryi_ActionParam = GetUseParams(
                baseLayers[3].animatorController as AnimatorController
            );
            var paryi_FXParam = EditFXParam(target.paryi_FX);

            HashSet<string> allParams = new HashSet<string>();
            allParams.UnionWith(paryi_LocoParam);
            allParams.UnionWith(paryi_GestureParam);
            allParams.UnionWith(paryi_ActionParam);
            allParams.UnionWith(paryi_FXParam);
            target.param.parameters = target
                .param.parameters.Where(param => allParams.Contains(param.name))
                .ToArray();

            var advanced = descriptor.transform.Find("Advanced");
            if (advanced != null)
            {
                var childList = new List<Transform>();
                for (int i = 0; i < advanced.childCount; i++)
                    childList.Add(advanced.GetChild(i));

                foreach (var child in childList)
                    if (child.GetComponents<Component>().Length == 1 && child.childCount == 0)
                        DestroyImmediate(child.gameObject);
            }

            ExecuteSpecificEdit<T>();

            Edit4Quest(descriptor);

            step2.Stop();
            return step2.ElapsedMilliseconds;
        }

        protected void ExecuteSpecificEdit<T>()
            where T : Reframe
        {
            if ((target as T).IKUSIA_emote)
                foreach (var control in target.menu.controls)
                    if (control.name == "IKUSIA_emote")
                    {
                        target.menu.controls.Remove(control);
                        break;
                    }
        }

        protected long FinalizeAssets(VRCAvatarDescriptor descriptor)
        {
            var step4 = Stopwatch.StartNew();
            RemoveUnusedMenuControls(target.menu, target.param);
            PromoteSingleSubMenu(target.menu);
            EditorUtility.SetDirty(target.paryi_FX);
            MarkAllMenusDirty(target.menu);
            EditorUtility.SetDirty(target.param);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();

            descriptor.baseAnimationLayers[4].animatorController = target.paryi_FX;
            descriptor.expressionsMenu = target.menu;
            descriptor.expressionParameters = target.param;
            EditorUtility.SetDirty(descriptor);
            step4.Stop();
            return step4.ElapsedMilliseconds;
        }

        private static void RemoveUnusedMenuControls(
            VRCExpressionsMenu menu,
            VRCExpressionParameters param
        )
        {
            if (menu == null)
                return;

            for (int i = menu.controls.Count - 1; i >= 0; i--)
            {
                var control = menu.controls[i];
                bool shouldRemove = true;

                if (string.IsNullOrEmpty(control.parameter.name))
                {
                    shouldRemove = false;
                }
                else
                {
                    if (param.parameters.Any(p => p.name == control.parameter.name))
                    {
                        shouldRemove = false;
                    }
                }

                if (control.type == VRCExpressionsMenu.Control.ControlType.SubMenu)
                {
                    RemoveUnusedMenuControls(control.subMenu, param);
                }

                if (
                    shouldRemove
                    || (
                        control.type == VRCExpressionsMenu.Control.ControlType.SubMenu
                        && control.subMenu.controls.Count == 0
                    )
                )
                {
                    menu.controls.RemoveAt(i);
                }
            }
        }

        private static void MarkAllMenusDirty(VRCExpressionsMenu menu)
        {
            if (menu == null)
                return;

            EditorUtility.SetDirty(menu);

            foreach (var control in menu.controls)
            {
                if (control.subMenu != null)
                {
                    MarkAllMenusDirty(control.subMenu);
                }
            }
        }

        public static VRCExpressionsMenu DuplicateExpressionMenu(
            VRCExpressionsMenu originalMenu,
            string parentPath,
            string iconPath,
            bool questFlg1,
            TextureResizeOption textureResize
        )
        {
            return DuplicateExpressionMenu(
                originalMenu,
                parentPath,
                iconPath,
                questFlg1,
                textureResize,
                null,
                null,
                null
            );
        }

        private static VRCExpressionsMenu DuplicateExpressionMenu(
            VRCExpressionsMenu originalMenu,
            string parentPath,
            string iconPath,
            bool questFlg1,
            TextureResizeOption textureResize,
            VRCExpressionsMenu rootMenuAsset = null,
            Dictionary<VRCExpressionsMenu, VRCExpressionsMenu> processedMenus = null,
            Dictionary<string, Texture2D> processedIcons = null
        )
        {
            if (originalMenu == null)
            {
                Debug.LogError("元のExpression Menuがありません");
                return null;
            }

            bool isRootCall = processedMenus == null;
            if (isRootCall)
            {
                processedMenus = new Dictionary<VRCExpressionsMenu, VRCExpressionsMenu>();
                processedIcons = new Dictionary<string, Texture2D>();
            }

            if (processedMenus.ContainsKey(originalMenu))
            {
                return processedMenus[originalMenu];
            }

            VRCExpressionsMenu newMenu = Instantiate(originalMenu);
            newMenu.name = originalMenu.name;

            processedMenus[originalMenu] = newMenu;

            if (isRootCall)
            {
                string menuAssetPath = Path.Combine(parentPath, originalMenu.name + ".asset");
                AssetDatabase.CreateAsset(newMenu, menuAssetPath);
                rootMenuAsset = newMenu;
            }
            else if (rootMenuAsset != null)
            {
                AssetDatabase.AddObjectToAsset(newMenu, rootMenuAsset);
            }

            for (int i = 0; i < newMenu.controls.Count; i++)
            {
                var control = newMenu.controls[i];
                if (questFlg1)
                {
                    if (textureResize == TextureResizeOption.LowerResolution)
                    {
                        var originalControl = originalMenu.controls[i];

                        if (originalControl.icon != null)
                        {
                            string iconAssetPath = AssetDatabase.GetAssetPath(originalControl.icon);
                            if (!string.IsNullOrEmpty(iconAssetPath))
                            {
                                string iconFileName = Path.GetFileName(iconAssetPath);
                                string destPath = Path.Combine(iconPath, iconFileName);

                                if (processedIcons.ContainsKey(iconAssetPath))
                                {
                                    control.icon = processedIcons[iconAssetPath];
                                }
                                else
                                {
                                    if (!File.Exists(destPath))
                                    {
                                        File.Copy(iconAssetPath, destPath, true);
                                        AssetDatabase.ImportAsset(destPath);
                                    }

                                    var copiedIcon = AssetDatabase.LoadAssetAtPath<Texture2D>(
                                        destPath
                                    );
                                    if (copiedIcon != null)
                                    {
                                        var importer =
                                            AssetImporter.GetAtPath(destPath) as TextureImporter;
                                        if (importer != null)
                                        {
                                            importer.maxTextureSize = 32;
                                            importer.SaveAndReimport();
                                        }

                                        processedIcons[iconAssetPath] = copiedIcon;
                                        control.icon = copiedIcon;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        control.icon = null;
                    }
                }
                if (control.subMenu != null)
                {
                    control.subMenu = DuplicateExpressionMenu(
                        control.subMenu,
                        parentPath,
                        iconPath,
                        questFlg1,
                        textureResize,
                        rootMenuAsset,
                        processedMenus,
                        processedIcons
                    );
                }
            }
            EditorUtility.SetDirty(newMenu);
            if (isRootCall)
            {
                AssetDatabase.SaveAssets();
            }
            return newMenu;
        }

        protected struct ParamProcessConfig
        {
            public bool condition;
            public Type processType;
        }

        protected void ProcessParam<Exe, Reframe>(VRCAvatarDescriptor descriptor)
            where Exe : BaseAbstract, new()
            where Reframe : IKUSIA.Reframe
        {
            Exe instance = CreateInstance<Exe>();

            List<string> parameters = instance.GetParameters();
            List<string> menuPath = instance.GetMenuPath();
            List<string> delPath = instance.GetDelPath();
            List<string> Layers = instance.GetLayers();

            instance.Initialize(descriptor, target.paryi_FX);
            instance.InitializeFlags(target);
            instance.DeleteFx(Layers);
            instance.DeleteFxBT(parameters);
            instance.EditVRCExpressions(target.menu, menuPath);
            if (instance.GetType().Name == "Reframe")
                instance.ParticleOptimize();
            instance.ChangeObj(delPath);
            if (
                instance.GetType().Namespace == GetNameSpace() + ".Mizuki"
                && instance.GetType().Name == "Reframe"
            )
                (instance as Base)?.DeleteMenuButtonCtrl(parameters);
        }

        protected ParamProcessConfig[] GetParamConfigs<Exe, Reframe>(
            Reframe target,
            string TargetNamespace
        )
            where Exe : BaseAbstract
            where Reframe : IKUSIA.Reframe
        {
            var types = GetDerivedTypes<Exe>(TargetNamespace);
            ParamProcessConfig[] configs = types
                .Select(t =>
                {
                    var flagField = typeof(Reframe).GetField(
                        t.Name + "Flg",
                        BindingFlags.Instance
                            | BindingFlags.Static
                            | BindingFlags.Public
                            | BindingFlags.NonPublic
                    );

                    bool condition = GetBoolFieldFromInstance(flagField, target);

                    return new ParamProcessConfig { condition = condition, processType = t };
                })
                .ToArray();
            return configs;
        }

        protected abstract void Edit4Quest(VRCAvatarDescriptor descriptor);

        protected static void DelPBByPathArray(
            VRCAvatarDescriptor descriptor,
            params string[] paths
        )
        {
            foreach (var path in paths)
                BaseAbstract.DestroyComponent<VRCPhysBoneBase>(descriptor.transform.Find(path));
        }

        protected static void DelPBColliderByPathArray(
            VRCAvatarDescriptor descriptor,
            params string[] paths
        )
        {
            foreach (var path in paths)
                BaseAbstract.DestroyComponent<VRCPhysBoneColliderBase>(
                    descriptor.transform.Find(path)
                );
        }

        protected static void DelColliderSettingByPathArray(
            VRCAvatarDescriptor descriptor,
            string[] colliderNames,
            params string[] pbPaths
        )
        {
            foreach (var pbPath in pbPaths)
            {
                if (descriptor.transform.Find(pbPath))
                {
                    var physBone = descriptor
                        .transform.Find(pbPath)
                        .GetComponent<VRCPhysBoneBase>();
                    if (physBone != null && physBone.colliders != null)
                    {
                        foreach (var colliderName in colliderNames)
                        {
                            for (int i = physBone.colliders.Count - 1; i >= 0; i--)
                            {
                                var collider = physBone.colliders[i];
                                if (collider != null && collider.name.Contains(colliderName))
                                {
                                    physBone.colliders.RemoveAt(i);
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }

        private static Type[] SafeGetTypes(Assembly asm)
        {
            try
            {
                return asm.GetTypes();
            }
            catch (ReflectionTypeLoadException ex)
            {
                return ex.Types.Where(t => t != null).ToArray();
            }
            catch
            {
                return Array.Empty<Type>();
            }
        }

        protected static Type[] GetDerivedTypes<T>(string TargetNamespace)
            where T : BaseAbstract
        {
            var baseType = typeof(T);
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            var types = assemblies
                .SelectMany(a => SafeGetTypes(a))
                .Where(t =>
                    t != null
                    && t.IsClass
                    && !t.IsAbstract
                    && t.Namespace == TargetNamespace
                    && baseType.IsAssignableFrom(t)
                )
                .OrderBy(t => t.Name)
                .ToArray();
            return types;
        }

        protected bool GetBoolFieldFromInstance(FieldInfo field, object instance)
        {
            if (field == null || instance == null)
                return false;
            try
            {
                if (field.IsStatic)
                    return field.GetValue(null) is bool b && b;
                else
                    return field.GetValue(instance) is bool b2 && b2;
            }
            catch
            {
                return false;
            }
        }

        protected static void InvokeProcessParamByType(
            object thisObj,
            Type genericParamType,
            VRCAvatarDescriptor descriptor
        )
        {
            if (thisObj == null || genericParamType == null)
                return;

            var mi = thisObj
                .GetType()
                .GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                .FirstOrDefault(m =>
                    m.Name == "ProcessParam"
                    && m.IsGenericMethodDefinition
                    && m.GetGenericArguments().Length == 2
                );

            if (mi == null)
            {
                Debug.LogError("ProcessParam<Exe, Reframe> メソッドが見つかりません");
                return;
            }

            try
            {
                var reframeType = typeof(Reframe);
                var targetType = thisObj.GetType();

                var targetField = targetType.GetField(
                    "target",
                    BindingFlags.Instance | BindingFlags.NonPublic
                );
                if (targetField != null)
                {
                    var targetValue = targetField.GetValue(thisObj);
                    if (targetValue != null)
                    {
                        reframeType = targetValue.GetType();
                    }
                }

                var gm = mi.MakeGenericMethod(genericParamType, reframeType);
                gm.Invoke(thisObj, new object[] { descriptor });
            }
            catch (Exception ex)
            {
                Debug.LogError($"ProcessParam呼び出しエラー: {ex.Message}");
            }
        }

        protected void SetNotSyncParameter(VRCExpressionParameters Parameters)
        {
            foreach (var parameter in Parameters.parameters)
            {
                if (NotSyncParameters.Contains(parameter.name))
                {
                    parameter.networkSynced = false;
                }
            }
        }

        protected HashSet<string> EditFXParam(AnimatorController paryi_FX)
        {
            HashSet<string> used = GetUseParams(paryi_FX);
            foreach (var p in paryi_FX.parameters.Where(p => !used.Contains(p.name)).ToArray())
                paryi_FX.RemoveParameter(p);

            return used;
        }

        protected static HashSet<string> GetUseParams(AnimatorController paryi_FX)
        {
            var used = new HashSet<string>();

            void CollectBlendTreeParams(BlendTree bt)
            {
                if (bt == null)
                    return;
                if (!string.IsNullOrEmpty(bt.blendParameter))
                    used.Add(bt.blendParameter);
                if (!string.IsNullOrEmpty(bt.blendParameterY))
                    used.Add(bt.blendParameterY);
                var children = bt.children;
                if (children == null)
                    return;
                foreach (var c in children)
                {
                    if (c.motion is BlendTree nested)
                        CollectBlendTreeParams(nested);
                }
            }

            foreach (var layer in paryi_FX.layers)
            {
                foreach (var s in layer.stateMachine.states)
                {
                    var state = s.state;
                    if (!string.IsNullOrEmpty(state.cycleOffsetParameter))
                        used.Add(state.cycleOffsetParameter);
                    if (!string.IsNullOrEmpty(state.timeParameter))
                        used.Add(state.timeParameter);
                    if (!string.IsNullOrEmpty(state.speedParameter))
                        used.Add(state.speedParameter);
                    if (!string.IsNullOrEmpty(state.mirrorParameter))
                        used.Add(state.mirrorParameter);

                    if (state.motion is BlendTree bt)
                    {
                        CollectBlendTreeParams(bt);
                    }

                    foreach (var tr in state.transitions)
                    {
                        if (tr.conditions == null)
                            continue;
                        foreach (var c in tr.conditions)
                        {
                            if (!string.IsNullOrEmpty(c.parameter))
                                used.Add(c.parameter);
                        }
                        var dst = tr.destinationState;
                        if (dst != null && dst.motion is BlendTree dstBT)
                            CollectBlendTreeParams(dstBT);
                    }
                }

                foreach (var tr in layer.stateMachine.anyStateTransitions)
                {
                    if (tr.conditions == null)
                        continue;
                    foreach (var c in tr.conditions)
                    {
                        if (!string.IsNullOrEmpty(c.parameter))
                            used.Add(c.parameter);
                    }
                    var dst = tr.destinationState;
                    if (dst != null && dst.motion is BlendTree dstBT)
                        CollectBlendTreeParams(dstBT);
                }
            }

            return used;
        }

        private static void PromoteSingleSubMenu(VRCExpressionsMenu menu)
        {
            if (menu == null)
                return;

            for (int i = 0; i < menu.controls.Count; i++)
            {
                var control = menu.controls[i];
                if (
                    control.type == VRCExpressionsMenu.Control.ControlType.SubMenu
                    && control.subMenu != null
                )
                {
                    var subMenu = control.subMenu;

                    PromoteSingleSubMenu(subMenu);

                    if (subMenu.controls.Count == 1)
                    {
                        var singleControl = subMenu.controls[0];
                        menu.controls[i] = singleControl;
                    }
                }
            }
        }

        protected void Remove4AAO(VRCAvatarDescriptor descriptor, bool AAORemoveFlg)
        {
            if (AAORemoveFlg)
            {
#if AVATAR_OPTIMIZER_FOUND
                if (
                    !descriptor
                        .transform.Find("Body")
                        .TryGetComponent<RemoveMeshByBlendShape>(out var removeMesh)
                )
                {
                    removeMesh = descriptor
                        .transform.Find("Body")
                        .gameObject.AddComponent<RemoveMeshByBlendShape>();
                    removeMesh.Initialize(1);
                }
                removeMesh.ShapeKeys.Add("照れ");
#endif
            }
        }
    }
}
