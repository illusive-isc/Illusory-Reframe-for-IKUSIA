using System.Collections.Generic;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA.Mizuki
{
    internal class Collider : Base
    {
        internal override List<string> GetLayers() => new() { "ColliderCtrl" };

        internal override List<string> GetParameters() =>
            new() { "ColliderON", "SpeedCollider", "JumpCollider" };

        internal override List<string> GetMenuPath() => new() { "Jump&Dash" };

        internal override List<string> GetDelPath() =>
            new()
            {
                "Advanced/Gimmick1/JUMP",
                "Advanced/Gimmick1/SPEED",
                "Advanced/Gimmick1/JUMP",
                "Advanced/Gimmick1/SPEED",
            };
    }
}
