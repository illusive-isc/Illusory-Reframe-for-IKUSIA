using System.Collections.Generic;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA.Mizuki
{
    internal class FreeParticle : MizukiBase
    {
        internal static new readonly List<string> Parameters = new()
        {
            "Paricle8_1",
            "Paricle8_2",
            "Paricle8_3",
            "Paricle8_4",
            "Paricle8_5",
            "Paricle8_6",
            "Paricle8_7",
            "Paricle8_8",
        };

        internal static new readonly List<string> menuPath = new() { "Particle", "Particle Free" };
        internal static new readonly List<string> delPath = new() { "Particle" };
    }
}
