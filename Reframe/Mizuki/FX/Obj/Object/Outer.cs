using System.Collections.Generic;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA.Mizuki
{
    internal class Outer : Base
    {
        internal override List<string> GetParameters() => new() { "Object3" };

        internal override List<string> GetMenuPath() => new() { "Object", "outer" };

        internal override List<string> GetDelPath() =>
            new()
            {
                "Outer",
                "Armature/Hips/Spine/Chest/Shoulder_R/Upperarm_R/Lowerarm_R/Right Hand/coat_hand_root_R",
                "Armature/Hips/Spine/Chest/Shoulder_L/Upperarm_L/Lowerarm_L/Left Hand/coat_hand_root_L",
            };

        bool OuterFlg2;

        internal override void InitializePlus(ReframeRuntime reframe)
        {
            OuterFlg2 = ((MizukiReframe)reframe).OuterFlg2;
        }

        internal override void ChangeObj(params string[] delPath)
        {
            if (OuterFlg2)
                base.ChangeObj(delPath);
        }
    }
}
