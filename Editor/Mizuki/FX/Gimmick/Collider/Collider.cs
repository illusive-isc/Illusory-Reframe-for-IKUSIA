using System.Collections.Generic;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA.Mizuki
{
    internal class Collider : MizukiBase
    {
        internal static new readonly List<string> Layers = new() { "ColliderCtrl" };

        internal static new readonly List<string> Parameters = new()
        {
            "ColliderON",
            "SpeedCollider",
            "JumpCollider",
        };

        internal static new readonly List<string> menuPath = new() { "Jump&Dash" };
        internal static new readonly List<string> delPath = new()
        {
            "Advanced/Gimmick1/JUMP",
            "Advanced/Gimmick1/SPEED",
            "Advanced/Gimmick1/JUMP",
            "Advanced/Gimmick1/SPEED",
        };
    }
}
