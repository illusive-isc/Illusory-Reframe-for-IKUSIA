using System.Collections.Generic;
using System.Linq;
using UnityEditor.Animations;
using UnityEngine;
using VRC.SDK3.Avatars.Components;
using VRC.SDK3.Avatars.ScriptableObjects;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA
{
    public abstract class BaseAbstract : ScriptableObject
    {
        protected VRCAvatarDescriptor descriptor;
        protected AnimatorController paryi_FX;

        internal virtual List<string> GetParameters() => new();

        internal virtual List<string> GetMenuPath() => new();

        internal virtual List<string> GetDelPath() => new();

        internal virtual List<string> GetLayers() => new();

        public static void EditorOnly(Transform obj)
        {
            if (obj)
            {
                EditorOnly(obj.gameObject);
            }
        }

        public static void EditorOnly(GameObject obj)
        {
            if (obj)
            {
                obj.tag = "EditorOnly";
            }
        }

        public static void DestroyObj(Transform obj)
        {
            if (obj)
            {
                DestroyObj(obj.gameObject);
            }
        }

        public static void DestroyObj(GameObject obj)
        {
            if (obj)
            {
                DestroyImmediate(obj);
            }
        }

        public static void DestroyComponent<T>(Transform obj)
            where T : Component
        {
            if (obj)
            {
                DestroyImmediate(obj.GetComponent<T>());
            }
        }

        public void ExeDestroyObj(Transform obj)
        {
            if (obj)
            {
                DestroyObj(obj);
            }
        }

        public static void SetWeight(SkinnedMeshRenderer obj, string weightName, float weight)
        {
            if (obj)
            {
                var blendShapeIndex = obj.sharedMesh.GetBlendShapeIndex(weightName);
                if (blendShapeIndex != -1)
                {
                    obj.SetBlendShapeWeight(blendShapeIndex, weight);
                }
            }
        }

        protected bool CheckBT(Motion motion, List<string> strings)
        {
            if (motion is BlendTree blendTree)
            {
                return !strings.Contains(blendTree.blendParameter);
            }
            else
            {
                return false;
            }
        }

        internal virtual void DeleteFxBT(List<string> Parameters)
        {
            foreach (var layer in paryi_FX.layers.Where(layer => layer.name == "MainCtrlTree"))
            {
                foreach (var state in layer.stateMachine.states)
                {
                    if (state.state.motion is BlendTree blendTree)
                    {
                        blendTree.children = blendTree
                            .children.Where(c => CheckBT(c.motion, Parameters))
                            .ToArray();
                    }
                }
            }
        }

        internal abstract void ParticleOptimize();

        internal virtual void EditVRCExpressions(VRCExpressionsMenu menu, List<string> menuPath)
        {
            if (menu == null || menuPath == null || menuPath.Count == 0)
                return;
            RemoveMenuItemRecursivelyInternal(menu, menuPath, 0);
        }

        protected bool RemoveMenuItemRecursivelyInternal(
            VRCExpressionsMenu menu,
            List<string> menuPath,
            int currentDepth
        )
        {
            if (currentDepth >= menuPath.Count)
                return false;

            var targetName = menuPath[currentDepth];

            for (int i = menu.controls.Count - 1; i >= 0; i--)
            {
                var control = menu.controls[i];

                if (control.name == targetName)
                {
                    if (currentDepth == menuPath.Count - 1)
                    {
                        menu.controls.RemoveAt(i);
                        return true;
                    }
                    else if (control.subMenu != null)
                    {
                        return RemoveMenuItemRecursivelyInternal(
                            control.subMenu,
                            menuPath,
                            currentDepth + 1
                        );
                    }
                }
            }

            return false;
        }

        internal void Initialize(VRCAvatarDescriptor descriptor, AnimatorController paryi_FX)
        {
            this.descriptor = descriptor;
            this.paryi_FX = paryi_FX;
        }

        internal virtual void InitializeFlags(ReframeRuntime reframe) { }

        internal virtual void ChangeObj(List<string> delPath)
        {
            foreach (var path in delPath)
                DestroyObj(descriptor.transform.Find(path));
        }

        internal virtual void DeleteFx(List<string> Layers)
        {
            paryi_FX.layers = paryi_FX
                .layers.Where(layer => !Layers.Contains(layer.name))
                .ToArray();
        }

        protected virtual void RemoveStatesAndTransitions(
            AnimatorStateMachine stateMachine,
            params AnimatorState[] statesToRemove
        )
        {
            foreach (var state in stateMachine.states)
            {
                state.state.transitions = state
                    .state.transitions.Where(t =>
                        t.destinationState == null || !statesToRemove.Contains(t.destinationState)
                    )
                    .ToArray();
            }
            stateMachine.anyStateTransitions = stateMachine
                .anyStateTransitions.Where(t =>
                    t.destinationState == null || !statesToRemove.Contains(t.destinationState)
                )
                .ToArray();
            stateMachine.states = stateMachine
                .states.Where(s => !statesToRemove.Contains(s.state))
                .ToArray();
        }

        protected void SetMaxParticle(string path, int max)
        {
            var particleobj = descriptor.transform.Find(path);
            if (particleobj)
            {
                var mainModule = particleobj.GetComponent<ParticleSystem>().main;
                mainModule.maxParticles = max;
            }
        }
    }
}
