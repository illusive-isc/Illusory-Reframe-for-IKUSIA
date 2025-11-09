using System.Collections.Generic;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA.Ririka {
	internal class Boots : Base {

		internal override List<string> GetDelPath() => new() { "Boots", "Armature/Hips/Upperleg_R/Lowerleg_R/Foot_R/PB_boots_chain_R", "Armature/Hips/Upperleg_L/Lowerleg_L/Foot_L/PB_boots_chain_L" };
	}
}