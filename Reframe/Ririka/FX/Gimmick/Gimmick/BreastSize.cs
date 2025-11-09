using System.Collections.Generic;
using VRC.Dynamics;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA.Ririka {
	internal class BreastSize : Base {

		internal override List<string> GetParameters() => new() { "BreastSize" };

		internal override List<string> GetMenuPath() => new() { "Gimmick", "Breast_size" };

		internal override void ChangeObj(params string[] delPath) {
			bool breastSizeFlg1 = ((RirikaReframe)reframe).BreastSizeFlg1;
			SetWeight(avatarRoot.Find("Bra"), "breast_small_胸小さく", breastSizeFlg1 ? 0 : 2.7f);
			SetWeight(avatarRoot.Find("Bra"), "breast_big_胸大きく", breastSizeFlg1 ? 100 : 0);
			SetWeight(avatarRoot.Find("body_b"), "breast_big_胸大きく", breastSizeFlg1 ? 100 : 0);
			SetWeight(avatarRoot.Find("Outer"), "breast_big_胸大きく", breastSizeFlg1 ? 100 : 6.3f);
			SetWeight(avatarRoot.Find("Cloth"), "breast_big_胸大きく", breastSizeFlg1 ? 100 : 0);
			avatarRoot.Find("Armature/Hips/Spine/Chest/Breast_R").GetComponent<VRCPhysBoneBase>().enabled = breastSizeFlg1;
			avatarRoot.Find("Armature/Hips/Spine/Chest/Breast_L").GetComponent<VRCPhysBoneBase>().enabled = breastSizeFlg1;
		}

	}
}
