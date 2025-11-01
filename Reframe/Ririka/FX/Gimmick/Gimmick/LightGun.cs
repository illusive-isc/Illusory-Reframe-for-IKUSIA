using System.Collections.Generic;
using VRC.SDK3.Avatars.ScriptableObjects;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA.Ririka {
	internal class LightGun : Base {
		internal override List<string> GetLayers() => new() { "butterfly" };

		internal override List<string> GetParameters() =>
			new()
			{
				"LightGun",
				"LightColor",
				"LightStrength",
				"butterfly_Set",
				"butterfly_Shot",
				"butterfly_stand",
				"butterfly_FingerIndexL",
				"butterfly_Gesture_Set",
			};

		internal override List<string> GetDelPath() => new() { "Advanced/butterfly" };

		internal static readonly List<List<string>> menuPathList = new(){
			new() { "Gimmick", "Light_Gun", "Light_Gun_On" },
			new() { "Gimmick", "Light_Gun", "Light_Gun_Option" },
			new() { "Gimmick", "Light_Gun", "Light_color" },
			new() { "Gimmick", "Light_Gun", "Light strength" },
			new() { "Gimmick", "Light_Gun" },
		};

		internal override void EditVRCExpressions(VRCExpressionsMenu menu, List<string> menuPath) {
			foreach (var item in menuPathList)
				base.EditVRCExpressions(menu, item);
		}
	}
}
