using System.Collections.Generic;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA.Rurune {
	internal class Pet : Base {
		internal override List<string> GetLayers() => new() { "Pet", "Pet_Animation", "Pet_Sleep" };

		internal override List<string> GetParameters() =>
			new()
			{
				"Pet_position.X",
				"Pet_position.Y",
				"Pet_position.Z",
				"Head_search_X+",
				"Head_search_X-",
				"Head_search_Y+",
				"Head_search_Y-",
				"Head_search_Z+",
				"Head_search_Z-",
				"Pet_RandomPosition_off",
                // 実体なし
                "Pet_Move_Contact",
				"Pet_position.X_Local",
				"Pet_position.Y_Local",
				"Pet_position.Z_Local",
				"PlayerDistance_Pet",
				"Head_search_Distance",
				"Pet_Grab_bone_IsGrabbed",
				"Pet_Head_Contact",
				"Pet_Move_Stop",
				"Head_search_off",
				"Pet_Player_Position",
				"Pet_ON",
				"Pet_Head_Stay",
				"Pet_Hand_hit",
				"Pet_Head_Position",
			};

		internal override List<string> GetMenuPath() => new() { "Gimmick", "Pet" };

		internal override List<string> GetDelPath() =>
			new()
			{
				"Advanced/Pet model",
				"Advanced/Pet_Player_Position",
				"Advanced/Pet_follow",
				"Advanced/PlayerDistance_Pet",
			};
	}
}
