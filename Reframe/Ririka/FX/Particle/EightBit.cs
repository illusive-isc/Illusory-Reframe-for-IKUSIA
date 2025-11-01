using System.Collections.Generic;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA.Ririka {
	internal class EightBit : Base {
		internal override List<string> GetParameters() => new() { "Particle5" };

		internal override List<string> GetMenuPath() => new() { "Particle", "EightBit" };

		internal override List<string> GetDelPath() => new() { "Advanced/Particle/5" };
	}
}
