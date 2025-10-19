using System.Collections.Generic;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA.Mizuki
{
    internal class FronthairLeft : Base
    {
        internal override List<string> GetParameters() => new() { "OBJ7_4" };

        internal override List<string> GetMenuPath() =>
            new() { "Object", "Head add", "fronthair_right" };
    }
}
