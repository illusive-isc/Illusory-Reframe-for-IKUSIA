using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR

namespace jp.illusive_isc.IllusoryReframe.IKUSIA.Mizuki
{
    [AddComponentMenu("")]
    internal class Help : MizukiBase
    {
        internal static new readonly List<string> Parameters = new() { "Help" };

        internal static new readonly List<string> menuPath = new() { "Gimmick2", "Help" };
        internal static new readonly List<string> delPath = new() { "Menu/MainMenu/help" };
    }
}
#endif
