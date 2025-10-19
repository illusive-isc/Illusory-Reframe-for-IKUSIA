using System.Collections.Generic;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA.Mizuki
{
    internal class Help : Base
    {
        internal override List<string> GetParameters() => new() { "Help" };

        internal override List<string> GetMenuPath() => new() { "Gimmick2", "Help" };

        internal override List<string> GetDelPath() => new() { "Menu/MainMenu/help" };
    }
}
