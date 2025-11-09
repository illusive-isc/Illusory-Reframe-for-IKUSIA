using System.Collections.Generic;
using System.Linq;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA.Ririka {
	internal class Gam : Base {
		internal override List<string> GetParameters() => new() { "gam" };
		internal override List<string> GetMenuPath() => new() { "Gimmick", "food", "gam" };
		internal override List<string> GetDelPath() => new() { "Advanced/food/can drink Hand" };

		internal override void ChangeFx(List<string> Layers) {
			foreach (var layer in paryi_FX.layers.Where(layer => layer.name is "LipSynk")) {
				layer.stateMachine.states =
				layer.stateMachine.states.
					Where(state => !(state.state.name is "mouthgam" or "mouthgam loop" or "mouthgam 0"))
					.ToArray();
				var states = layer.stateMachine.states;

				foreach (var state in states) {
					if (state.state.name is "off" or "mouth0") {
						state.state.transitions = state
							.state.transitions.Where(transition =>
								transition.destinationState.name is not "mouthgam"
							)
							.ToArray();
					}
				}
				layer.stateMachine.states = states;
			}
			foreach (var layer in paryi_FX.layers.Where(layer => layer.name is "Blink_Control")) {
				layer.stateMachine.states = layer
					.stateMachine.states.Where(s => s.state.name != "mouth1")
					.ToArray();

				var stateMachine = layer.stateMachine;
				stateMachine.anyStateTransitions = stateMachine
					.anyStateTransitions.Where(t => t.destinationState.name != "mouth1")
					.ToArray();
			}
			paryi_FX.layers = paryi_FX
				.layers.Where(layer => !Layers.Contains(layer.name))
				.ToArray();
		}
	}
}