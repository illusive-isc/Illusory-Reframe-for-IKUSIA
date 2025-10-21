using System.Collections.Generic;
using UnityEngine;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA.Rurune
{
    internal class BreastSize : Base
    {
        bool breastSizeFlg1,
            breastSizeFlg2,
            breastSizeFlg3;

        internal override List<string> GetParameters() => new() { "BreastSize" };

        internal override List<string> GetMenuPath() => new() { "Gimmick", "Breast_size" };

        internal override void InitializeFlags(ReframeRuntime reframe)
        {
            breastSizeFlg1 = ((RuruneReframe)reframe).BreastSizeFlg1;
            breastSizeFlg2 = ((RuruneReframe)reframe).BreastSizeFlg2;
            breastSizeFlg3 = ((RuruneReframe)reframe).BreastSizeFlg3;
        }

        internal override void ChangeObj(params string[] delPath)
        {
            SetBreastSizeWeights(
                "Body_b",
                "Breast_small_____胸_小",
                "Breast_big(limit)",
                "Breast_Big_____胸_大(mizuki)"
            );
            SetBreastSizeWeights("acce", "Breast_smal", "Breast_big(limit)");
            SetBreastSizeWeights("cloth", "Breast_small_____胸_小", "Breast_big(limit)");
            SetBreastSizeWeights("cloth", "Breast_small_____胸_小", "Breast_big(limit)");
            SetWeight(
                avatarRoot.Find("jacket"),
                "Breast_big(limit)",
                breastSizeFlg2 ? 100 : 0
            );
            SetWeight(
                avatarRoot.Find("jacket"),
                "Breast_big(limit)",
                breastSizeFlg3 ? 200 : 0
            );
            SetBreastSizeWeights(
                "underwear",
                "Retarget_Body_b_Breast_small_____胸_小",
                "Breast_big(limit)",
                "Breast_Big_____胸_大"
            );
        }

        private void SetBreastSizeWeights(
            string bodyPart,
            string breastSmall,
            string Limit,
            string Mizuki = ""
        )
        {
            SetWeight(avatarRoot.Find(bodyPart), breastSmall, breastSizeFlg1 ? 100 : 0);
            SetWeight(avatarRoot.Find(bodyPart), Limit, breastSizeFlg2 ? 100 : 0);
            if (Mizuki != "")
                SetWeight(avatarRoot.Find(bodyPart), Mizuki, breastSizeFlg3 ? 100 : 0);
            else
                SetWeight(avatarRoot.Find(bodyPart), Limit, breastSizeFlg3 ? 200 : 0);
        }
    }
}
