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
using static jp.illusive_isc.IllusoryReframe.IKUSIA.ReframeRuntime;
using Debug = UnityEngine.Debug;
using Object = UnityEngine.Object;
#if AVATAR_OPTIMIZER_FOUND
using Anatawa12.AvatarOptimizer;
#endif

namespace jp.illusive_isc.IllusoryReframe.IKUSIA
{
    public abstract class ExeAbstract : ScriptableObject
    {
        protected ReframeRuntime target { get; set; }

        protected Object AssetContainer { get; set; }

        public void SetTarget<T>(T target)
            where T : ReframeRuntime
        {
            this.target = target;
        }

        public void SetAssetContainer(Object AssetContainer)
        {
            this.AssetContainer = AssetContainer;
        }

        public bool IsEdit()
        {
            return AssetContainer != null || target.executeMode != ExecuteModeOption.NDMF;
        }

        protected readonly string[] stepNames = new[]
        {
            "InitializeAssets",
            "EditProcessing",
            "FinalizeAssets",
        };

        protected virtual string GetPathDirPrefix() => "Assets/IllusoryReframe/";

        protected virtual string GetFxGuid() => "";

        protected virtual string GetMenuGuid() => "";

        protected virtual string GetParamGuid() => "";

        protected virtual string GetNameSpace() => GetType().Namespace;

        protected string pathName = ".controller";
        protected string pathDir = "";

