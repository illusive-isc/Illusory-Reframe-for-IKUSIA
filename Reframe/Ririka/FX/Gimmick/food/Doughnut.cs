using System.Collections.Generic;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA.Ririka {
	internal class Doughnut : Base {
		internal override List<string> GetLayers() => new() { "doughnut" };
		internal override List<string> GetParameters() => new() { "doughnut" };
		internal override List<string> GetMenuPath() => new() { "Gimmick", "food", "doughnut" };
		internal override List<string> GetDelPath() => new() {
			"Advanced/food/doughnut",
			"Advanced/food/doughnut_contact",
			"Advanced/food/food hand contact R",
			"Advanced/food/food hand contact L"
			};
	}
}
