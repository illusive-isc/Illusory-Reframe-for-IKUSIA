using System.Collections.Generic;
using UnityEngine;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA.Mizuki {
	internal class ArmAcce : Base {
		internal override List<string> GetParameters() => new() { "Object2" };

		internal override List<string> GetMenuPath() => new() { "Object", "ArmAcceOff" };

		bool ArmAcceFlg2;

		internal override void InitializePlus(ReframeRuntime reframe) {
			ArmAcceFlg2 = ((MizukiReframe)reframe).ArmAcceFlg2;
		}

		internal override void ChangeObj(params string[] delPath) {
			var maid = avatarRoot.Find("Maid");

			if (maid)
				if (maid.TryGetComponent<SkinnedMeshRenderer>(out var maidSMR)) {
					SetWeight(maidSMR, "UpperArm_frills_off", ArmAcceFlg2 ? 0 : 100);
					SetWeight(maidSMR, "hands_frills_off", ArmAcceFlg2 ? 0 : 100);
				}
		}
	}
}
