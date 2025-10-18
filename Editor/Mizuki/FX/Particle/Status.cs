using System.Collections.Generic;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA.Mizuki
{
    internal class Status : MizukiBase
    {
        internal static new readonly List<string> Parameters = new() { "ParticleStatus" };
        internal static new readonly List<string> menuPath = new() { "Particle", "Status" };
        internal static new readonly List<string> delPath = new() { "Advanced/Particle/6" };
    }
}
