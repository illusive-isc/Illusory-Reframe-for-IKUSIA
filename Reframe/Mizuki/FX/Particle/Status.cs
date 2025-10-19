using System.Collections.Generic;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA.Mizuki
{
    internal class Status : Base
    {
        internal override List<string> GetParameters() => new() { "ParticleStatus" };

        internal override List<string> GetMenuPath() => new() { "Particle", "Status" };

        internal override List<string> GetDelPath() => new() { "Advanced/Particle/6" };
    }
}
