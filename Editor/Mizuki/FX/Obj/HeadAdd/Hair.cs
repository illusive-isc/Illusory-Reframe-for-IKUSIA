using System.Collections.Generic;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA.Mizuki
{
    internal class Hair : MizukiBase
    {
        internal static new readonly List<string> delPath = new()
        {
            "Armature/Hips/Spine/Chest/Neck/Head/Hair_root",
            "hair_back",
            "hair_front",
        };

        internal new void ChangeObj(List<string> delPath)
        {
            base.ChangeObj(delPath);
        }
    }
}
