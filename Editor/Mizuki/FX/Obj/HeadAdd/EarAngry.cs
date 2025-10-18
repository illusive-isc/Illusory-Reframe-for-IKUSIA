using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR

namespace jp.illusive_isc.IllusoryReframe.IKUSIA.Mizuki
{
    [AddComponentMenu("")]
    internal class EarAngry : MizukiBase
    {
        internal static new readonly List<string> Parameters = new() { "OBJ7_2" };

        internal static new readonly List<string> menuPath = new()
        {
            "Object",
            "Head add",
            "ear angry",
        };
    }
}
#endif
