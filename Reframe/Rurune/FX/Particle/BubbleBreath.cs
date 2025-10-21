using System.Collections.Generic;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA.Rurune
{
    internal class BubbleBreath : Base
    {
        internal override List<string> GetParameters() => new() { "Particle3" };

        internal override List<string> GetMenuPath() => new() { "Particle", "bubble breath" };

        internal override List<string> GetDelPath() => new() { "Advanced/Particle/3" };
    }
}
