using System.Collections.Generic;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA.Mizuki
{
    internal class Accesary : Base
    {
        internal override List<string> GetParameters() => new() { "OBJ7_8" };

        internal override List<string> GetMenuPath() => new() { "Object", "Head add", "accesary" };

        bool AccesaryFlg2;

        internal override void InitializeFlags(IKUSIA.Reframe reframe)
        {
            AccesaryFlg2 = ((MizukiReframe)reframe).AccesaryFlg2;
        }

        internal override void ChangeObj(List<string> delPath)
        {
            if (AccesaryFlg2)
                DestroyObj(descriptor.transform.Find("Add-Ribbon"));
        }
    }
}
