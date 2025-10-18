using System.Collections.Generic;
using UnityEditor.Animations;
using VRC.SDK3.Avatars.Components;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA.Mizuki
{
    internal class Belt : MizukiBase
    {
        internal static new readonly List<string> Parameters = new() { "Object4" };

        internal static new readonly List<string> menuPath = new() { "Object", "belt" };

        bool BeltFlg2;

        internal void Initialize(
            VRCAvatarDescriptor descriptor,
            AnimatorController paryi_FX,
            MizukiReframe optimizer
        )
        {
            this.descriptor = descriptor;
            this.paryi_FX = paryi_FX;
            BeltFlg2 = optimizer.BeltFlg2;
        }

        internal new void ChangeObj(List<string> delPath)
        {
            if (BeltFlg2)
                DestroyObj(descriptor.transform.Find("add-belt"));
        }
    }
}
