using System.Collections.Generic;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA.Mizuki
{
    internal class AvatarLight : MizukiBase
    {
        internal override List<string> GetParameters() => new() { "AvatarLightStrength" };

        internal override List<string> GetMenuPath() => new() { "Gimmick", "Avatar_Light" };

        internal override void DeleteFx(List<string> Layers)
        {
            DeleteBarCtrlHandHit(GetParameters(), "AvatarLightStrength");
            DeleteBarCtrl("BarOff 0 0", "BarOpen 0 0", "AvatarLightStrength", "Color 0");
        }
    }
}
