using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using UnityEditor.Animations;
using UnityEngine;
using VRC.SDK3.Avatars.Components;
using VRC.SDK3.Avatars.ScriptableObjects;
using Debug = UnityEngine.Debug;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA.Rurune
{
    public partial class ReframeExe : ExeAbstract
    {
        protected override string GetPathDirPrefix() => base.GetPathDirPrefix() + "Rurune/";

        protected override string GetFxGuid() => "3eece7cfaddb2fe4fb361c09935d2231";

        protected override string GetMenuGuid() => "78032fce499b8cd4c9590b79ccdf3166";

        protected override string GetParamGuid() => "ab33368960825474eb83487d302f6743";

        protected override void EditAnimatorParams()
        {
            AnimatorController paryi_Loco = target.paryi_Loco;
            AnimatorController paryi_Gesture = target.paryi_Gesture;
            // AnimatorController paryi_Action = target.paryi_Action;
            AnimatorController paryi_FX = target.paryi_FX;
            if (((RuruneReframe)target).HeartGunFlg)
            {
                {
                    BaseAbstract.RemoveState4AnyState(paryi_Gesture, "Right Hand", "HeartGun");
                    BaseAbstract.RemoveStatesAndTransitions(
                        paryi_Gesture,
                        "Right Hand",
                        "yubiheart"
                    );
                }
                {
                    BaseAbstract.RemoveState4AnyState(paryi_Gesture, "Left Hand", "HeartGun");
                    BaseAbstract.RemoveStatesAndTransitions(
                        paryi_Gesture,
                        "Left Hand",
                        "yubiheart"
                    );
                }
            }
            BaseAbstract.RemoveState4AnyState(paryi_Gesture, "Right Hand", "Gimmick2_6");
            if (((RuruneReframe)target).ColliderFlg)
                BaseAbstract.RemoveStatesAndTransitions(paryi_Loco, "Locomotion", "ColliderJump");
            {
                var JumpCollider = paryi_FX.parameters.FirstOrDefault(p =>
                    p.name == "JumpCollider"
                );
                if (JumpCollider != null)
                {
                    paryi_FX.RemoveParameter(JumpCollider);
                    paryi_FX.AddParameter("JumpCollider", AnimatorControllerParameterType.Float);
                }
            }
            {
                var JumpCollider = paryi_Loco.parameters.FirstOrDefault(p =>
                    p.name == "JumpCollider"
                );
                if (JumpCollider != null)
                {
                    paryi_Loco.RemoveParameter(JumpCollider);
                    paryi_Loco.AddParameter("JumpCollider", AnimatorControllerParameterType.Float);
                }
            }
            {
                var SpeedCollider = paryi_FX.parameters.FirstOrDefault(p =>
                    p.name == "SpeedCollider"
                );
                if (SpeedCollider != null)
                {
                    paryi_FX.RemoveParameter(SpeedCollider);
                    paryi_FX.AddParameter("SpeedCollider", AnimatorControllerParameterType.Float);
                }
            }
            {
                var SpeedCollider = paryi_Loco.parameters.FirstOrDefault(p =>
                    p.name == "SpeedCollider"
                );
                if (SpeedCollider != null)
                {
                    paryi_Loco.RemoveParameter(SpeedCollider);
                    paryi_Loco.AddParameter("SpeedCollider", AnimatorControllerParameterType.Float);
                }
            }
            {
                var Grounded = paryi_FX.parameters.FirstOrDefault(p => p.name == "Grounded");
                if (Grounded != null)
                {
                    paryi_FX.RemoveParameter(Grounded);
                    paryi_FX.AddParameter("Grounded", AnimatorControllerParameterType.Float);
                }
            }
            {
                var Grounded = paryi_Loco.parameters.FirstOrDefault(p => p.name == "Grounded");
                if (Grounded != null)
                {
                    paryi_Loco.RemoveParameter(Grounded);
                    paryi_Loco.AddParameter("Grounded", AnimatorControllerParameterType.Float);
                }
            }
            {
                var VRMode = paryi_Loco.parameters.FirstOrDefault(p => p.name == "VRMode");
                if (VRMode != null)
                {
                    paryi_Loco.RemoveParameter(VRMode);
                    paryi_Loco.AddParameter("VRMode", AnimatorControllerParameterType.Float);
                }
            }
            {
                var VRMode = paryi_FX.parameters.FirstOrDefault(p => p.name == "VRMode");
                if (VRMode != null)
                {
                    paryi_FX.RemoveParameter(VRMode);
                    paryi_FX.AddParameter("VRMode", AnimatorControllerParameterType.Float);
                }
            }
        }

        public override void Execute(VRCAvatarDescriptor descriptor)
        {
            var stopwatch = Stopwatch.StartNew();
            var stepTimes = new Dictionary<string, long>
            {
                [stepNames[0]] = InitializeAssets<RuruneReframe>(descriptor, GetPathDirPrefix()),
                [stepNames[1]] = Edit<RuruneReframe>(
                    descriptor,
                    GetParamConfigs<Base, RuruneReframe>(target as RuruneReframe, GetNameSpace())
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

        protected override void ExecuteSpecificEdit<T>()
        {
            if ((target as T).IKUSIA_emote && (target as RuruneReframe).IKUSIA_emote1)
            {
                foreach (var control in target.menu.controls)
                    if (control.name == "IKUSIA_emote")
                        foreach (var control2 in control.subMenu.controls)
                            if (control2.name == "姿勢変更")
                                foreach (var ctl in control2.subMenu.controls)
                                    if (ctl.name == "AFK")
                                    {
                                        target.menu.controls.Add(
                                            new VRCExpressionsMenu.Control
                                            {
                                                name = ctl.name,
                                                icon = ctl.icon,
                                                type = ctl.type,
                                                parameter = ctl.parameter,
                                                value = ctl.value,
                                            }
                                        );
                                        goto BreakAllLoops;
                                    }

                                BreakAllLoops:
                ;
            }
            if ((target as T).IKUSIA_emote)
                foreach (var control in target.menu.controls)
                    if (control.name == "IKUSIA_emote")
                    {
                        target.menu.controls.Remove(control);
                        break;
                    }
        }
    }
}
