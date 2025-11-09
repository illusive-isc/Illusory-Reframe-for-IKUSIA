using System.Collections.Generic;
using UnityEngine;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA.Ririka {
	internal class Heel : Base {
		bool heelFlg1,
			heelFlg2;

		internal override void InitializePlus(ReframeRuntime reframe) {
			heelFlg1 = ((RirikaReframe)reframe).heelFlg1;
			heelFlg2 = ((RirikaReframe)reframe).heelFlg2;
		}

		internal override void ChangeObj(params string[] delPath) {
			var body_b = avatarRoot.Find("body_b");
			SetWeight(body_b, "heel_OFF_ヒールオフ_R", heelFlg1 || heelFlg2 ? 0 : 100);
			SetWeight(body_b, "heel_OFF_ヒールオフ_L", heelFlg1 || heelFlg2 ? 0 : 100);
			SetWeight(body_b, "highheel_ハイヒール_R", heelFlg2 ? 100 : 0);
			SetWeight(body_b, "highheel_ハイヒール_L", heelFlg2 ? 100 : 0);
			SetWeight(avatarRoot.Find("Over knee socks"), "heel_OFF_ヒールオフ", heelFlg1 || heelFlg2 ? 0 : 100);
			SetWeight(avatarRoot.Find("Over knee socks"), "highheel_ハイヒール", heelFlg2 ? 100 : 0);
		}
	}
}
