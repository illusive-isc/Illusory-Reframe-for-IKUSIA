using System.Collections.Generic;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA.Ririka {
	internal class WhiteBreath : Base {
		internal override List<string> GetParameters() => new() { "Particle1", "Voice" };

		internal override List<string> GetMenuPath() => new() { "Particle", "White_breath" };

		internal override List<string> GetDelPath() => new() { "Advanced/Particle/1" };
	}
}
