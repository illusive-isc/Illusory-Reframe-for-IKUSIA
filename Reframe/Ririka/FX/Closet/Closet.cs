using System.Collections.Generic;
using System.Linq;
using UnityEditor.Animations;
using UnityEngine;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA.Ririka {
	internal class Closet : Base {
		internal override List<string> GetParameters() => new()
		{
			"Ririka_Outer",
			"Ririka_Tsyatu",
			"Ririka_armcover",
			"Ririka_gloves",
			"Ririka_Pants",
			"Ririka_boots",
		};
		internal override List<string> GetMenuPath() => new() { "closet", "cloth" };

		internal override void ChangeFxBT(List<string> Parameters) {
			var targetLayer = paryi_FX.layers.FirstOrDefault(l => l.name == "MainCtrlTree");
			if (targetLayer == null)
				return;
			foreach (var state in targetLayer.stateMachine.states) {
				if (state.state.motion is not BlendTree rootTree)
					continue;

				rootTree.children = rootTree
					.children.Where(c => c.motion.name != "cloth1custom")
					.ToArray();
			}
			return;
		}
	}
}