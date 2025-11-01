using System.Collections.Generic;
using VRC.SDK3.Avatars.ScriptableObjects;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA.Mizuki {
	internal class Picture : Base {
		internal override List<string> GetParameters() =>
			new() { "cameraLight&eyeLookHide", "LightCamera", "eyeLook" };

		internal override List<string> GetDelPath() =>
			new() { "Advanced/LookOBJHead", "Advanced/CametaLightOBJ_World" };

		internal static readonly List<List<string>> menuPathList = new() {
			new() { "Gimmick", "Light_Gun", "Light_camera_on" },
			new() { "Gimmick", "Light_Gun", "eyeLook" },
			new() { "Gimmick", "Light_Gun", "cameraLight&eyeLookHide" },
		};

		internal override void EditVRCExpressions(VRCExpressionsMenu menu, List<string> menuPath) {
			foreach (var item in menuPathList)
				base.EditVRCExpressions(menu, item);
		}
	}
}
