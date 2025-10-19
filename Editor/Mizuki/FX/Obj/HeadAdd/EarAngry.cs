using System.Collections.Generic;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA.Mizuki
{
    internal class EarAngry : MizukiBase
    {
        internal override List<string> GetParameters() => new() { "OBJ7_2" };

        internal override List<string> GetMenuPath() => new() { "Object", "Head add", "ear angry" };
    }
}
