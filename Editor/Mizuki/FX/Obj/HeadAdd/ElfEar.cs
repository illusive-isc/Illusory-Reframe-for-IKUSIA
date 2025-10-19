using System.Collections.Generic;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA.Mizuki
{
    internal class ElfEar : MizukiBase
    {
        internal override List<string> GetParameters() => new() { "OBJ7_5" };

        internal override List<string> GetMenuPath() => new() { "Object", "Head add", "elf ear" };
    }
}
