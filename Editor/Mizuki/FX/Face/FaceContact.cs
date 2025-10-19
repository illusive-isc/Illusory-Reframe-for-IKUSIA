using System.Collections.Generic;
using VRC.SDK3.Avatars.ScriptableObjects;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA.Mizuki
{
    internal class FaceContact : MizukiBase
    {
        public bool kamitukiFlg = false;
        public bool nadeFlg = false;

        internal override void InitializeFlags(ReframeAbstract reframe)
        {
            kamitukiFlg = ((MizukiReframe)reframe).kamitukiFlg;
            nadeFlg = ((MizukiReframe)reframe).nadeFlg;
        }

        internal override void DeleteFx(List<string> Layers)
        {
            if (nadeFlg)
                DeleteMenuButtonCtrl(new() { "NadeNade" });
            if (kamitukiFlg)
                DeleteMenuButtonCtrl(new() { "Gimmick2_5" });
        }

        internal override void DeleteFxBT(List<string> Parameters)
        {
            if (nadeFlg)
                base.DeleteFxBT(new() { "NadeNade" });
            if (kamitukiFlg)
                base.DeleteFxBT(new() { "Gimmick2_5" });
        }

        internal override void EditVRCExpressions(VRCExpressionsMenu menu, List<string> menuPath)
        {
            if (nadeFlg)
                RemoveMenuItemRecursivelyInternal(
                    menu,
                    new() { "Gimmick2", "Gesture_change", "NadeNade" },
                    0
                );
            if (kamitukiFlg)
                RemoveMenuItemRecursivelyInternal(menu, new() { "Gimmick2", "噛みつき禁止" }, 0);
        }

        internal override void ChangeObj(List<string> delPath)
        {
            if (nadeFlg)
                descriptor.transform.Find("Advanced/Gimmick2/Face2").gameObject.SetActive(true);

            if (kamitukiFlg)
                descriptor.transform.Find("Advanced/Gimmick2/3").gameObject.SetActive(true);
        }
    }
}
