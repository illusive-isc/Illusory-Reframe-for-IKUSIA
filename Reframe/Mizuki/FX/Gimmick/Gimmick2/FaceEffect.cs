using System.Collections.Generic;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA.Mizuki
{
    internal class FaceEffect : Base
    {
        internal override List<string> GetParameters() => new() { "faceeffect" };

        internal override List<string> GetMenuPath() =>
            new() { "Gimmick2", "Gesture_change", "faceeffect" };

        internal override List<string> GetDelPath() => new() { "Advanced/FaceEffect" };
    }
}
