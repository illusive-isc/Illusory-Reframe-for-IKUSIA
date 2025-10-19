using System.Collections.Generic;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA.Mizuki
{
    internal class CameraPicture : Base
    {
        internal override List<string> GetLayers() => new() { "CameraPicture" };

        internal override List<string> GetParameters() =>
            new() { "Gimmick1_7", "CameraPictureDistance" };

        internal override List<string> GetMenuPath() => new() { "Gimmick", "Camera" };

        internal override List<string> GetDelPath() => new() { "Advanced/CameraPictureWorld" };
    }
}
