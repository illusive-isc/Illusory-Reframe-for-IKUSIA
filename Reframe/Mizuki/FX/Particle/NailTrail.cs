using System.Collections.Generic;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA.Mizuki {
	internal class NailTrail : Base {
		internal override List<string> GetParameters() => new() { "Particle3" };

		internal override List<string> GetMenuPath() => new() { "Particle", "Nail_trail" };

		internal override List<string> GetDelPath() => new() { "Advanced/Particle/3" };
	}
}
