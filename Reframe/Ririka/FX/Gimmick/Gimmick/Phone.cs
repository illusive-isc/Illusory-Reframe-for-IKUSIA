using System.Collections.Generic;
using System.Linq;
using UnityEditor.Animations;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA.Ririka {

	internal class Phone : Base {

		internal override List<string> GetParameters() => new()
		{
			"phone on",
			"phone light on",
			"phone incamera",
		};
		internal override List<string> GetLayers() => new() { "camera" };

		internal override List<string> GetMenuPath() => new() { "Gimmick", "camera", "phone" };
		internal override List<string> GetDelPath() => new() { "Advanced/phone", "Armature/Hips/Spine/Chest/sholder_L/Upperarm_L/Lowerarm_L/Left Hand/phone" };

		internal override void ChangeFxBT(List<string> Parameters) {
			base.ChangeFxBT(Parameters);
			foreach (var layer in paryi_FX.layers.Where(layer => layer.name == "MainCtrlTree")) {
				foreach (var state in layer.stateMachine.states) {
					if (state.state.motion is BlendTree blendTree) {
						blendTree.children = blendTree
							.children.Where(c => c.motion.name != "phone")
							.ToArray();
					}
				}
			}
		}
	}
}