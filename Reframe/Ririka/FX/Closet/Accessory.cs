using System.Collections.Generic;
using System.Linq;
using UnityEditor.Animations;
using VRC.Dynamics;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA.Ririka {
	internal class Accessory : Base {
		internal override List<string> GetDelPath() => new() { "acce" };
		internal override List<string> GetMenuPath() => new() { "closet", "acce" };

		private bool AccessoryFlg1;
		private bool AccessoryFlg2;
		private bool AccessoryFlg3;
		private bool AccessoryFlg4;
		private bool AccessoryFlg5;
		private bool AccessoryDelFlg;

		internal override List<string> GetParameters() => new()
		{
			"cloth1",
			"cloth7",
			"cloth8",
			"cloth9",
		};

		internal override void InitializePlus(ReframeRuntime reframe) {
			AccessoryFlg1 = (reframe as RirikaReframe).AccessoryFlg1;
			AccessoryFlg2 = (reframe as RirikaReframe).AccessoryFlg2;
			AccessoryFlg3 = (reframe as RirikaReframe).AccessoryFlg3;
			AccessoryFlg4 = (reframe as RirikaReframe).AccessoryFlg4;
			AccessoryFlg5 = (reframe as RirikaReframe).AccessoryFlg5;
			AccessoryDelFlg = (reframe as RirikaReframe).AccessoryDelFlg;
		}

		internal override void ChangeFxBT(List<string> Parameters) {
			var targetLayer = paryi_FX.layers.FirstOrDefault(l => l.name == "MainCtrlTree");
			if (targetLayer == null)
				return;

			foreach (var state in targetLayer.stateMachine.states) {
				if (state.state.motion is not BlendTree rootTree)
					continue;
				rootTree.children = rootTree
					.children.Where(c => CheckBT(c.motion, Parameters))
					.ToArray();
				var RirikaClosetTree = rootTree
					.children.Select(c => c.motion)
					.OfType<BlendTree>()
					.FirstOrDefault(bt => bt.name == "cloth1custom");
				if (RirikaClosetTree != null)
					RirikaClosetTree.children = RirikaClosetTree
						.children.Where(c => CheckBT(c.motion, Parameters))
						.ToArray();
			}
		}

		internal override void ChangeObj(params string[] delPath) {

			SetWeight(avatarRoot.Find("cloth_Accessories"), "hairpin", AccessoryFlg1 ? 0 : 100);
			SetWeight(avatarRoot.Find("cloth_Accessories"), "ribbon", AccessoryFlg1 ? 0 : 100);
			SetWeight(avatarRoot.Find("cloth_Accessories"), "wing", AccessoryFlg2 ? 0 : 100);
			SetWeight(avatarRoot.Find("cloth_Accessories"), "choker", AccessoryFlg3 ? 0 : 100);
			SetWeight(avatarRoot.Find("cloth_Accessories"), "Leg_acce", AccessoryFlg4 ? 0 : 100);
			SetWeight(avatarRoot.Find("cloth_Accessories"), "earring", AccessoryFlg5 ? 0 : 100);

			var earringRoot = avatarRoot.Find("Armature/Hips/Spine/Chest/Neck/Head/earring_root");
			if (earringRoot != null)
				earringRoot.GetComponent<VRCPhysBoneBase>().enabled = !AccessoryFlg5;
			var wingRoot = avatarRoot.Find("Armature/Hips/Spine/Chest/Neck/Head/acce_wing_transform/acce_wing_root");
			if (wingRoot != null)
				wingRoot.GetComponent<VRCPhysBoneBase>().enabled = !AccessoryFlg2;
			var Leg_acce = avatarRoot.Find("Armature/Hips/Upperleg_L/Z_leg_acce");
			if (Leg_acce != null)
				Leg_acce.GetComponent<VRCPhysBoneBase>().enabled = !AccessoryFlg4;

			if (IsNDMFEdit() || AccessoryDelFlg) {
				if (!AccessoryFlg1 && !AccessoryFlg2 && !AccessoryFlg3 && !AccessoryFlg4 && !AccessoryFlg5) {
					base.ChangeObj("Armature/Hips/Spine/Chest/Neck/Head/earring_root");
					base.ChangeObj("Armature/Hips/Spine/Chest/Neck/Head/acce_wing_transform");
					base.ChangeObj("Armature/Hips/Upperleg_L/Z_leg acce");
					base.ChangeObj("cloth_Accessories");
				}
			}
		}
	}
}
