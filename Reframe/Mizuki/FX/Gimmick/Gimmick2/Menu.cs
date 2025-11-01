using System.Collections.Generic;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA.Mizuki {
	internal class Menu : Base {
		internal override List<string> GetLayers() =>
			new() {
				"MainKeyCtrl",
				"MainIntCtrl",
				"MainCtrl",
				"MenuButtonCtrl",
				"MenuOpenGestureCtrl",
				"BarCtrl",
				"BarCtrlHandHit",
			};

		internal override List<string> GetParameters() =>
			new() {
				"Paryi_MenuMainInt",
				"MenuButtonGlobalToggle",
				"MenuStart",
				"BarType",
				"Voice",
				"Viseme",
			};

		internal override List<string> GetMenuPath() => new() { "Gimmick2", "MenuDesktop" };

		internal override List<string> GetDelPath() => new() { "MenuGrabWorld", "Menu" };
	}
}
