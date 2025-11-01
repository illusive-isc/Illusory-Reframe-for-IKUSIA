using System.Collections.Generic;
using System.Linq;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA.Ririka {
	internal class HeartGun : Base {
		internal override List<string> GetLayers() => new() { "PenCtrl_R", "PenCtrl_L" };

		internal override List<string> GetParameters() =>
			new() { "HeartGun", "HeartGunCollider R", "HeartGunCollider L" };

		internal override List<string> GetMenuPath() => new() { "Particle", "HartGun" };

		internal override List<string> GetDelPath() =>
			new() {
				"Advanced/HeartGunR",
				"Advanced/HeartGunL",
				"Advanced/HeartGunR2",
				"Advanced/HeartGunL2",
			};

		internal override void ChangeFx(List<string> Layers) {
			base.ChangeFx(new() { "HeartGun" });
			foreach (var layer in paryi_FX.layers.Where(layer => Layers.Contains(layer.name))) {
				layer.stateMachine.states = layer
					.stateMachine.states.Where(state =>
						!(
							state.state.name
							is "on"
								or "Head"
								or "shot"
								or "Head 0"
								or "shot 0"
								or "shot 0 0"
						)
					)
					.ToArray();
				var states = layer.stateMachine.states;

				foreach (var state in states) {
					if (state.state.name == "off") {
						state.state.transitions = state
							.state.transitions.Where(transition =>
								transition.destinationState.name is not "on"
							)
							.ToArray();
					}
				}
				layer.stateMachine.states = states;
			}

			paryi_FX.layers = paryi_FX
				.layers.Where(layer => !Layers.Contains(layer.name))
				.ToArray();
		}
	}
}
