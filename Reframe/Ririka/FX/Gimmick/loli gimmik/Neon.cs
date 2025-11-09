using System.Collections.Generic;
using System.Linq;
using UnityEditor.Animations;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA.Ririka {
	internal class Neon : Base {
		internal override List<string> GetMenuPath() => new() { "Gimmick", "loli gimmik", "neon" };
		internal override List<string> GetDelPath() => new() { "Advanced/neon" };

		internal override void ChangeFxBT(List<string> Parameters) {
			base.ChangeFxBT(Parameters);
			foreach (var layer in paryi_FX.layers.Where(layer => layer.name == "MainCtrlTree")) {
				foreach (var state in layer.stateMachine.states) {
					if (state.state.motion is BlendTree blendTree) {
						blendTree.children = blendTree
							.children.Where(c => c.motion.name != "neon")
							.ToArray();
					}
				}
			}
		}
	}
}
