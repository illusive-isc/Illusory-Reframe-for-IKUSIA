using System.Collections.Generic;
using UnityEngine;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA.Mizuki
{
    internal class ArmAcce : MizukiBase
    {
        internal override List<string> GetParameters() => new() { "Object2" };

        internal override List<string> GetMenuPath() => new() { "Object", "ArmAcceOff" };

        bool ArmAcceFlg2;

        internal override void InitializeFlags(ReframeAbstract reframe)
        {
            ArmAcceFlg2 = ((MizukiReframe)reframe).ArmAcceFlg2;
        }

        internal override void ChangeObj(List<string> delPath)
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
