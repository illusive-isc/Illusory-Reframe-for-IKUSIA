using System.Collections.Generic;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA.Mizuki
{
    internal class TPS : MizukiBase
    {
        internal override List<string> GetParameters() => new() { "TPS" };

        internal override List<string> GetMenuPath() => new() { "Gimmick", "TPS" };

        internal override List<string> GetDelPath() => new() { "Advanced/TPS" };
    }
}
