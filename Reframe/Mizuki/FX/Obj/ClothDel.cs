using System.Collections.Generic;
using UnityEngine;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA.Mizuki {
	internal class ClothDel : Base {
		bool ClothDelFlg2;

		internal override void InitializePlus(ReframeRuntime reframe) {
			ClothDelFlg2 = ((MizukiReframe)reframe).ClothDelFlg2;
		}

		internal override List<string> GetDelPath() =>
			new() {
				"Maid",
				"knee-socks",
				"Armature/Hips/Skirt_Root",
				"Armature/Hips/Spine/Chest/Shoulder_Ribbon_BackRoot_L",
				"Armature/Hips/Spine/Chest/Shoulder_Ribbon_BackRoot_R",
				"Armature/Hips/Spine/Chest/Shoulder_L/Shoulder_Ribbon_FrontRoot_L",
				"Armature/Hips/Spine/Chest/Shoulder_R/Shoulder_Ribbon_FrontRoot_R",
				"Armature/Hips/Spine/Chest/Neck/Head/headband_Root",
				"Armature/Hips/Upperleg_R/Lowerleg_R/Leg_frills_Root_R",
				"Armature/Hips/Upperleg_L/Lowerleg_L/Leg_frills_Loot_L",
				"Armature/Hips/Spine/Chest/Shoulder_R/Upperarm_R/Lowerarm_R/Right Hand/Hand_frills_R",
				"Armature/Hips/Spine/Chest/Shoulder_L/Upperarm_L/Lowerarm_L/Left Hand/Hand_frills_L",
				"Armature/Hips/Upperleg_L/Lowerleg_L/Foot_L/Leg_frills_Root_L",
			};

		internal override void ChangeObj(params string[] delPath) {
			base.ChangeObj(delPath);
			var Body_b = avatarRoot.Find("Body_b");

			if (Body_b)
				if (Body_b.TryGetComponent<SkinnedMeshRenderer>(out var Body_bSMR)) {
					SetWeight(Body_bSMR, "Knee socks_____ニーソ専用", 0);
					SetWeight(Body_bSMR, "bra_off_____ブラジャー_off", ClothDelFlg2 ? 0 : 100);
					SetWeight(Body_bSMR, "pants_off_____パンツ_off", ClothDelFlg2 ? 0 : 100);
				}
		}
	}
}
