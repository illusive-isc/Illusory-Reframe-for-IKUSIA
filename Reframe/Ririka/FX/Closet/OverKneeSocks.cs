using System.Collections.Generic;
using UnityEngine;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA.Ririka {
	internal class OverKneeSocks : Base {

		internal override List<string> GetDelPath() => new() { "Over knee socks" };

		internal override void ChangeObj(params string[] delPath) {
			base.ChangeObj(delPath);
			if (avatarRoot.Find("body_b") is Transform body_b) {
				var body_b_smr = body_b.GetComponent<SkinnedMeshRenderer>();
				SetWeight(body_b_smr, "Over-the-knee socks_オーバーニー_R", 0);
				SetWeight(body_b_smr, "Over-the-knee socks_オーバーニー_L", 0);
				SetWeight(body_b_smr, "toe_つま先2_R", 0);
				SetWeight(body_b_smr, "toe_つま先2_L", 0);
			}
		}
	}
}