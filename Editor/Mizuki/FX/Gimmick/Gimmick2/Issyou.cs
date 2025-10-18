using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR

namespace jp.illusive_isc.IllusoryReframe.IKUSIA.Mizuki
{
    [AddComponentMenu("")]
    internal class Issyou : MizukiBase
    {
        internal static new readonly List<string> Parameters = new() { "Gimmick2_7" };

        internal static new readonly List<string> menuPath = new() { "Gimmick2", "Gimmick7" };
        internal static new readonly List<string> delPath = new() { "Advanced/Gimmick2/7" };
    }
}
#endif
