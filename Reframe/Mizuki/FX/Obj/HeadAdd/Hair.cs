using System.Collections.Generic;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA.Mizuki
{
    internal class Hair : Base
    {
        internal override List<string> GetDelPath() =>
            new() { "Armature/Hips/Spine/Chest/Neck/Head/Hair_root", "hair_back", "hair_front" };

        internal override void ChangeObj(List<string> delPath)
        {
            base.ChangeObj(delPath);
        }
    }
}
