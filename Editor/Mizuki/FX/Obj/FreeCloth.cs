using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR

namespace jp.illusive_isc.IllusoryReframe.IKUSIA.Mizuki
{
    [AddComponentMenu("")]
    internal class FreeCloth : MizukiBase
    {
        internal static new readonly List<string> Parameters = new() { "Cloth" };

        internal static new readonly List<string> menuPath = new() { "Cloth" };
        internal static new readonly List<string> delPath = new() { "Cloth" };
    }
}
#endif
