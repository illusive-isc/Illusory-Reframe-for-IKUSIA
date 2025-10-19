using System.Collections.Generic;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA.Mizuki
{
    internal class FronthairRight : MizukiBase
    {
        internal override List<string> GetParameters() => new() { "OBJ7_3" };

        internal override List<string> GetMenuPath() =>
            new() { "Object", "Head add", "fronthair_right" };
    }
}
