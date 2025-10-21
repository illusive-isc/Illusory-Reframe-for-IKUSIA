using System.Collections.Generic;
using VRC.SDK3.Avatars.ScriptableObjects;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA.Rurune
{
    internal class Picture : Base
    {
        internal override List<string> GetParameters() =>
            new() { "LightCamera", "LookOBJ", "eyeLook", "Camera_eye_hide" };

        internal override List<string> GetDelPath() =>
            new() { "Advanced/LookOBJHead", "Advanced/CametaLightOBJ_World" };

        internal static readonly List<List<string>> menuPathList = new()
        {
            new() { "Gimmick", "Picture", "Light_camera_on" },
            new() { "Gimmick", "Picture", "eye tracking" },
            new() { "Gimmick", "Picture", "Camera_eye_hide" },
        };

        internal override void EditVRCExpressions(VRCExpressionsMenu menu, List<string> menuPath)
        {
            foreach (var item in menuPathList)
                base.EditVRCExpressions(menu, item);
        }
    }
}
