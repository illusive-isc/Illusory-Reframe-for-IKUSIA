using UnityEngine;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA.Mizuki
{
    public partial class ReframeExe : ExeAbstract
    {
        protected override void Edit4Quest(Transform avatarRoot)
        {
            var mizukiTarget = target as MizukiReframe;
            if (mizukiTarget.questFlg1)
            {
                if (mizukiTarget.Butt)
                    DelPBByPathArray(avatarRoot, "Armature/Hips/Butt_L", "Armature/Hips/Butt_R");

                if (mizukiTarget.Skirt_Root)
                    DelPBByPathArray(
                        avatarRoot,
                        "Armature/Hips/Skirt_Root/Skirt_L.038",
                        "Armature/Hips/Skirt_Root/Skirt_Root_L",
                        "Armature/Hips/Skirt_Root/Skirt_Root_R"
                    );
                if (mizukiTarget.Upperleg_collider1)
                {
                    DelColliderSettingByPathArray(
                        avatarRoot,
                        new string[] { "Upperleg_L", "Upperleg_R" },
                        "Armature/Hips/Skirt_Root/Skirt_L.038",
                        "Armature/Hips/Skirt_Root/Skirt_Root_L",
                        "Armature/Hips/Skirt_Root/Skirt_Root_R"
                    );
                }
                if (mizukiTarget.Breast)
                    DelPBByPathArray(
                        avatarRoot,
                        "Armature/Hips/Spine/Chest/Breast_L",
                        "Armature/Hips/Spine/Chest/Breast_R"
                    );
                if (mizukiTarget.Shoulder_collider)
                {
                    DelColliderSettingByPathArray(
                        avatarRoot,
                        new string[] { "Shoulder_L", "Shoulder_R" },
                        "Armature/Hips/Spine/Chest/Breast_L",
                        "Armature/Hips/Spine/Chest/Breast_R"
                    );
                }
                if (mizukiTarget.UpperArm_collider1)
                {
                    DelColliderSettingByPathArray(
                        avatarRoot,
                        new string[] { "Upperarm_L", "Upperarm_R" },
                        "Armature/Hips/Spine/Chest/Breast_L",
                        "Armature/Hips/Spine/Chest/Breast_R"
                    );
                }
                if (mizukiTarget.Cheek)
                    DelPBByPathArray(
                        avatarRoot,
                        "Armature/Hips/Spine/Chest/Neck/Head/Cheek_L/Cheek_L.001",
                        "Armature/Hips/Spine/Chest/Neck/Head/Cheek_R/Cheek_R.001"
                    );
                if (mizukiTarget.ahoge)
                    DelPBByPathArray(
                        avatarRoot,
                        "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/ahoge"
                    );
                if (mizukiTarget.Backhair)
                    DelPBByPathArray(
                        avatarRoot,
                        "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/Backhair2_L",
                        "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/Backhair2_R",
                        "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/Backhair3_L",
                        "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/Backhair3_R",
                        "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/Backhair4_L",
                        "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/Backhair4_R",
                        "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/Backhair5",
                        "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/backhair7_L",
                        "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/backhair7_R",
                        "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/Backhair_R",
                        "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/Backhair_L"
                    );
                if (mizukiTarget.Chest_collider)
                {
                    DelColliderSettingByPathArray(
                        avatarRoot,
                        new string[] { "Chest" },
                        "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/Backhair2_L",
                        "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/Backhair2_R",
                        "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/Backhair3_L",
                        "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/Backhair3_R",
                        "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/Backhair4_L",
                        "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/Backhair4_R",
                        "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/Backhair5",
                        "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/backhair7_L",
                        "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/backhair7_R",
                        "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/Backhair_R",
                        "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/Backhair_L"
                    );
                }
                if (mizukiTarget.Butt_collider)
                {
                    DelColliderSettingByPathArray(
                        avatarRoot,
                        new string[] { "Hips" },
                        "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/Backhair2_L",
                        "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/Backhair2_R",
                        "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/Backhair3_L",
                        "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/Backhair3_R",
                        "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/Backhair4_L",
                        "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/Backhair4_R",
                        "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/Backhair5",
                        "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/backhair7_L",
                        "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/backhair7_R",
                        "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/Backhair_R",
                        "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/Backhair_L"
                    );
                }
                if (mizukiTarget.Front)
                    DelPBByPathArray(
                        avatarRoot,
                        "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/Front",
                        "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/Front1",
                        "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/Front2",
                        "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/Front_2"
                    );
                if (mizukiTarget.Frontside)
                    DelPBByPathArray(
                        avatarRoot,
                        "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/Frontside1_L",
                        "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/Frontside1_R",
                        "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/Frontside2_L",
                        "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/Frontside2_R"
                    );
                if (mizukiTarget.side)
                    DelPBByPathArray(
                        avatarRoot,
                        "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/side3_L",
                        "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/side3_L.001",
                        "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/side3_L.002",
                        "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/side3_R",
                        "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/side3_R.001",
                        "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/side3_R.002",
                        "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/side5_L",
                        "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/side5_R",
                        "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/side6_L",
                        "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/side6_R",
                        "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/side_Root_L",
                        "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/side_Root_R"
                    );
                if (mizukiTarget.headband_Root)
                    DelPBByPathArray(
                        avatarRoot,
                        "Armature/Hips/Spine/Chest/Neck/Head/headband_Root"
                    );
                if (mizukiTarget.tang)
                    DelPBByPathArray(avatarRoot, "Armature/Hips/Spine/Chest/Neck/Head/tang");
                if (mizukiTarget.TigerEar)
                    DelPBByPathArray(
                        avatarRoot,
                        "Armature/Hips/Spine/Chest/Neck/Head/TigerEar/L/ear.L",
                        "Armature/Hips/Spine/Chest/Neck/Head/TigerEar/R/ear.R"
                    );
                if (mizukiTarget.Shoulder_Ribbon)
                    DelPBByPathArray(
                        avatarRoot,
                        "Armature/Hips/Spine/Chest/Shoulder_L/Shoulder_Ribbon_FrontRoot_L",
                        "Armature/Hips/Spine/Chest/Shoulder_R/Shoulder_Ribbon_FrontRoot_R",
                        "Armature/Hips/Spine/Chest/Shoulder_Ribbon_BackRoot_L",
                        "Armature/Hips/Spine/Chest/Shoulder_Ribbon_BackRoot_R"
                    );
                if (mizukiTarget.UpperArm_collider2)
                {
                    DelColliderSettingByPathArray(
                        avatarRoot,
                        new string[] { "Upperarm_L", "Upperarm_R" },
                        "Armature/Hips/Spine/Chest/Shoulder_L/Shoulder_Ribbon_FrontRoot_L",
                        "Armature/Hips/Spine/Chest/Shoulder_R/Shoulder_Ribbon_FrontRoot_R",
                        "Armature/Hips/Spine/Chest/Shoulder_Ribbon_BackRoot_L",
                        "Armature/Hips/Spine/Chest/Shoulder_Ribbon_BackRoot_R"
                    );
                }
                if (mizukiTarget.coat_hand)
                    DelPBByPathArray(
                        avatarRoot,
                        "Armature/Hips/Spine/Chest/Shoulder_R/Upperarm_R/Lowerarm_R/Right Hand/coat_hand_root_R",
                        "Armature/Hips/Spine/Chest/Shoulder_L/Upperarm_L/Lowerarm_L/Left Hand/coat_hand_root_L"
                    );
                if (mizukiTarget.Hand_frills)
                    DelPBByPathArray(
                        avatarRoot,
                        "Armature/Hips/Spine/Chest/Shoulder_R/Upperarm_R/Lowerarm_R/Right Hand/Hand_frills_R",
                        "Armature/Hips/Spine/Chest/Shoulder_L/Upperarm_L/Lowerarm_L/Left Hand/Hand_frills_L"
                    );
                if (mizukiTarget.tail)
                    DelPBByPathArray(avatarRoot, "Armature/Hips/tail/tail.001");
                if (mizukiTarget.Upperleg_collider2)
                {
                    DelColliderSettingByPathArray(
                        avatarRoot,
                        new string[] { "Upperleg_L", "Upperleg_R" },
                        "Armature/Hips/tail/tail.001"
                    );
                }
                if (mizukiTarget.Leg_frills)
                    DelPBByPathArray(
                        avatarRoot,
                        "Armature/Hips/Upperleg_L/Lowerleg_L/Foot_L/Leg_frills_Root_L"
                    );

                if (mizukiTarget.Upperleg_collider2)
                {
                    DelColliderSettingByPathArray(
                        avatarRoot,
                        new string[] { "chest_collider" },
                        "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/back_hair_root/back_hair_root_R/backhair_R",
                        "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/back_hair_root/back_hair_root_L/backhair_L"
                    );
                }
                Remove4AAO(avatarRoot, mizukiTarget.AAORemoveFlg);
            }
        }
    }
}
