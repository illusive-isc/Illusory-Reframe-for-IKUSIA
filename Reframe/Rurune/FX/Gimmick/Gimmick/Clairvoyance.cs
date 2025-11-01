using System.Collections.Generic;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA.Rurune {
	internal class Clairvoyance : Base {
		internal override List<string> GetParameters() => new() { "clairvoyance" };

		internal override List<string> GetMenuPath() => new() { "Gimmick", "Clairvoyance" };

		internal override List<string> GetDelPath() => new() { "Advanced/clairvoyance" };
	}
}
