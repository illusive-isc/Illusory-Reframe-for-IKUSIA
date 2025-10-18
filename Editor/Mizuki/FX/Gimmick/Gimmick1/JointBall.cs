using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR

namespace jp.illusive_isc.IllusoryReframe.IKUSIA.Mizuki
{
    [AddComponentMenu("")]
    internal class JointBall : MizukiBase
    {
        internal static new readonly List<string> Parameters = new() { "Gimmick1_8" };
        internal static new readonly List<string> menuPath = new() { "Gimmick", "JointBall" };
        internal static new readonly List<string> delPath = new() { "Advanced/Gimmick1/8" };
    }
}
#endif
