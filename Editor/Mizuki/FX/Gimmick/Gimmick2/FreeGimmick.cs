using System.Collections.Generic;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA.Mizuki
{
    internal class FreeGimmick : MizukiBase
    {
        internal override List<string> GetParameters() =>
            new()
            {
                "Gimmick2_8_1",
                "Gimmick2_8_2",
                "Gimmick2_8_3",
                "Gimmick2_8_4",
                "Gimmick2_8_5",
                "Gimmick2_8_6",
                "Gimmick2_8_7",
                "Gimmick2_8_8",
            };

        internal override List<string> GetMenuPath() => new() { "Gimmick2", "Free" };

        internal override List<string> GetDelPath() => new() { "Gimmick2" };
    }
}
