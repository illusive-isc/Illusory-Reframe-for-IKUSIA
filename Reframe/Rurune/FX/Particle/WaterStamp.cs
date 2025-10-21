using System.Collections.Generic;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA.Rurune
{
    internal class WaterStamp : Base
    {
        internal override List<string> GetParameters() =>
            new() { "Particle2", "WaterFoot_L", "WaterFoot_R", "Grounded" };

        internal override List<string> GetMenuPath() => new() { "Particle", "water_stamp" };

        internal override List<string> GetDelPath() => new() { "Advanced/Particle/2" };
    }
}
