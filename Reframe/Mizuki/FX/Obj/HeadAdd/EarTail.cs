using System.Collections.Generic;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA.Mizuki
{
    internal class EarTail : Base
    {
        internal override List<string> GetParameters() => new() { "OBJ7_1" };

        internal override List<string> GetMenuPath() => new() { "Object", "Head add", "ear tail" };

        bool EarTailFlg2;

        internal override void InitializeFlags(ReframeRuntime reframe)
        {
            EarTailFlg2 = ((MizukiReframe)reframe).EarTailFlg2;
        }

        internal override List<string> GetDelPath() =>
            new() { "Armature/Hips/tail", "Armature/Hips/Spine/Chest/Neck/Head/TigerEar" };

        internal override void ChangeObj(List<string> delPath)
        {
            base.ChangeObj(delPath);
            if (EarTailFlg2)
                DestroyObj(descriptor.transform.Find("eartail"));
        }
    }
}
