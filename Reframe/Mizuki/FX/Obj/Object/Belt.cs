using System.Collections.Generic;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA.Mizuki
{
    internal class Belt : Base
    {
        internal override List<string> GetParameters() => new() { "Object4" };

        internal override List<string> GetMenuPath() => new() { "Object", "belt" };

        bool BeltFlg2;

        internal override void InitializePlus(ReframeRuntime reframe)
        {
            BeltFlg2 = ((MizukiReframe)reframe).BeltFlg2;
        }

        internal override void ChangeObj(params string[] delPath)
        {
            if (BeltFlg2)
                DestroyObj(avatarRoot.Find("add-belt"));
        }
    }
}
