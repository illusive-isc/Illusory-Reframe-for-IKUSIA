using System.Collections.Generic;
using UnityEngine;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA.Mizuki
{
    internal class Heel : Base
    {
        bool heelFlg1,
            heelFlg2;

        internal override void InitializeFlags(ReframeRuntime reframe)
        {
            heelFlg1 = ((MizukiReframe)reframe).heelFlg1;
            heelFlg2 = ((MizukiReframe)reframe).heelFlg2;
        }

        internal override void ChangeObj(List<string> delPath)
        {
            var body_b = descriptor.transform.Find("Body_b");
            if (body_b)
                if (body_b.TryGetComponent<SkinnedMeshRenderer>(out var body_bSMR))
                {
                    SetWeight(
                        body_bSMR,
                        "Foot_heel_OFF_____足_ヒールオフ",
                        heelFlg1 || heelFlg2 ? 0 : 100
                    );
                    SetWeight(body_bSMR, "Foot_Hiheel_____足_ハイヒール", heelFlg2 ? 100 : 0);
                }
        }
    }
}
