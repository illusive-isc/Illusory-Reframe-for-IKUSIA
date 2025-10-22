using System.Collections.Generic;
using UnityEngine;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA.Rurune
{
    internal class Heel : Base
    {
        bool heelFlg1,
            heelFlg2;

        internal override void InitializePlus(ReframeRuntime reframe)
        {
            heelFlg1 = ((RuruneReframe)reframe).heelFlg1;
            heelFlg2 = ((RuruneReframe)reframe).heelFlg2;
        }

        internal override void ChangeObj(params string[] delPath)
        {
            SetWeight(
                avatarRoot.Find("Body_b"),
                "Foot_heel_OFF_____足_ヒールオフ",
                heelFlg1 || heelFlg2 ? 0 : 100
            );
            SetWeight(
                avatarRoot.Find("Body_b"),
                "Foot_Hiheel_____足_ハイヒール",
                heelFlg2 ? 100 : 0
            );
            SetWeight(
                avatarRoot.Find("knee-socks"),
                "ヒールOFF",
                heelFlg1 || heelFlg2 ? 0 : 100
            );
            SetWeight(avatarRoot.Find("knee-socks"), "ハイヒール", heelFlg2 ? 100 : 0);
        }
    }
}
