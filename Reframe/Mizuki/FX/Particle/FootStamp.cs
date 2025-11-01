using System.Collections.Generic;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA.Mizuki {
	internal class FootStamp : Base {
		internal override List<string> GetParameters() => new() { "Particle4" };

		internal override List<string> GetMenuPath() => new() { "Particle", "Foot_stamp" };

		internal override List<string> GetDelPath() => new() { "Advanced/Particle/4" };
	}
}
