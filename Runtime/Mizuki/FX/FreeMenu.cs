using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR

namespace jp.illusive_isc.IllusoryReframe.IKUSIA.Mizuki
{
    [AddComponentMenu("")]
    internal class FreeMenu : MizukiBase
    {
        internal static new readonly List<string> delPath = new()
        {
            "____________________Menu________________________",
        };
    }
}
#endif
