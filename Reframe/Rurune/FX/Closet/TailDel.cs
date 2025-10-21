using System.Collections.Generic;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA.Rurune
{
    internal class TailDel : Base
    {
        internal override List<string> GetParameters() => new() { "tail_Ground" };

        internal override List<string> GetDelPath() =>
            new() { "sharktail", "Advanced/tail_Ground", "Advanced/sippo_contact" };
    }
}
