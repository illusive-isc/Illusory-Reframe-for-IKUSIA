using System.Collections.Generic;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA.Mizuki {
	internal class FreeParticle : Base {
		internal override List<string> GetParameters() =>
			new() {
				"Paricle8_1",
				"Paricle8_2",
				"Paricle8_3",
				"Paricle8_4",
				"Paricle8_5",
				"Paricle8_6",
				"Paricle8_7",
				"Paricle8_8",
			};

		internal override List<string> GetMenuPath() => new() { "Particle", "Particle Free" };

		internal override List<string> GetDelPath() => new() { "Particle" };
	}
}
