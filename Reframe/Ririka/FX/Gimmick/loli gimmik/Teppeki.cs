using System.Collections.Generic;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA.Ririka {
	internal class Teppeki : Base {
		internal override List<string> GetParameters() => new() { "teppeki", "teppeki contact", };
		internal override List<string> GetMenuPath() => new() { "Gimmick", "loli gimmik", "鉄壁" };
		internal override List<string> GetDelPath() => new() { "Advanced/teppeki" };

	}
}