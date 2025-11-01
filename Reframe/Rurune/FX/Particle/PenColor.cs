using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditor.Animations;
using UnityEngine;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA.Rurune {
	internal class PenColor : Base {
		protected static string[] PenColorList =>
			new string[]
			{
				"d567f8ad4be58e84a808e6de4bf7c6e7",
				"dc067eb7355276a41a6e80b1d455c41e",
				"7df61d410a91bd84782ca5c196c3b57f",
				"84e2cf9000547da498cda965483da2d5",
				"d255f0f42f7960147aa799730ec8c474",
				"b706355151043954a8519390167f17d6",
				"91bf94f1676929441b0ede91a9fac815",
				"aea3fdd607aa6c64d8133fc4d7fe68aa",
				"a53171a567a4cbb409e6c89fc81e0dc6",
				"25bd9abba42881d43b1aaa0c9dfe116d",
				"61a934a8f73bdab45a17dc2712e9b79a",
				"a17f550ae9b8fb24c96e68f7e22a602c",
				"838345033a832e74698c664420aeb74b",
				"9a1572a023d9c7d429aded1db67647e3",
				"f0638953442e7e242a311785c3a4ede6",
				"c6199fd407313bc4086f653bbce7b83c",
				"dacc5218969b88f48abed5944559f1f9",
				"8ae512d68061cd742846accb8a171bae",
			};

		internal override void ChangeFxBT(List<string> Parameters) {
			foreach (var layer in paryi_FX.layers.Where(layer => layer.name == "MainCtrlTree")) {
				var state = layer
					.stateMachine.states.Where(s =>
						s.state != null && s.state.name == "MainCtrlTree"
					)
					.ToArray();
				if (state.Length != 0) {
					var blendTree = state[0].state.motion as BlendTree;
					var children = blendTree.children;

					for (int i = 0; i < children.Length; i++) {
						var Tree = children[i].motion as BlendTree;
						if (Tree != null && Tree.name == "PenColor") {
							var penColorBlendTree = Tree;
							var penColorChildren = penColorBlendTree.children;

							var penColor1Clip = AssetDatabase.LoadAssetAtPath<AnimationClip>(
								AssetDatabase.GUIDToAssetPath(
									PenColorList[(int)((RuruneReframe)reframe).PenColor1]
								)
							);

							var penColor2Clip = AssetDatabase.LoadAssetAtPath<AnimationClip>(
								AssetDatabase.GUIDToAssetPath(
									PenColorList[(int)((RuruneReframe)reframe).PenColor2]
								)
							);

							var newChildren = new ChildMotion[penColorChildren.Length];
							for (int j = 0; j < penColorChildren.Length; j++) {
								newChildren[j] = penColorChildren[j];

								if (j == 0 && penColor1Clip != null)
									newChildren[j].motion = penColor1Clip;
								else if (j == 1 && penColor2Clip != null)
									newChildren[j].motion = penColor2Clip;
							}

							penColorBlendTree.children = newChildren;
							break;
						}
					}
				}
			}
		}
	}
}
