using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using UnityEditor.Animations;
using UnityEngine;
using VRC.SDK3.Avatars.Components;
using Debug = UnityEngine.Debug;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA.Mizuki
{
    public partial class ReframeExe : ExeAbstract
    {
        protected override string GetPathDirPrefix() => base.GetPathDirPrefix() + "Mizuki/";

        protected override string GetFxGuid() => "eabec4db12bc4574c996310914852639";

        protected override string GetMenuGuid() => "2e95f28830e406047b35e7e58b3c0e79";

        protected override string GetParamGuid() => "ca37a7e2249e6404ea1893c197866705";

        protected override void EditAnimatorParams(
            AnimatorController paryi_Loco,
            AnimatorController paryi_Gesture,
            AnimatorController paryi_Action,
            AnimatorController paryi_FX
        )
        {
            foreach (var p in paryi_Loco.parameters.Where(p => p.name == "leg fixed").ToArray())
            {
                paryi_Loco.RemoveParameter(p);

                paryi_Loco.AddParameter(
                    new AnimatorControllerParameter
                    {
                        name = p.name,
                        type = AnimatorControllerParameterType.Float,
                        defaultFloat = p.defaultFloat,
                    }
                );
            }
            foreach (var p in paryi_Gesture.parameters.Where(p => p.name == "Gimmick2_6").ToArray())
            {
                paryi_Gesture.RemoveParameter(p);

                paryi_Gesture.AddParameter(
                    new AnimatorControllerParameter
                    {
                        name = p.name,
                        type = AnimatorControllerParameterType.Float,
                        defaultFloat = p.defaultFloat,
                    }
                );
            }
            if (((MizukiReframe)target).DrinkFlg)
            {
                var layer = paryi_FX.layers.First(l => l.name == "Right Hand");
                if (layer != null)
                {
                    var anyStateTransitions = layer.stateMachine.anyStateTransitions;

                    foreach (var transition in anyStateTransitions)
                    {
                        transition.conditions = transition
                            .conditions.Where(c => c.parameter != "Gimmick2_6")
                            .ToArray();
                    }
                    layer.stateMachine.anyStateTransitions = anyStateTransitions;
                }
            }

            foreach (var p in paryi_Action.parameters.Where(p => p.name == "leg fixed").ToArray())
                paryi_Action.RemoveParameter(p);
            foreach (var p in paryi_FX.parameters.Where(p => p.name == "leg fixed").ToArray())
                paryi_FX.RemoveParameter(p);
        }

        public override void Execute(VRCAvatarDescriptor descriptor)
        {
            var stopwatch = Stopwatch.StartNew();
            var stepTimes = new Dictionary<string, long>
            {
                [stepNames[0]] = InitializeAssets<MizukiReframe>(descriptor, GetPathDirPrefix()),
                [stepNames[1]] = Edit<MizukiReframe>(
                    descriptor,
                    GetParamConfigs<Base, MizukiReframe>(target as MizukiReframe, GetNameSpace())
                ),
                [stepNames[2]] = FinalizeAssets(descriptor),
            };

            stopwatch.Stop();
            Debug.Log(
                $"最適化を実行しました！総処理時間: {stopwatch.ElapsedMilliseconds}ms ({stopwatch.Elapsed.TotalSeconds:F2}秒)"
            );

            foreach (var kvp in stepTimes)
            {
                Debug.Log($"[Performance] {kvp.Key}: {kvp.Value}ms");
            }
        }
    }
}
