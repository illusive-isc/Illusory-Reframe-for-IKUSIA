using UnityEngine;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA.Ririka {
	internal class Cloth : Base {

		internal override void ChangeObj(params string[] delPath) {
			DestroyObj(avatarRoot.Find("Cloth"));
			if (((RirikaReframe)reframe).OuterFlg)
				DestroyObj(avatarRoot.Find("Armature/Hips/Spine/Z_Skirt_root"));
			DestroyObj(avatarRoot.Find("Armature/Hips/Spine/Chest/cloth1_chestribbon"));
			if (((RirikaReframe)reframe).BagFlg) {
				DestroyObj(avatarRoot.Find("Armature/Hips/Spine/Chest/sholder_L/Z_frills_L"));
				DestroyObj(avatarRoot.Find("Armature/Hips/Spine/Chest/sholder_R/Z_frills_R"));
			}
			if (avatarRoot.Find("body_b") is Transform body_b)
				SetWeight(body_b.GetComponent<SkinnedMeshRenderer>(), "cloth1_shrink", 0);
			// foreach (var layer in paryi_FX.layers.Where(layer => layer.name == "MainCtrlTree"))
			// 	foreach (var state in layer.stateMachine.states)
			// 		if (state.state.motion is BlendTree blendTree)
			// 			blendTree.children = blendTree
			// 				.children.Where(c => !(c.motion.name == "Grounded"))
			// 				.ToArray();
		}
	}
}