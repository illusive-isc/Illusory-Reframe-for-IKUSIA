using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditor.Animations;
using UnityEngine;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA.Rurune
{
    internal class Reframe : Base
    {
        private static readonly List<string> NotUseParameters = new()
        {
            "Mirror Toggle",
            "PlayerCollisionHit",
            "FaceLock",
        };

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
            TPSFlg = ((RuruneReframe)reframe).TPSFlg;
            ClairvoyanceFlg = ((RuruneReframe)reframe).ClairvoyanceFlg;
        }

        internal override void ChangeFx(List<string> Layers)
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
                    foreach (var state in layer.stateMachine.states)
                        if (state.state.motion is BlendTree blendTree)
                            blendTree.children = blendTree
                                .children.Where(c => c.motion.name != "VRMode0")
                                .ToArray();
                    if (!(TPSFlg && ClairvoyanceFlg))
                        CreateMainCtrlTree(
                            layer,
                            "VRMode",
                            "VRMode",
                            new ChildMotion[]
                            {
                                new()
                                {
                                    motion = AssetDatabase.LoadAssetAtPath<Motion>(
                                        AssetDatabase.GUIDToAssetPath(
                                            "c5c466dc7db945441aee55c5650877a0"
                                        )
                                    ),
                                    threshold = 0.0f,
                                    timeScale = 1,
                                },
                                new()
                                {
                                    motion = AssetDatabase.LoadAssetAtPath<Motion>(
                                        AssetDatabase.GUIDToAssetPath(
                                            "ebde9bbeee5f36048bb6de04d594ab8d"
                                        )
                                    ),
                                    threshold = 1.0f,
                                    timeScale = 1,
                                },
                            }
                        );
                }
            }
        }

        internal override void ChangeFxBT(List<string> Parameters)
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