        public readonly List<string> NotSyncParameters = new()
        {
            "takasa",
            "takasa_Toggle",
            "Action_Mode_Reset",
            "Action_Mode",
            "Mirror",
            "Mirror Toggle",
            "EmoteMirror",
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
            where Reframe : ReframeRuntime
        {
            var step1 = Stopwatch.StartNew();
            if (target.executeMode != ExecuteModeOption.NDMF)
            {
                pathDir = pathDirPrefix + descriptor.gameObject.name + "/";
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

                AssetDatabase.CopyAsset(
                    AssetDatabase.GetAssetPath(
                        descriptor.baseAnimationLayers[0].animatorController
                    ),
                    pathDir + descriptor.baseAnimationLayers[0].animatorController.name + pathName
                );

                target.paryi_Loco = AssetDatabase.LoadAssetAtPath<AnimatorController>(
                    pathDir + descriptor.baseAnimationLayers[0].animatorController.name + pathName
                );

                AssetDatabase.CopyAsset(
                    AssetDatabase.GetAssetPath(
                        descriptor.baseAnimationLayers[2].animatorController
                    ),
                    pathDir + descriptor.baseAnimationLayers[2].animatorController.name + pathName
                );

                target.paryi_Gesture = AssetDatabase.LoadAssetAtPath<AnimatorController>(
                    pathDir + descriptor.baseAnimationLayers[2].animatorController.name + pathName
                );
                AssetDatabase.CopyAsset(
                    AssetDatabase.GetAssetPath(
                        descriptor.baseAnimationLayers[3].animatorController
                    ),
                    pathDir + descriptor.baseAnimationLayers[3].animatorController.name + pathName
                );

                target.paryi_Action = AssetDatabase.LoadAssetAtPath<AnimatorController>(
                    pathDir + descriptor.baseAnimationLayers[3].animatorController.name + pathName
                );
                AssetDatabase.CopyAsset(
                    AssetDatabase.GetAssetPath(
                        descriptor.baseAnimationLayers[4].animatorController
                    ),
                    pathDir + descriptor.baseAnimationLayers[4].animatorController.name + pathName
                );

                target.paryi_FX = AssetDatabase.LoadAssetAtPath<AnimatorController>(
                    pathDir + descriptor.baseAnimationLayers[4].animatorController.name + pathName
                );

                var iconPath = pathDir + "/icon";
                if (!Directory.Exists(iconPath))
                {
                    Directory.CreateDirectory(iconPath);
                }
                target.menu = DuplicateExpressionMenu(
                    descriptor.expressionsMenu,
                    pathDir,
                    iconPath,
                    target.questFlg1,
                    target.textureResize,
                    AssetContainer
                );
                target.param = CreateInstance<VRCExpressionParameters>();
                EditorUtility.CopySerialized(descriptor.expressionParameters, target.param);
                target.param.name = descriptor.expressionParameters.name;

                SetNotSyncParameter(target.param);
                EditorUtility.SetDirty(target.param);
                AssetDatabase.CreateAsset(target.param, pathDir + target.param.name + ".asset");
            }

            if (target.executeMode == ExecuteModeOption.NDMF && AssetContainer)
            {
                {
                    var originalController =
                        descriptor.baseAnimationLayers[0].animatorController as AnimatorController;
                    if (originalController != null)
                    {
                        target.paryi_Loco = Instantiate(originalController);
                        target.paryi_Loco.name = originalController.name;
                        AssetDatabase.AddObjectToAsset(target.paryi_Loco, AssetContainer);
                    }
                }
                {
                    var originalController =
                        descriptor.baseAnimationLayers[2].animatorController as AnimatorController;
                    if (originalController != null)
                    {
                        target.paryi_Gesture = Instantiate(originalController);
                        target.paryi_Gesture.name = originalController.name;
                        AssetDatabase.AddObjectToAsset(target.paryi_Gesture, AssetContainer);
                    }
                }
                {
                    var originalController =
                        descriptor.baseAnimationLayers[3].animatorController as AnimatorController;
                    if (originalController != null)
                    {
                        target.paryi_Action = Instantiate(originalController);
                        target.paryi_Action.name = originalController.name;
                        AssetDatabase.AddObjectToAsset(target.paryi_Action, AssetContainer);
                    }
                }
                {
                    var originalController =
                        descriptor.baseAnimationLayers[4].animatorController as AnimatorController;
                    if (originalController != null)
                    {
                        target.paryi_FX = Instantiate(originalController);
                        target.paryi_FX.name = originalController.name;
                        AssetDatabase.AddObjectToAsset(target.paryi_FX, AssetContainer);
                    }
                }

                var iconPath = pathDir + "/icon";
                if (!Directory.Exists(iconPath))
                {
                    Directory.CreateDirectory(iconPath);
                }
                target.menu = DuplicateExpressionMenu(
                    descriptor.expressionsMenu,
                    pathDir,
                    iconPath,
                    target.questFlg1,
                    target.textureResize,
                    AssetContainer
                );

                target.param = CreateInstance<VRCExpressionParameters>();
                EditorUtility.CopySerialized(descriptor.expressionParameters, target.param);
                target.param.name = descriptor.expressionParameters.name;

                SetNotSyncParameter(target.param);
                EditorUtility.SetDirty(target.param);
                AssetDatabase.AddObjectToAsset(target.param, AssetContainer);
            }
            step1.Stop();
            return step1.ElapsedMilliseconds;
        }

        protected long Edit<T>(VRCAvatarDescriptor descriptor, ParamProcessConfig[] configs)
            where T : ReframeRuntime
        {
            var step2 = Stopwatch.StartNew();

            foreach (var config in configs)
                if (config.condition)
                    InvokeProcessParamByType(this, config.processType, descriptor);

            if (IsEdit())
            {
                EditAnimatorParams();

                var paryi_LocoParam = GetUseParams(
                    target.paryi_Loco != null
                        ? target.paryi_Loco
                        : descriptor.baseAnimationLayers[0].animatorController as AnimatorController
                );
                var paryi_GestureParam = GetUseParams(
                    target.paryi_Gesture != null
                        ? target.paryi_Gesture
                        : descriptor.baseAnimationLayers[2].animatorController as AnimatorController
                );
                var paryi_ActionParam = GetUseParams(
                    target.paryi_Action != null
                        ? target.paryi_Action
                        : descriptor.baseAnimationLayers[3].animatorController as AnimatorController
                );
                var paryi_FXParam = EditFXParam(
                    target.paryi_FX != null
                        ? target.paryi_FX
                        : descriptor.baseAnimationLayers[4].animatorController as AnimatorController
                );

                HashSet<string> allParams = new();
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
            }

            Edit4Quest(descriptor.transform);

            step2.Stop();
            return step2.ElapsedMilliseconds;
        }

        protected virtual void EditAnimatorParams() { }

        protected virtual void ExecuteSpecificEdit<T>()
            where T : ReframeRuntime
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

            if (IsEdit())
            {
                try
                {
                    RemoveUnusedMenuControls(target.menu, target.param);
                }
                catch (Exception e)
                {
                    Debug.LogWarning("メニューの最適化に失敗しました。" + e);
                }
                PromoteSingleSubMenu(target.menu);
                EditorUtility.SetDirty(target.paryi_FX);
                MarkAllMenusDirty(target.menu);
                EditorUtility.SetDirty(target.param);
                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();

                if (target.executeMode == ExecuteModeOption.NDMF)
                {
                    descriptor.baseAnimationLayers[0].animatorController = target.paryi_Loco;
                    descriptor.baseAnimationLayers[2].animatorController = target.paryi_Gesture;
                    descriptor.baseAnimationLayers[3].animatorController = target.paryi_Action;
                    descriptor.baseAnimationLayers[4].animatorController = target.paryi_FX;
                    descriptor.expressionsMenu = target.menu;
                    descriptor.expressionParameters = target.param;
                }
                EditorUtility.SetDirty(descriptor);
            }
            step4.Stop();
            return step4.ElapsedMilliseconds;
        }

