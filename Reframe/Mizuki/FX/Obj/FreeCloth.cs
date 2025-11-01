using System.Collections.Generic;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA.Mizuki {
	internal class FreeCloth : Base {
		internal override List<string> GetParameters() => new() { "Cloth" };

		internal override List<string> GetMenuPath() => new() { "Cloth" };

		internal override List<string> GetDelPath() => new() { "Cloth" };
	}
}
