using System.Collections.Generic;
using System.Linq;
using UnityEditor.Animations;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA.Ririka {
	internal class Pet : Base {
		internal override List<string> GetLayers() => new() { "Pet", "Pet Animation" };

		internal override List<string> GetParameters() =>
			new() {
				"pet",
				"pet position X",
				"pet position Y",
				"pet position custom",
				"pet to pet contact",
				"pet_stand_position_look",
				"Pet Grab_IsGrabbed",
				"pet stand head",
				"pet stand sholder_L",
				"pet stand sholder_R",
				"Head_search",
				"Head_search_X+",
				"Head_search_X-",
				"Head_search_Y+",
				"Head_search_Y-",
				"Head_search_Z+",
				"Head_search_Z-",
				"pet frend on",
				"pet player dis",
			};

		internal override List<string> GetMenuPath() => new() { "Gimmick", "Pet" };
		internal override void ChangeFxBT(List<string> Parameters) {
			base.ChangeFxBT(Parameters);
			foreach (var layer in paryi_FX.layers.Where(layer => layer.name == "MainCtrlTree")) {
				foreach (var state in layer.stateMachine.states) {
					if (state.state.motion is BlendTree blendTree) {
						blendTree.children = blendTree
							.children.Where(c => c.motion.name != "pet position custom")
							.ToArray();
					}
				}
			}
		}
		internal override List<string> GetDelPath() =>
			new() {
				"Advanced/Pet",
				"Advanced/pet position Particle",
			};
	}
}
