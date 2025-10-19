using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using VRC.SDK3.Avatars.Components;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA.Mizuki
{
    internal class BreastSize : MizukiBase
    {
        bool breastSizeFlg1,
            breastSizeFlg2,
            breastSizeFlg3;

        internal override List<string> GetParameters() => new() { "BreastSize" };

        internal override List<string> GetMenuPath() => new() { "Gimmick2", "Breast_size" };

        internal override void InitializeFlags(ReframeAbstract reframe)
        {
            breastSizeFlg1 = ((MizukiReframe)reframe).BreastSizeFlg1;
            breastSizeFlg2 = ((MizukiReframe)reframe).BreastSizeFlg2;
            breastSizeFlg3 = ((MizukiReframe)reframe).BreastSizeFlg3;
        }

        internal override void DeleteFx(List<string> Layers)
        {
            DeleteBarCtrlHandHit(GetParameters(), "BreastSize");
            DeleteBarCtrl("BarOff", "BarOpen", "BreastSize");
        }

        internal override void ChangeObj(List<string> delPath)
        {
            var Body_b = descriptor.transform.Find("Body_b");
            if (Body_b)
                if (Body_b.TryGetComponent<SkinnedMeshRenderer>(out var Body_bSMR))
                {
                    SetWeight(Body_bSMR, "Breast_small_____胸_小", breastSizeFlg1 ? 100 : 0);
                    SetWeight(Body_bSMR, "Breast_Big_____胸_大", breastSizeFlg2 ? 50 : 0);
                    SetWeight(Body_bSMR, "Breast_Big_____胸_大", breastSizeFlg3 ? 100 : 0);
                }
            var maid = descriptor.transform.Find("Maid");
            if (maid)
                if (maid.TryGetComponent<SkinnedMeshRenderer>(out var maidSMR))
                {
                    SetWeight(maidSMR, "Breast_small_____胸_小", breastSizeFlg1 ? 100 : 0);
                    SetWeight(
                        maidSMR,
                        "Breast_Big_____胸_大",
                        breastSizeFlg2 ? 50
                            : breastSizeFlg3 ? 100
                            : 0
                    );
                }
            var outer = descriptor.transform.Find("Outer");
            if (outer)
                if (outer.TryGetComponent<SkinnedMeshRenderer>(out var outerSMR))
                {
                    SetWeight(outerSMR, "Breast_small_____胸_小", breastSizeFlg1 ? 100 : 0);
                    SetWeight(
                        outerSMR,
                        "Breast_Big_____胸_大",
                        breastSizeFlg2 ? 50
                            : breastSizeFlg3 ? 100
                            : 0
                    );
                }
            var jacket = descriptor.transform.Find("jacket");
            if (jacket)
                if (jacket.TryGetComponent<SkinnedMeshRenderer>(out var jacketSMR))
                {
                    jacketSMR.SetBlendShapeWeight(
                        1,
                        breastSizeFlg2 ? 100
                            : breastSizeFlg3 ? 200
                            : 0
                    );
                }
        }
    }
}
