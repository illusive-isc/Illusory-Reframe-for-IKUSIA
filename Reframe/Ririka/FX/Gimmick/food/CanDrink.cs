using System.Collections.Generic;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA.Ririka {
	internal class CanDrink : Base {

		internal override List<string> GetParameters() => new() { "drink" };
		internal override List<string> GetMenuPath() => new() { "Gimmick", "food", "ジュース" };
		internal override List<string> GetDelPath() => new() { "Advanced/food/can drink Hand" };

	}
}
