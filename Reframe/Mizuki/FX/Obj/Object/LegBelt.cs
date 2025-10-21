using System.Collections.Generic;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA.Mizuki
{
    internal class LegBelt : Base
    {
        internal override List<string> GetParameters() => new() { "Object5" };

        internal override List<string> GetMenuPath() => new() { "Object", "leg belt" };

        bool LegBeltFlg2;

        internal override void InitializeFlags(ReframeRuntime reframe)
        {
            LegBeltFlg2 = ((MizukiReframe)reframe).LegBeltFlg2;
        }

        internal override void ChangeObj(params string[] delPath)
        {
            if (LegBeltFlg2)
                DestroyObj(avatarRoot.Find("leg-garter"));
        }
    }
}
