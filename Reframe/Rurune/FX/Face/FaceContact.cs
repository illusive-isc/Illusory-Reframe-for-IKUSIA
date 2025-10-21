using System.Collections.Generic;
using VRC.SDK3.Avatars.ScriptableObjects;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA.Rurune
{
    internal class FaceContact : Base
    {
        public bool kamitukiFlg = false;
        public bool nadeFlg = false;

        internal override void InitializeFlags(ReframeRuntime reframe)
        {
            kamitukiFlg = ((RuruneReframe)reframe).kamitukiFlg;
            nadeFlg = ((RuruneReframe)reframe).nadeFlg;
        }

        internal override void ChangeFxBT(List<string> Parameters)
        {
            if (nadeFlg)
                base.ChangeFxBT(new() { "Nade" });
            if (kamitukiFlg)
                base.ChangeFxBT(new() { "Kamituki" });
        }

        internal override void EditVRCExpressions(VRCExpressionsMenu menu, List<string> menuPath)
        {
            if (nadeFlg)
                RemoveMenuItemRecursivelyInternal(menu, new() { "Gimmick", "Face", "なでなで" }, 0);
            if (kamitukiFlg)
                RemoveMenuItemRecursivelyInternal(
                    menu,
                    new() { "Gimmick", "Face", "噛みつき禁止" },
                    0
                );
        }

        // internal override void ChangeObj(params string[] delPath)
        // {
        //     if (nadeFlg)
        //         avatarRoot.Find("Advanced/Gimmick2/Face2").gameObject.SetActive(true);

        //     if (kamitukiFlg)
        //         avatarRoot.Find("Advanced/Gimmick2/3").gameObject.SetActive(true);
        // }
    }
}
