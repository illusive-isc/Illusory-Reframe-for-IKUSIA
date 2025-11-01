using System.Collections.Generic;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA.Mizuki {
	internal class HandTrail : Base {
		internal override List<string> GetParameters() => new() { "Particle2" };

		internal override List<string> GetMenuPath() => new() { "Particle", "Hand trail" };

		internal override List<string> GetDelPath() => new() { "Advanced/Particle/2" };
	}
}
