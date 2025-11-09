using System.Collections.Generic;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA.Ririka {
	internal class Candy : Base {
		internal override List<string> GetParameters() => new() { "candy" };
		internal override List<string> GetMenuPath() => new() { "Gimmick", "food", "candy" };
		internal override List<string> GetDelPath() => new() { "Advanced/food/candy" };
	}
}