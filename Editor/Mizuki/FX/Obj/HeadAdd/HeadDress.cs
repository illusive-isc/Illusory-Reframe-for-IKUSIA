using System.Collections.Generic;
using UnityEngine;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA.Mizuki
{
    internal class HeadDress : MizukiBase
    {
        internal override List<string> GetParameters() => new() { "OBJ7_7" };

        internal override List<string> GetMenuPath() =>
            new() { "Object", "Head add", "head dress" };

        bool HeadDressFlg2;

        internal override void InitializeFlags(ReframeAbstract reframe)
        {
            HeadDressFlg2 = ((MizukiReframe)reframe).HeadDressFlg2;
        }

        internal override void ChangeObj(List<string> delPath)
        {
            var maid = descriptor.transform.Find("Maid");

            if (maid)
                if (maid.TryGetComponent<SkinnedMeshRenderer>(out var maidSMR))
                {
                    SetWeight(maidSMR, "Headdress_off", HeadDressFlg2 ? 0 : 100);
                }
        }
    }
}
