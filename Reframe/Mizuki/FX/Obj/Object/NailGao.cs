using System.Collections.Generic;
using UnityEngine;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA.Mizuki {
	internal class NailGao : Base {
		bool NailGaoFlg2;

		internal override void InitializePlus(ReframeRuntime reframe) {
			NailGaoFlg2 = ((MizukiReframe)reframe).NailGaoFlg2;
		}

		internal override List<string> GetParameters() => new() { "Object1" };

		internal override List<string> GetMenuPath() => new() { "Object", "nail gao~" };

		internal override void ChangeObj(params string[] delPath) {
			var body_b = avatarRoot.Find("Body_b");

			if (body_b)
				if (body_b.TryGetComponent<SkinnedMeshRenderer>(out var body_bSMR)) {
					SetWeight(body_bSMR, "Extend", NailGaoFlg2 ? 100 : 0);
				}
		}
	}
}
