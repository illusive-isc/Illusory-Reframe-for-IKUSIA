using System.Collections.Generic;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA.Ririka {
	internal class Pet : Base {
		internal override List<string> GetLayers() => new() { "Pet", "Pet Animation" };

		internal override List<string> GetParameters() =>
			new() {
				"pet",
				"pet position custom",
				"pet position X",
				"pet position Y",
				"pet_stand_position_look",
				"Head_search_X+",
				"Head_search_X-",
				"Head_search_Y+",
				"Head_search_Y-",
				"Head_search_Z+",
				"Head_search_Z-",
				"pet to pet contact",
			};

		internal override List<string> GetMenuPath() => new() { "Gimmick", "Pet" };

		internal override List<string> GetDelPath() =>
			new() {
				"Advanced/Pet model",
				"Advanced/Pet_Player_Position",
				"Advanced/Pet_follow",
				"Advanced/PlayerDistance_Pet",
			};
	}
}
