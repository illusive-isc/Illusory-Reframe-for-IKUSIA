using System.Collections.Generic;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA.Mizuki
{
    internal class FreeMenu : MizukiBase
    {
        internal override List<string> GetDelPath() =>
            new()
            {
                "____________________Menu________________________",
                "____________________Advanced________________________ (1)",
            };
    }
}
