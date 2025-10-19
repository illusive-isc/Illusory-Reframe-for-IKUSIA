using System.Collections.Generic;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA.Mizuki
{
    internal class WhiteBreath : MizukiBase
    {
        internal override List<string> GetParameters() => new() { "Particle1" };

        internal override List<string> GetMenuPath() => new() { "Particle", "White_breath" };

        internal override List<string> GetDelPath() => new() { "Advanced/Particle/1" };
    }
}
