using System.Collections.Generic;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA.Ririka {
	internal class TPS : Base {
		internal override List<string> GetParameters() => new() { "TPS" };

		internal override List<string> GetMenuPath() => new() { "Gimmick", "TPS" };

		internal override List<string> GetDelPath() => new() { "Advanced/TPS" };
	}
}
