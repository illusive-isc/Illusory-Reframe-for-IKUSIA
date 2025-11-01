using System.Collections.Generic;
using VRC.Dynamics;
using VRC.SDK3.Avatars.ScriptableObjects;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA.Ririka {
	internal class Hair : Base {
		internal override List<string> GetParameters() =>
			new() {
				"Object1",
				"Object2",
				"Object3",
				"Object5",
				"Object6",
				"Object7",
				"Hair_Ground",
				"Object4",
				"Particle4",
			};

		internal override void EditVRCExpressions(VRCExpressionsMenu menu, List<string> menuPath) {
			base.EditVRCExpressions(menu, new() { "closet", "head etc" });
			base.EditVRCExpressions(menu, new() { "Particle", "headphone" });
		}

		internal override void ChangeObj(params string[] delPath) {
			RirikaReframe reframe = (RirikaReframe)this.reframe;
			// var hair = avatarRoot.Find("hair");
			// SetWeight(hair, "Front_c", reframe.HairFlg10 ? 100 : 0);
			// SetWeight(hair, "pattun_short", reframe.HairFlg11 ? 100 : 0);
			// SetWeight(hair, "front_side_L", reframe.HairFlg20 ? 0 : 100);
			// SetWeight(hair, "back_ribbon", reframe.HairFlg22 ? 100 : 0);
			// SetWeight(hair, "Side_c", reframe.HairFlg12 ? 0 : 100);
			// SetWeight(hair, "Side_off", reframe.HairFlg30 ? 0 : 100);

			// SetWeight(hair, "headphone_c", reframe.HairFlg50 ? 0 : 100);

			// SetHairPB(reframe, avatarRoot.Find("Armature/Hips/Spine/Chest/Neck/Head/Hair_root"));

			// if (reframe.HairFlg40)
			// 	base.ChangeObj("hair_2");
			// if (reframe.HairFlg60) {
			// 	base.ChangeObj(
			// 		"hair",
			// 		"Armature/plane_collider",
			// 		"Advanced/Hair_Ground",
			// 		"Advanced/Hair_Contact"
			// 	);
			// 	base.ChangeObj(
			// 		"Armature/Hips/Spine/Chest/Neck/Head/Hair_root/back_hair_root",
			// 		"Armature/Hips/Spine/Chest/Neck/Head/Hair_root/back_side_root",
			// 		"Armature/Hips/Spine/Chest/Neck/Head/Hair_root/Front_hair1_root",
			// 		"Armature/Hips/Spine/Chest/Neck/Head/Hair_root/Front_hair2_root",
			// 		"Armature/Hips/Spine/Chest/Neck/Head/Hair_root/side_1_root",
			// 		"Armature/Hips/Spine/Chest/Neck/Head/Hair_root/side_3_root",
			// 		"Armature/Hips/Spine/Chest/Neck/Head/Hair_root/Side_root"
			// 	);
			// 	if (reframe.HairFlg40)
			// 		base.ChangeObj("Armature/Hips/Spine/Chest/Neck/Head/Hair_root/side_2_root");
			// 	foreach (
			// 		var physBoneCollider in avatarRoot
			// 			.Find("Armature")
			// 			.GetComponentsInChildren<VRCPhysBoneColliderBase>()
			// 	) {
			// 		if (
			// 			!(
			// 				physBoneCollider.gameObject.name
			// 					is "plane_tail_collider"
			// 						or "Breast_L"
			// 						or "Breast_R"
			// 				|| !reframe.TailDelFlg
			// 					&& physBoneCollider.gameObject.name
			// 						is "head_collider"
			// 							or "chest_collider"
			// 							or "upperleg_L_collider"
			// 							or "upperleg_R_collider"
			// 			)
			// 		)
			// 			DestroyImmediate(physBoneCollider.gameObject);
			// 		else if (physBoneCollider.gameObject.name is "Breast_L" or "Breast_R")
			// 			DestroyImmediate(physBoneCollider);
			// 	}
			// }

			// if (reframe.HairFlg50)
			// 	base.ChangeObj("Armature/Hips/Spine/Chest/Neck/Head/Ririka_headphone");
			// else
			// 	avatarRoot
			// 		.Find("Armature/Hips/Spine/Chest/Neck/Head/Ririka_headphone")
			// 		.gameObject.SetActive(true);

			// if (reframe.HairFlg51)
			// 	base.ChangeObj(
			// 		"Armature/Hips/Spine/Chest/Neck/Head/headphone_particle",
			// 		"Advanced/Particle/4"
			// 	);
			// else
			// 	avatarRoot.Find("Advanced/Particle/4").gameObject.SetActive(true);
		}

		private static void SetHairPB(RirikaReframe reframe, UnityEngine.Transform hairRoot) {
			if (hairRoot) {
				// if (
				// 	hairRoot.Find("Front_hair1_root/Head.002")
				// 	&& hairRoot
				// 		.Find("Front_hair1_root/Head.002")
				// 		.TryGetComponent<VRCPhysBoneBase>(out var Front_hair1_root)
				// ) {
				// 	Front_hair1_root.enabled = !reframe.HairFlg10;
				// }

				// if (
				// 	hairRoot.Find("Front_hair2_root")
				// 	&& hairRoot
				// 		.Find("Front_hair2_root")
				// 		.TryGetComponent<VRCPhysBoneBase>(out var Front_hair2_root)
				// ) {
				// 	Front_hair2_root.enabled = reframe.HairFlg10;
				// }

				// if (
				// 	hairRoot.Find("side_1_root")
				// 	&& hairRoot
				// 		.Find("side_1_root")
				// 		.TryGetComponent<VRCPhysBoneBase>(out var side_1_root)
				// ) {
				// 	side_1_root.enabled = reframe.HairFlg12;
				// }

				// if (
				// 	hairRoot.Find("Side_root")
				// 	&& hairRoot
				// 		.Find("Side_root")
				// 		.TryGetComponent<VRCPhysBoneBase>(out var Side_root)
				// ) {
				// 	Side_root.enabled = reframe.HairFlg30;
				// }
			}
		}
	}
}
