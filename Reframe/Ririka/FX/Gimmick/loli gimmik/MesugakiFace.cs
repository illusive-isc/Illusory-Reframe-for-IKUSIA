using System.Collections.Generic;
using System.Linq;
using VRC.SDK3.Avatars.ScriptableObjects;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA.Ririka {
	internal class MesugakiFace : Base {

		internal override List<string> GetParameters() => new()
		{
			"mesugaki face",
			"mesugaki face random",
			"mesugaki face particle",
		};
		internal override List<string> GetMenuPath() => new() { "Gimmick", "loli gimmik", "ハンドハート" };
		internal override List<string> GetDelPath() => new() { "Advanced/hand heart", "Advanced/mesugakiparticle" };

		internal override void ChangeFx(List<string> Layers) {
			foreach (var layer in paryi_FX.layers.Where(layer => layer.name is "LeftHand" or "RightHand")) {
				foreach (var sub in layer.stateMachine.stateMachines)
					if (sub.stateMachine.name == "mesugaki face") {
						layer.stateMachine.RemoveStateMachine(sub.stateMachine);
						break;
					}
				foreach (var t in layer.stateMachine.anyStateTransitions)
					t.conditions = t.conditions
						.Where(c => c.parameter != "mesugaki face")
						.ToArray();

				foreach (var state in layer.stateMachine.states) {
					foreach (var transition in state.state.transitions.Where(t => t.isExit).ToArray())
						state.state.RemoveTransition(transition);
				}
			}
		}
		internal override void EditVRCExpressions(VRCExpressionsMenu menu, List<string> menuPath) {
			base.EditVRCExpressions(menu, new() { "Gimmick", "loli gimmik", "mesugaki face" });
			base.EditVRCExpressions(menu, new() { "Gimmick", "loli gimmik", "mesugaki face particle" });
		}
	}
}