using System.Collections.Generic;
using VRC.SDK3.Avatars.ScriptableObjects;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA.Mizuki {
	internal class Teleport : Base {
		internal override List<string> GetParameters() => new() { "warpA", "warpB" };

		internal override List<string> GetDelPath() => new() { "Advanced/Teleport_World" };

		internal override void EditVRCExpressions(VRCExpressionsMenu menu, List<string> menuPath) {
			if (menu == null || menuPath == null)
				return;
			RemoveMenuItemRecursivelyInternal(menu, new() { "Gimmick", "WarpA" }, 0);
			RemoveMenuItemRecursivelyInternal(menu, new() { "Gimmick", "WarpB" }, 0);
		}
	}
}
