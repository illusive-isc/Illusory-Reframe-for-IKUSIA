using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using VRC.SDK3.Avatars.Components;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA.Mizuki
{
    internal class ArmAcce : MizukiBase
    {
        internal static new readonly List<string> Parameters = new() { "Object2" };

        internal static new readonly List<string> menuPath = new() { "Object", "ArmAcceOff" };
        bool ArmAcceFlg2;

        internal void Initialize(
            VRCAvatarDescriptor descriptor,
            AnimatorController paryi_FX,
            MizukiReframe optimizer
        )
        {
            this.descriptor = descriptor;
            this.paryi_FX = paryi_FX;
            ArmAcceFlg2 = optimizer.ArmAcceFlg2;
        }

        internal new void ChangeObj(List<string> delPath)
        {
            var maid = descriptor.transform.Find("Maid");

            if (maid)
                if (maid.TryGetComponent<SkinnedMeshRenderer>(out var maidSMR))
                {
                    SetWeight(maidSMR, "UpperArm_frills_off", ArmAcceFlg2 ? 0 : 100);
                    SetWeight(maidSMR, "hands_frills_off", ArmAcceFlg2 ? 0 : 100);
                }
        }
    }
}
