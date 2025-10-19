using System.Collections.Generic;
using UnityEngine;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA.Mizuki
{
    internal class Shoes : MizukiBase
    {
        internal override List<string> GetParameters() => new() { "Object6" };

        internal override List<string> GetMenuPath() => new() { "Object", "shoes" };

        bool ArmAcceFlg2;

        internal override void InitializeFlags(Reframe reframe)
        {
            ArmAcceFlg2 = ((MizukiReframe)reframe).ArmAcceFlg2;
        }

        internal override void ChangeObj(List<string> delPath)
        {
            var maid = descriptor.transform.Find("Maid");

            if (maid)
                if (maid.TryGetComponent<SkinnedMeshRenderer>(out var maidSMR))
                {
                    SetWeight(maidSMR, "Shoes_off", ArmAcceFlg2 ? 0 : 100);
                }
        }
    }
}
