using UnityEngine;
using VRC.Dynamics;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA.Rurune
{
    public partial class ReframeExe : ExeAbstract
    {
        protected override void Edit4Quest(Transform avatarRoot)
        {
            var RuruneTarget = target as RuruneReframe;
            if (RuruneTarget.questFlg1)
            {
                var AFK_World = avatarRoot.Find("Advanced/AFK_World/position");

                BaseAbstract.DestroyObj(AFK_World.Find("water2"));
                BaseAbstract.DestroyObj(AFK_World.Find("water3"));
                BaseAbstract.DestroyObj(AFK_World.Find("AFKIN Particle"));
                BaseAbstract.DestroyObj(AFK_World.Find("swim"));
                BaseAbstract.DestroyObj(AFK_World.Find("IdolParticle"));
                if (RuruneTarget.Breast)
                {
                    DelPBByPathArray(
                        avatarRoot,
                        "Armature/Hips/Spine/Chest/Breast_L",
                        "Armature/Hips/Spine/Chest/Breast_R"
                    );
                }
                if (RuruneTarget.tail_044)
                {
                    DelPBByPathArray(avatarRoot, "Armature/Hips/tail/tail.044");
                }

                if (RuruneTarget.head_collider2)
                {
                    DelColliderSettingByPathArray(
                        avatarRoot,
                        new string[] { "head_collider" },
                        "Armature/Hips/tail/tail.044"
                    );
                }
                if (RuruneTarget.chest_collider2)
                {
                    DelColliderSettingByPathArray(
                        avatarRoot,
                        new string[] { "chest_collider" },
                        "Armature/Hips/tail/tail.044"
                    );
                }
                if (RuruneTarget.upperleg_collider3)
                {
                    DelColliderSettingByPathArray(
                        avatarRoot,
                        new string[] { "upperleg_L_collider", "upperleg_R_collider" },
                        "Armature/Hips/tail/tail.044"
                    );
                }

                if (RuruneTarget.plane_tail_collider)
                {
                    DelColliderSettingByPathArray(
                        avatarRoot,
                        new string[] { "plane_tail_collider" },
                        "Armature/Hips/tail/tail.044"
                    );
                    BaseAbstract.DestroyComponent<VRCPhysBoneColliderBase>(
                        avatarRoot.Find("Armature/plane_tail_collider")
                    );
                }

                if (RuruneTarget.tail_022)
                {
                    DelPBByPathArray(
                        avatarRoot,
                        "Armature/Hips/tail/tail.044/tail.001/tail.002/tail.003/tail.004/tail.005/tail.006/tail.007/tail.008/tail.009/tail.010/tail.011/tail.012/tail.013/tail.014/tail.018/tail.021/tail.022"
                    );

                    DelPBByPathArray(
                        avatarRoot,
                        "Armature/Hips/tail/tail.044/tail.001/tail.002/tail.003/tail.004/tail.005/tail.006/tail.007/tail.008/tail.009/tail.010/tail.011/tail.012/tail.013/tail.014/tail.018/tail.021/tail.024"
                    );
                }
                if (RuruneTarget.Skirt_Root)
                    DelPBByPathArray(
                        avatarRoot,
                        "Armature/Hips/Skirt_Root/Skirt_Root_L",
                        "Armature/Hips/Skirt_Root/Skirt_Root_R"
                    );
                if (RuruneTarget.upperleg_collider2)
                    DelColliderSettingByPathArray(
                        avatarRoot,
                        new string[] { "upperleg_L_collider", "upperleg_R_collider" },
                        "Armature/Hips/Skirt_Root/Skirt_Root_L",
                        "Armature/Hips/Skirt_Root/Skirt_Root_R"
                    );
                if (RuruneTarget.Head_002)
                {
                    DelPBByPathArray(
                        avatarRoot,
                        "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/Front_hair1_root/Head.002"
                    );
                }
                if (RuruneTarget.side_1_root)
                {
                    DelPBByPathArray(
                        avatarRoot,
                        "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/side_1_root"
                    );
                }
                if (RuruneTarget.sidehair)
                {
                    DelPBByPathArray(
                        avatarRoot,
                        "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/side_2_root/side_ani_L/sidehair_L.003"
                    );
                    DelPBByPathArray(
                        avatarRoot,
                        "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/side_2_root/side_ani_R/sidehair_R.003"
                    );
                }
                if (RuruneTarget.Front_hair2_root)
                {
                    DelPBByPathArray(
                        avatarRoot,
                        "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/Front_hair2_root"
                    );
                }
                if (RuruneTarget.side_3_root)
                {
                    DelPBByPathArray(
                        avatarRoot,
                        "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/side_3_root"
                    );
                }
                if (RuruneTarget.Side_root)
                {
                    DelPBByPathArray(
                        avatarRoot,
                        "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/Side_root"
                    );
                }
                if (RuruneTarget.backhair)
                {
                    DelPBByPathArray(
                        avatarRoot,
                        "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/back_hair_root/back_hair_root_L/backhair_L"
                    );

                    DelPBByPathArray(
                        avatarRoot,
                        "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/back_hair_root/back_hair_root_R/backhair_R"
                    );
                }
                if (RuruneTarget.plane_collider)
                {
                    DelColliderSettingByPathArray(
                        avatarRoot,
                        new string[] { "plane_collider" },
                        "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/back_hair_root/back_hair_root_L/backhair_L",
                        "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/back_hair_root/back_hair_root_R/backhair_R"
                    );
                    BaseAbstract.DestroyComponent<VRCPhysBoneColliderBase>(
                        avatarRoot.Find("Armature/plane_collider")
                    );
                }
                if (RuruneTarget.head_collider1)
                {
                    DelColliderSettingByPathArray(
                        avatarRoot,
                        new string[] { "head_collider" },
                        "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/back_hair_root/back_hair_root_L/backhair_L",
                        "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/back_hair_root/back_hair_root_R/backhair_R"
                    );
                }
                if (RuruneTarget.upperArm_collider)
                {
                    DelColliderSettingByPathArray(
                        avatarRoot,
                        new string[] { "upperArm_L_collider", "upperArm_R_collider" },
                        "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/back_hair_root/back_hair_root_L/backhair_L",
                        "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/back_hair_root/back_hair_root_R/backhair_R"
                    );
                    BaseAbstract.DestroyComponent<VRCPhysBoneColliderBase>(
                        avatarRoot.Find(
                            "Armature/Hips/Spine/Chest/Shoulder_L/Upperarm_L/upperArm_L_collider"
                        )
                    );
                    BaseAbstract.DestroyComponent<VRCPhysBoneColliderBase>(
                        avatarRoot.Find(
                            "Armature/Hips/Spine/Chest/Shoulder_R/Upperarm_R/upperArm_R_collider"
                        )
                    );
                }
                if (RuruneTarget.upperleg_collider1)
                {
                    DelColliderSettingByPathArray(
                        avatarRoot,
                        new string[] { "upperleg_L_collider", "upperleg_R_collider" },
                        "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/back_hair_root/back_hair_root_L/backhair_L",
                        "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/back_hair_root/back_hair_root_R/backhair_R"
                    );
                }
                if (RuruneTarget.chest_collider1)
                {
                    DelColliderSettingByPathArray(
                        avatarRoot,
                        new string[] { "chest_collider", "Upperarm_R" },
                        "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/back_hair_root/back_hair_root_R/backhair_R",
                        "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/back_hair_root/back_hair_root_L/backhair_L"
                    );
                }
                if (RuruneTarget.back_side_root)
                {
                    DelPBByPathArray(
                        avatarRoot,
                        "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/back_side_root"
                    );
                }
                if (RuruneTarget.hair_2)
                {
                    DelPBByPathArray(
                        avatarRoot,
                        "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/side_2_root/sidehair_L"
                    );

                    DelPBByPathArray(
                        avatarRoot,
                        "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/side_2_root/sidehair_R"
                    );
                }

                if (RuruneTarget.chest_collider1 && RuruneTarget.chest_collider2)
                    BaseAbstract.DestroyComponent<VRCPhysBoneColliderBase>(
                        avatarRoot.Find("Armature/Hips/Spine/Chest/chest_collider")
                    );

                if (
                    RuruneTarget.upperleg_collider1
                    && RuruneTarget.upperleg_collider2
                    && RuruneTarget.upperleg_collider3
                )
                {
                    BaseAbstract.DestroyComponent<VRCPhysBoneColliderBase>(
                        avatarRoot.Find("Armature/Hips/Upperleg_L/upperleg_L_collider")
                    );
                    BaseAbstract.DestroyComponent<VRCPhysBoneColliderBase>(
                        avatarRoot.Find("Armature/Hips/Upperleg_R/upperleg_R_collider")
                    );
                }

                if (RuruneTarget.head_collider1 && RuruneTarget.head_collider2)
                    BaseAbstract.DestroyComponent<VRCPhysBoneColliderBase>(
                        avatarRoot.Find("Armature/Hips/Spine/Chest/Neck/Head/head_collider")
                    );
                if (RuruneTarget.Breast_collider)
                {
                    BaseAbstract.DestroyComponent<VRCPhysBoneColliderBase>(
                        avatarRoot.Find("Armature/Hips/Spine/Chest/Breast_R")
                    );
                    BaseAbstract.DestroyComponent<VRCPhysBoneColliderBase>(
                        avatarRoot.Find("Armature/Hips/Spine/Chest/Breast_L")
                    );
                }
            }
            Remove4AAO(avatarRoot, RuruneTarget.AAORemoveFlg);
        }
    }
}
