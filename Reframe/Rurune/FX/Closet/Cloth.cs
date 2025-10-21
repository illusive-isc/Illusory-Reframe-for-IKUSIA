using System.Collections.Generic;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA.Rurune
{
    internal class Cloth : Base
    {
        internal override List<string> GetDelPath() => new() { "cloth" };

        internal string[] GetDelPath2() =>
            new[]
            {
                "Armature/Hips/Skirt_Root/Skirt_Root_L/Skirt_back",
                "Armature/Hips/Skirt_Root/Skirt_Root_L/Skirt_L",
                "Armature/Hips/Skirt_Root/Skirt_Root_L/Skirt_L.007",
                "Armature/Hips/Skirt_Root/Skirt_Root_L/Skirt_L.012",
                "Armature/Hips/Skirt_Root/Skirt_Root_L/Skirt_L.017",
                "Armature/Hips/Skirt_Root/Skirt_Root_R/Skirt_R",
                "Armature/Hips/Skirt_Root/Skirt_Root_R/Skirt_R.007",
                "Armature/Hips/Skirt_Root/Skirt_Root_R/Skirt_R.012",
                "Armature/Hips/Skirt_Root/Skirt_Root_R/Skirt_R.017",
            };

        internal override void ChangeObj(params string[] delPath)
        {
            base.ChangeObj(delPath);
            if (
                ((RuruneReframe)reframe).JacketFlg
                && ((RuruneReframe)reframe).ClothFlg
                && ((RuruneReframe)reframe).AcceFlg
            )
            {
                if (((RuruneReframe)reframe).TailDelFlg)
                    base.ChangeObj("Armature/Hips/Skirt_Root");
                else
                    base.ChangeObj(GetDelPath2());
            }
        }
    }
}
