using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditor.Animations;
using UnityEngine;
using VRC.Dynamics;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA.Ririka {
	internal class Reframe : Base {

		internal override List<string> GetParameters() => new() { "Camera_eye_hide" };

		internal override List<string> GetDelPath() =>
			new() {

				"Advanced/Gimmick1/8",
				"Advanced/Gimmick2/3",
				"Advanced/Gimmick2/5",
				"Advanced/Gimmick2/6",
				"Advanced/Gimmick2/7",
				"Advanced/Particle/2",
				"Advanced/Particle/3",
				"Advanced/Particle/4",
				"Advanced/Particle/6",
				"Armature/Hips/Spine/Chest/sholder_L/Upperarm_L/Lowerarm_L/Left Hand/Z_sode_root_L",
				"Armature/Hips/Spine/Chest/sholder_R/Upperarm_R/Lowerarm_R/Right Hand/Z_sode_root_R",
				"Advanced/Constraint/Index_R_Constraint",
				"Advanced/Constraint/Index_L_Constraint",
				"Advanced/Constraint/Hand_L_Constraint",
				"Advanced/Constraint/Hand_R_Constraint",
			};

		internal override void ChangeFxBT(List<string> Parameters) {
			base.ChangeFxBT(Parameters);
			foreach (var layer in paryi_FX.layers) {
				if (layer.name == "MainCtrlTree") {
					foreach (var state in layer.stateMachine.states) {
						if (state.state.name == "MainCtrlTree 0") {
							RemoveStatesAndTransitions(layer.stateMachine, state.state);
							break;
						}
					}
					foreach (var state in layer.stateMachine.states)
						if (state.state.motion is BlendTree blendTree)
							blendTree.children = blendTree
								.children.Where(c => c.motion.name != "VRMode0")
								.ToArray();
					if (!(((RirikaReframe)reframe).TPSFlg && ((RirikaReframe)reframe).ClairvoyanceFlg))
						CreateMainCtrlTree(
							layer,
							"VRMode",
							"VRMode",
							new ChildMotion[] {
								new() {
									motion = AssetDatabase.LoadAssetAtPath<Motion>( AssetDatabase.GUIDToAssetPath( "f359446d713a50842afae58659f69d59" ) ),
									threshold = 0.0f,
									timeScale = 1,
								},
								new() {
									motion = AssetDatabase.LoadAssetAtPath<Motion>( AssetDatabase.GUIDToAssetPath( "6d4e80fde47d7e0449ecd7bbb9425337" ) ),
									threshold = 1.0f,
									timeScale = 1,
								},
							}
						);
				}
			}
		}
		internal override void ChangeObj(params string[] delPath) {
			base.ChangeObj(delPath);
			var pbs = avatarRoot.Find("Armature/Hips/Upperleg_L/Z_leg acce/Z_Leg_acce").GetComponents<VRCPhysBoneBase>();

			if (pbs.Length > 1)
				DestroyComponent<VRCPhysBoneBase>(pbs[1].transform);
			string[] materialGUIDList1 = new[]
			{
				"c0252ca034162eb46990a23810a1e07d",
				"5611fc4b398eecc4f886073d221f23e2",
				"fac45238542421549bef06f342a5a28b",
				"9ad6719639344ff4c8c7c0d9e29cc8a0",
				"53e35fe2714b3f543835f9876594a5e1",
				"5bfb354df46565d479d5b3d70a86b0b6",
			};
			string[] materialGUIDList2 = new[]
			{
				"367477648768ca84eb734d731414034b",
				"39fc30cc23d31ce449650231e1a8d813",
				"0c1c9891338f7fd43a8f85667813500e",
				"788bbbd12cd3e1642a5ceb4e3aedfbd9",
				"3cd89e1491e3baa4b89f409d4d14cd62",
				"2ef2d823c931e40458c36d3ce25dccdf",
			};
			string[][] transformLists = new[]
			{
				new[] { "body_b" },
				new[] { "Body" },
				new[] { "Bra" },
				new[] { "hair_main", "hair_bob", "hair_back_long" },
				new[] { "Cloth", "cover_arm", "Over knee socks" },
				new[] { "Bag", "Boots", "cloth_Accessories", "Outer", "Tail" },
			};

			if ((reframe as RirikaReframe).colorFlg0) {
				foreach (var materialGUID in materialGUIDList1) {
					var i = Array.IndexOf(materialGUIDList1, materialGUID);
					for (int j = 0; j < transformLists[i].Length; j++) {
						if (avatarRoot.Find(transformLists[i][j]) is Transform hair) {
							var renderer = hair.GetComponent<SkinnedMeshRenderer>();

							var materials = renderer.sharedMaterials;

							materials[0] = AssetDatabase.LoadAssetAtPath<Material>(
								AssetDatabase.GUIDToAssetPath(materialGUID)
							);

							renderer.sharedMaterials = materials;
						}
					}
				}
			}
			if ((reframe as RirikaReframe).colorFlg1)
				foreach (var hairNm in transformLists[3]) {
					if (avatarRoot.Find(hairNm) is Transform hair) {
						var renderer = hair.GetComponent<SkinnedMeshRenderer>();

						var materials = renderer.sharedMaterials;

						materials[0] = AssetDatabase.LoadAssetAtPath<Material>(
							AssetDatabase.GUIDToAssetPath("f8a05f950d33acd41b3c5835fb973a7c")
						);

						renderer.sharedMaterials = materials;
					}
				}
			if ((reframe as RirikaReframe).colorFlg2) {
				foreach (var materialGUID in materialGUIDList2) {
					var i = Array.IndexOf(materialGUIDList2, materialGUID);
					for (int j = 0; j < transformLists[i].Length; j++) {
						if (avatarRoot.Find(transformLists[i][j]) is Transform hair) {
							var renderer = hair.GetComponent<SkinnedMeshRenderer>();
							var materials = renderer.sharedMaterials;
							materials[0] = AssetDatabase.LoadAssetAtPath<Material>(
								AssetDatabase.GUIDToAssetPath(materialGUID)
							);
							renderer.sharedMaterials = materials;
						}
					}
				}
			}
		}
	}
}
