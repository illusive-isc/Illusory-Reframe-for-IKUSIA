using System.Collections.Generic;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA.Mizuki {
	internal class Issyou : Base {
		internal override List<string> GetParameters() => new() { "Gimmick2_7" };

		internal override List<string> GetMenuPath() => new() { "Gimmick2", "Gimmick7" };

		internal override List<string> GetDelPath() => new() { "Advanced/Gimmick2/7" };
	}
}
