using System.Collections.Generic;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA.Ririka {

	internal class Backlight : Base {
		internal override List<string> GetParameters() => new() { "backlight" };

		internal override List<string> GetMenuPath() => new() { "Gimmick", "backlight" };
	}
}
