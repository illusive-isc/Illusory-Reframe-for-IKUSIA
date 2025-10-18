using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR

namespace jp.illusive_isc.IllusoryReframe.IKUSIA.Mizuki
{
    [AddComponentMenu("")]
    internal class FronthairLeft : MizukiBase
    {
        internal static new readonly List<string> Parameters = new() { "OBJ7_4" };

        internal static new readonly List<string> menuPath = new()
        {
            "Object",
            "Head add",
            "fronthair_right",
        };
    }
}
#endif
