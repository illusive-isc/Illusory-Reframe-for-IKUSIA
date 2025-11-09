using System.Collections.Generic;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA.Ririka {
	internal class Noisepanel : Base {
		internal override List<string> GetParameters() => new() { "noisepanel", };
		internal override List<string> GetMenuPath() => new() { "Gimmick", "loli gimmik", "容疑者風" };
		internal override List<string> GetDelPath() => new() { "Advanced/noise panel" };
    }
}
