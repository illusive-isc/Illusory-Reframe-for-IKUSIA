using System.Collections.Generic;
using UnityEngine;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA.Mizuki
{
    internal class NailGao : MizukiBase
    {
        bool NailGaoFlg2;

        internal override void InitializeFlags(Reframe reframe)
        {
            NailGaoFlg2 = ((MizukiReframe)reframe).NailGaoFlg2;
        }

        internal override List<string> GetParameters() => new() { "Object1" };

        internal override List<string> GetMenuPath() => new() { "Object", "nail gao~" };

        internal override void ChangeObj(List<string> delPath)
        {
            var body_b = descriptor.transform.Find("Body_b");

            if (body_b)
                if (body_b.TryGetComponent<SkinnedMeshRenderer>(out var body_bSMR))
                {
                    SetWeight(body_bSMR, "Extend", NailGaoFlg2 ? 100 : 0);
                }
        }
    }
}
