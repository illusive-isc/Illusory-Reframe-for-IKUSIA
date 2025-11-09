using System.Collections.Generic;
using System.Linq;
using UnityEditor.Animations;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA.Ririka {
	internal class Handheart : Base {
		internal override List<string> GetMenuPath() => new() { "Gimmick", "loli gimmik", "ハンドハート" };
		internal override List<string> GetDelPath() =>
			new() {
				"Advanced/hand heart",
				"Advanced/Constraint/Middle_L_Constraint0",
				"Advanced/Constraint/Middle_R_Constraint0",
				};
		internal override void ChangeFxBT(List<string> Parameters) {
			foreach (var layer in paryi_FX.layers.Where(layer => layer.name == "MainCtrlTree")) {
				foreach (var state in layer.stateMachine.states) {
					if (state.state.motion is BlendTree blendTree) {
						blendTree.children = blendTree
							.children.Where(c => c.motion.name != "hand heart")
							.ToArray();
					}
				}
			}
		}
	}
}
