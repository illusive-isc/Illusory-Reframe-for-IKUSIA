using UnityEngine;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA.Rurune
{
    public partial class ReframeExe : ExeAbstract
    {
        protected override void Edit4Quest(Transform avatarRoot)
        {
            var RuruneTarget = target as RuruneReframe;
            if (RuruneTarget.questFlg1)
            {
                // if (RuruneTarget.Butt)
                //     DelPBByPathArray(descriptor, "Armature/Hips/Butt_L", "Armature/Hips/Butt_R");

                // if (RuruneTarget.Skirt_Root)
                //     DelPBByPathArray(
                //         descriptor,
                //         "Armature/Hips/Skirt_Root/Skirt_L.038",
                //         "Armature/Hips/Skirt_Root/Skirt_Root_L",
                //         "Armature/Hips/Skirt_Root/Skirt_Root_R"
                //     );
                // if (RuruneTarget.Upperleg_collider1)
                // {
                //     DelColliderSettingByPathArray(
                //         descriptor,
                //         new string[] { "Upperleg_L", "Upperleg_R" },
                //         "Armature/Hips/Skirt_Root/Skirt_L.038",
                //         "Armature/Hips/Skirt_Root/Skirt_Root_L",
                //         "Armature/Hips/Skirt_Root/Skirt_Root_R"
                //     );
                // }
                // if (RuruneTarget.Breast)
                //     DelPBByPathArray(
                //         descriptor,
                //         "Armature/Hips/Spine/Chest/Breast_L",
                //         "Armature/Hips/Spine/Chest/Breast_R"
                //     );
                // if (RuruneTarget.Shoulder_collider)
                // {
                //     DelColliderSettingByPathArray(
                //         descriptor,
                //         new string[] { "Shoulder_L", "Shoulder_R" },
                //         "Armature/Hips/Spine/Chest/Breast_L",
                //         "Armature/Hips/Spine/Chest/Breast_R"
                //     );
                // }
                // if (RuruneTarget.UpperArm_collider1)
                // {
                //     DelColliderSettingByPathArray(
                //         descriptor,
                //         new string[] { "Upperarm_L", "Upperarm_R" },
                //         "Armature/Hips/Spine/Chest/Breast_L",
                //         "Armature/Hips/Spine/Chest/Breast_R"
                //     );
                // }
                // if (RuruneTarget.Cheek)
                //     DelPBByPathArray(
                //         descriptor,
                //         "Armature/Hips/Spine/Chest/Neck/Head/Cheek_L/Cheek_L.001",
                //         "Armature/Hips/Spine/Chest/Neck/Head/Cheek_R/Cheek_R.001"
                //     );
                // if (RuruneTarget.ahoge)
                //     DelPBByPathArray(
                //         descriptor,
                //         "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/ahoge"
                //     );
                // if (RuruneTarget.Backhair)
                //     DelPBByPathArray(
                //         descriptor,
                //         "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/Backhair2_L",
                //         "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/Backhair2_R",
                //         "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/Backhair3_L",
                //         "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/Backhair3_R",
                //         "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/Backhair4_L",
                //         "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/Backhair4_R",
                //         "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/Backhair5",
                //         "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/backhair7_L",
                //         "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/backhair7_R",
                //         "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/Backhair_R",
                //         "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/Backhair_L"
                //     );
                // if (RuruneTarget.Chest_collider)
                // {
                //     DelColliderSettingByPathArray(
                //         descriptor,
                //         new string[] { "Chest" },
                //         "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/Backhair2_L",
                //         "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/Backhair2_R",
                //         "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/Backhair3_L",
                //         "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/Backhair3_R",
                //         "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/Backhair4_L",
                //         "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/Backhair4_R",
                //         "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/Backhair5",
                //         "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/backhair7_L",
                //         "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/backhair7_R",
                //         "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/Backhair_R",
                //         "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/Backhair_L"
                //     );
                // }
                // if (RuruneTarget.Butt_collider)
                // {
                //     DelColliderSettingByPathArray(
                //         descriptor,
                //         new string[] { "Hips" },
                //         "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/Backhair2_L",
                //         "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/Backhair2_R",
                //         "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/Backhair3_L",
                //         "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/Backhair3_R",
                //         "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/Backhair4_L",
                //         "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/Backhair4_R",
                //         "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/Backhair5",
                //         "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/backhair7_L",
                //         "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/backhair7_R",
                //         "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/Backhair_R",
                //         "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/Backhair_L"
                //     );
                // }
                // if (RuruneTarget.Front)
                //     DelPBByPathArray(
                //         descriptor,
                //         "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/Front",
                //         "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/Front1",
                //         "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/Front2",
                //         "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/Front_2"
                //     );
                // if (RuruneTarget.Frontside)
                //     DelPBByPathArray(
                //         descriptor,
                //         "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/Frontside1_L",
                //         "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/Frontside1_R",
                //         "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/Frontside2_L",
                //         "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/Frontside2_R"
                //     );
                // if (RuruneTarget.side)
                //     DelPBByPathArray(
                //         descriptor,
                //         "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/side3_L",
                //         "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/side3_L.001",
                //         "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/side3_L.002",
                //         "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/side3_R",
                //         "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/side3_R.001",
                //         "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/side3_R.002",
                //         "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/side5_L",
                //         "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/side5_R",
                //         "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/side6_L",
                //         "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/side6_R",
                //         "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/side_Root_L",
                //         "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/side_Root_R"
                //     );
                // if (RuruneTarget.headband_Root)
                //     DelPBByPathArray(
                //         descriptor,
                //         "Armature/Hips/Spine/Chest/Neck/Head/headband_Root"
                //     );
                // if (RuruneTarget.tang)
                //     DelPBByPathArray(descriptor, "Armature/Hips/Spine/Chest/Neck/Head/tang");
                // if (RuruneTarget.TigerEar)
                //     DelPBByPathArray(
                //         descriptor,
                //         "Armature/Hips/Spine/Chest/Neck/Head/TigerEar/L/ear.L",
                //         "Armature/Hips/Spine/Chest/Neck/Head/TigerEar/R/ear.R"
                //     );
                // if (RuruneTarget.Shoulder_Ribbon)
                //     DelPBByPathArray(
                //         descriptor,
                //         "Armature/Hips/Spine/Chest/Shoulder_L/Shoulder_Ribbon_FrontRoot_L",
                //         "Armature/Hips/Spine/Chest/Shoulder_R/Shoulder_Ribbon_FrontRoot_R",
                //         "Armature/Hips/Spine/Chest/Shoulder_Ribbon_BackRoot_L",
                //         "Armature/Hips/Spine/Chest/Shoulder_Ribbon_BackRoot_R"
                //     );
                // if (RuruneTarget.UpperArm_collider2)
                // {
                //     DelColliderSettingByPathArray(
                //         descriptor,
                //         new string[] { "Upperarm_L", "Upperarm_R" },
                //         "Armature/Hips/Spine/Chest/Shoulder_L/Shoulder_Ribbon_FrontRoot_L",
                //         "Armature/Hips/Spine/Chest/Shoulder_R/Shoulder_Ribbon_FrontRoot_R",
                //         "Armature/Hips/Spine/Chest/Shoulder_Ribbon_BackRoot_L",
                //         "Armature/Hips/Spine/Chest/Shoulder_Ribbon_BackRoot_R"
                //     );
                // }
                // if (RuruneTarget.coat_hand)
                //     DelPBByPathArray(
                //         descriptor,
                //         "Armature/Hips/Spine/Chest/Shoulder_R/Upperarm_R/Lowerarm_R/Right Hand/coat_hand_root_R",
                //         "Armature/Hips/Spine/Chest/Shoulder_L/Upperarm_L/Lowerarm_L/Left Hand/coat_hand_root_L"
                //     );
                // if (RuruneTarget.Hand_frills)
                //     DelPBByPathArray(
                //         descriptor,
                //         "Armature/Hips/Spine/Chest/Shoulder_R/Upperarm_R/Lowerarm_R/Right Hand/Hand_frills_R",
                //         "Armature/Hips/Spine/Chest/Shoulder_L/Upperarm_L/Lowerarm_L/Left Hand/Hand_frills_L"
                //     );
                // if (RuruneTarget.tail)
                //     DelPBByPathArray(descriptor, "Armature/Hips/tail/tail.001");
                // if (RuruneTarget.Upperleg_collider2)
                // {
                //     DelColliderSettingByPathArray(
                //         descriptor,
                //         new string[] { "Upperleg_L", "Upperleg_R" },
                //         "Armature/Hips/tail/tail.001"
                //     );
                // }
                // if (RuruneTarget.Leg_frills)
                //     DelPBByPathArray(
                //         descriptor,
                //         "Armature/Hips/Upperleg_L/Lowerleg_L/Foot_L/Leg_frills_Root_L"
                //     );

                // if (RuruneTarget.Upperleg_collider2)
                // {
                //     DelColliderSettingByPathArray(
                //         descriptor,
                //         new string[] { "chest_collider" },
                //         "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/back_hair_root/back_hair_root_R/backhair_R",
                //         "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/back_hair_root/back_hair_root_L/backhair_L"
                //     );
                // }
                Remove4AAO(avatarRoot, RuruneTarget.AAORemoveFlg);
            }
        }
    }
}
