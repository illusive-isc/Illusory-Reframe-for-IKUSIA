using System.Collections.Generic;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA.Mizuki
{
    internal class Clairvoyance : MizukiBase
    {
        internal override List<string> GetParameters() => new() { "clairvoyance" };

        internal override List<string> GetMenuPath() => new() { "Gimmick", "Clairvoyance" };

        internal override List<string> GetDelPath() => new() { "Advanced/clairvoyance" };
    }
}
