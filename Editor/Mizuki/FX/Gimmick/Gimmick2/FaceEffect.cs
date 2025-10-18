using System.Collections.Generic;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA.Mizuki
{
    internal class FaceEffect : MizukiBase
    {
        internal static new readonly List<string> Parameters = new() { "faceeffect" };

        internal static new readonly List<string> menuPath = new()
        {
            "Gimmick2",
            "Gesture_change",
            "faceeffect",
        };
        internal static new readonly List<string> delPath = new() { "Advanced/FaceEffect" };
    }
}
