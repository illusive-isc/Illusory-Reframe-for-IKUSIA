using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditor.Animations;
using UnityEngine;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA.Mizuki
{
    internal class Reframe : Base
    {
        private static readonly List<string> NotUseParameters = new() { "Mirror Toggle" };

        internal override List<string> GetDelPath() =>
            new()
            {
                "Advanced/Object",
                "Advanced/cameraLight&eyeLookHide",
                "Advanced/Gimmick2/5",
                "Advanced/Particle/7/1",
                "Advanced/Particle/7/3",
                "Advanced/Particle/7/5",
                "Advanced/Particle/6/Head",
            };

        private bool TPSFlg;
        private bool ClairvoyanceFlg;

        internal override void InitializeFlags(ReframeRuntime reframe)
        {
            TPSFlg = ((MizukiReframe)reframe).TPSFlg;
            ClairvoyanceFlg = ((MizukiReframe)reframe).ClairvoyanceFlg;
        }

        internal override void DeleteFx(List<string> Layers)
        {
            foreach (var layer in paryi_FX.layers)
            {
                var statesForTransitions = layer.stateMachine.states.ToArray();
                var transitionsToRemove =
                    new List<(AnimatorState source, AnimatorStateTransition tr)>();
                var statesToRemove = new HashSet<AnimatorState>();

                void CollectDownstream(AnimatorState sState)
                {
                    if (sState == null || statesToRemove.Contains(sState))
                        return;
                    statesToRemove.Add(sState);
                    foreach (var t in sState.transitions)
                    {
                        var dst = t.destinationState;
                        if (dst != null)
                            CollectDownstream(dst);
                    }
                }

                foreach (var s in statesForTransitions)
                {
                    var stateObj = s.state;
                    var transitions = stateObj.transitions.ToArray();
                    foreach (var tr in transitions)
                    {
                        if (
                            tr.conditions != null
                            && tr.conditions.Any(c => NotUseParameters.Contains(c.parameter))
                        )
                        {
                            transitionsToRemove.Add((stateObj, tr));
                            var dst = tr.destinationState;
                            if (dst != null)
                                CollectDownstream(dst);
                        }
                    }
                }

                var anyTransitions = layer.stateMachine.anyStateTransitions.ToArray();
                foreach (var tr in anyTransitions)
                {
                    if (
                        tr.conditions != null
                        && tr.conditions.Any(c => NotUseParameters.Contains(c.parameter))
                    )
                    {
                        transitionsToRemove.Add((null, tr));
                        var dst = tr.destinationState;
                        if (dst != null)
                            CollectDownstream(dst);
                    }
                }

                foreach (var (source, tr) in transitionsToRemove)
                {
                    try
                    {
                        if (source != null)
                            source.RemoveTransition(tr);
                        else
                            layer.stateMachine.RemoveAnyStateTransition(tr);
                    }
                    catch { }
                }

                RemoveStatesAndTransitions(layer.stateMachine, statesToRemove.ToArray());
                if (layer.name == "butterfly")
                {
                    foreach (var state in layer.stateMachine.states)
                    {
                        if (state.state.name == "New State" || state.state.name == "New State 0")
                        {
                            RemoveStatesAndTransitions(layer.stateMachine, state.state);
                            continue;
                        }
                        if (state.state.name == "butterfly_off")
                        {
                            foreach (var transition in state.state.transitions)
                            {
                                foreach (var condition in transition.conditions)
                                {
                                    if (condition.parameter == "VRMode")
                                    {
                                        transition.conditions = new AnimatorCondition[]
                                        {
                                            new()
                                            {
                                                mode = AnimatorConditionMode.Greater,
                                                parameter = "VRMode",
                                                threshold = 0.5f,
                                            },
                                        };
                                        break;
                                    }
                                }
                            }
                            continue;
                        }
                    }
                }
                if (layer.name == "MainCtrlTree")
                {
                    foreach (var state in layer.stateMachine.states)
                    {
                        if (state.state.name == "MainCtrlTree 0")
                        {
                            RemoveStatesAndTransitions(layer.stateMachine, state.state);
                            break;
                        }
                    }
                    if (!(TPSFlg && ClairvoyanceFlg))
                        foreach (var state in layer.stateMachine.states)
                        {
                            if (state.state.motion is BlendTree blendTree)
                            {
                                BlendTree newBlendTree = new()
                                {
                                    name = "VRMode",
                                    blendParameter = "VRMode",
                                    blendParameterY = "Blend",
                                    blendType = BlendTreeType.Simple1D,
                                    useAutomaticThresholds = false,
                                    maxThreshold = 1.0f,
                                    minThreshold = 0.0f,
                                };
                                blendTree.AddChild(newBlendTree);
                                var children = blendTree.children;

                                for (int i = 0; i < children.Length; i++)
                                {
                                    if (children[i].motion.name == "VRMode")
                                    {
                                        children[i].threshold = 1;
                                    }
                                }
                                blendTree.children = children;

                                newBlendTree.children = new ChildMotion[]
                                {
                                    new()
                                    {
                                        motion = AssetDatabase.LoadAssetAtPath<Motion>(
                                            AssetDatabase.GUIDToAssetPath(
                                                AssetDatabase.FindAssets("VRMode0")[0]
                                            )
                                        ),
                                        threshold = 0.0f,
                                        timeScale = 1,
                                    },
                                    new()
                                    {
                                        motion = AssetDatabase.LoadAssetAtPath<Motion>(
                                            AssetDatabase.GUIDToAssetPath(
                                                AssetDatabase.FindAssets("VRMode1")[0]
                                            )
                                        ),
                                        threshold = 1.0f,
                                        timeScale = 1,
                                    },
                                };
                                AssetDatabase.AddObjectToAsset(newBlendTree, paryi_FX);
                                AssetDatabase.SaveAssets();
                            }
                        }
                }
            }
            var VRMode = paryi_FX.parameters.FirstOrDefault(p => p.name == "VRMode");
            if (VRMode != null)
            {
                if (VRMode.type != AnimatorControllerParameterType.Float)
                {
                    paryi_FX.RemoveParameter(VRMode);
                    paryi_FX.AddParameter("VRMode", AnimatorControllerParameterType.Float);
                }
            }
        }

        internal override void DeleteFxBT(List<string> Parameters)
        {
            foreach (var layer in paryi_FX.layers.Where(layer => layer.name == "MainCtrlTree"))
            {
                foreach (var state in layer.stateMachine.states)
                {
                    if (state.state.motion is BlendTree blendTree)
                    {
                        blendTree.children = blendTree
                            .children.Where(c => CheckBT(c.motion, NotUseParameters))
                            .ToArray();
                    }
                }
            }
        }
    }
}
