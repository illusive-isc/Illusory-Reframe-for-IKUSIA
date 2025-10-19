using System.Collections.Generic;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA.Mizuki
{
    internal class Belt : Base
    {
        internal override List<string> GetParameters() => new() { "Object4" };

        internal override List<string> GetMenuPath() => new() { "Object", "belt" };

        bool BeltFlg2;

        internal override void InitializeFlags(IKUSIA.Reframe reframe)
        {
            BeltFlg2 = ((MizukiReframe)reframe).BeltFlg2;
        }

        internal override void ChangeObj(List<string> delPath)
        {
            if (BeltFlg2)
                DestroyObj(descriptor.transform.Find("add-belt"));
        }
    }
}
