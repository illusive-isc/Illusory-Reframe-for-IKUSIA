using System.Collections.Generic;
using UnityEngine;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA.Mizuki {
	internal class Eyemask : Base {
		internal override List<string> GetParameters() => new() { "OBJ7_6" };

		internal override List<string> GetMenuPath() => new() { "Object", "Head add", "eyemask" };

		bool EyemaskFlg2;

		internal override void InitializePlus(ReframeRuntime reframe) {
			EyemaskFlg2 = ((MizukiReframe)reframe).EyemaskFlg2;
		}

		internal override void ChangeObj(params string[] delPath) {
			var maid = avatarRoot.Find("Maid");

			if (maid)
				if (maid.TryGetComponent<SkinnedMeshRenderer>(out var maidSMR)) {
					SetWeight(maidSMR, "Eye mask_on", EyemaskFlg2 ? 100 : 0);
				}
		}
	}
}