        private static void RemoveUnusedMenuControls(
            VRCExpressionsMenu menu,
            VRCExpressionParameters param
        )
        {
            if (menu == null || param == null)
                return;

            if (menu.controls == null)
                return;

            for (int i = menu.controls.Count - 1; i >= 0; i--)
            {
                var control = menu.controls[i];
                if (control == null)
                {
                    menu.controls.RemoveAt(i);
                    continue;
                }

                bool shouldRemove = true;

                if (control.parameter == null || string.IsNullOrEmpty(control.parameter.name))
                    shouldRemove = false;
                else if (
                    param.parameters != null
                    && param.parameters.Any(p => p != null && p.name == control.parameter.name)
                )
                    shouldRemove = false;

                if (control.type == VRCExpressionsMenu.Control.ControlType.SubMenu)
                    if (control.subMenu != null)
                        RemoveUnusedMenuControls(control.subMenu, param);

                if (
                    shouldRemove
                    || (
                        control.type == VRCExpressionsMenu.Control.ControlType.SubMenu
                        && (
                            control.subMenu == null
                            || control.subMenu.controls == null
                            || control.subMenu.controls.Count == 0
                        )
                    )
                )
                    menu.controls.RemoveAt(i);
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
            TextureResizeOption textureResize,
            Object AssetContainer
        )
        {
            return DuplicateExpressionMenu(
                originalMenu,
                parentPath,
                iconPath,
                questFlg1,
                textureResize,
                AssetContainer,
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
            Object AssetContainer = null,
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
                if (!AssetContainer)
                {
                    string menuAssetPath = Path.Combine(parentPath, originalMenu.name + ".asset");
                    AssetDatabase.CreateAsset(newMenu, menuAssetPath);
                    rootMenuAsset = newMenu;
                }
                else
                {
                    newMenu = Instantiate(originalMenu);
                    newMenu.name = originalMenu.name;
                    AssetDatabase.AddObjectToAsset(newMenu, AssetContainer);
                }
            }
            else if (rootMenuAsset != null)
            {
                AssetDatabase.AddObjectToAsset(
                    newMenu,
                    AssetContainer == null ? rootMenuAsset : AssetContainer
                );
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
                        AssetContainer,
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
            where Reframe : ReframeRuntime
        {
            Exe instance = CreateInstance<Exe>();

            List<string> parameters = instance.GetParameters();
            List<string> menuPath = instance.GetMenuPath();
            List<string> delPath = instance.GetDelPath();
            List<string> Layers = instance.GetLayers();

            instance.Initialize(descriptor.transform, target.paryi_FX, target, AssetContainer);
            instance.InitializePlus(target);
            if (IsEdit())
                instance.ChangeFx(Layers);
            if (IsEdit())
                instance.ChangeFxBT(parameters);
            if (IsEdit())
                instance.EditVRCExpressions(target.menu, menuPath);
            if (instance.GetType().Name == "Reframe" && target.maxParticleLimitFlg)
                instance.ParticleOptimize();
            instance.ChangeObj(delPath.ToArray());
            if (
                instance.GetType().Namespace == GetNameSpace() + ".Mizuki"
                && instance.GetType().Name == "Reframe"
            )
            {
                if (IsEdit())
                    (instance as Base)?.DeleteMenuButtonCtrl(parameters);
            }
        }

        protected ParamProcessConfig[] GetParamConfigs<Exe, Reframe>(
            Reframe target,
            string TargetNamespace
        )
            where Exe : BaseAbstract
            where Reframe : ReframeRuntime
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

        protected abstract void Edit4Quest(Transform avatarRoot);

        protected static void DelPBByPathArray(Transform avatarRoot, params string[] paths)
        {
            foreach (var path in paths)
                BaseAbstract.DestroyComponent<VRCPhysBoneBase>(avatarRoot.Find(path));
        }

        protected static void DelPBColliderByPathArray(Transform avatarRoot, params string[] paths)
        {
            foreach (var path in paths)
                BaseAbstract.DestroyComponent<VRCPhysBoneColliderBase>(avatarRoot.Find(path));
        }

        protected static void DelColliderSettingByPathArray(
            Transform avatarRoot,
            string[] colliderNames,
            params string[] pbPaths
        )
        {
            foreach (var pbPath in pbPaths)
            {
                if (avatarRoot.Find(pbPath))
                {
                    var physBone = avatarRoot.Find(pbPath).GetComponent<VRCPhysBoneBase>();
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
                var reframeType = typeof(ReframeRuntime);
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
                Debug.LogError($"ProcessParam呼び出しエラー:{genericParamType} : {ex}");
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

        protected void Remove4AAO(Transform avatarRoot, bool AAORemoveFlg)
        {
            if (AAORemoveFlg)
            {
#if AVATAR_OPTIMIZER_FOUND
                if (
                    !avatarRoot
                        .Find("Body")
                        .TryGetComponent<RemoveMeshByBlendShape>(out var removeMesh)
                )
                {
                    removeMesh = avatarRoot
                        .Find("Body")
                        .gameObject.AddComponent<RemoveMeshByBlendShape>();
                    removeMesh.Initialize(1);
                }
                removeMesh.ShapeKeys.Add("照れ");
#endif
            }
        }
    }
}
