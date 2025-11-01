using UnityEngine;
using VRC.Dynamics;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA.Ririka {
	public partial class ReframeExe : ExeAbstract {
		protected override void Edit4Quest(Transform avatarRoot) {
			// var RirikaTarget = target as RirikaReframe;
			// if (RirikaTarget.questFlg1)
			// {
			//     var AFK_World = avatarRoot.Find("Advanced/AFK_World/position");

			//     BaseAbstract.DestroyObj(AFK_World.Find("water2"));
			//     BaseAbstract.DestroyObj(AFK_World.Find("water3"));
			//     BaseAbstract.DestroyObj(AFK_World.Find("AFKIN Particle"));
			//     BaseAbstract.DestroyObj(AFK_World.Find("swim"));
			//     BaseAbstract.DestroyObj(AFK_World.Find("IdolParticle"));
			//     if (RirikaTarget.Breast)
			//     {
			//         DelPBByPathArray(
			//             avatarRoot,
			//             "Armature/Hips/Spine/Chest/Breast_L",
			//             "Armature/Hips/Spine/Chest/Breast_R"
			//         );
			//     }
			//     if (RirikaTarget.tail_044)
			//     {
			//         DelPBByPathArray(avatarRoot, "Armature/Hips/tail/tail.044");
			//     }

			//     if (RirikaTarget.head_collider2)
			//     {
			//         DelColliderSettingByPathArray(
			//             avatarRoot,
			//             new string[] { "head_collider" },
			//             "Armature/Hips/tail/tail.044"
			//         );
			//     }
			//     if (RirikaTarget.chest_collider2)
			//     {
			//         DelColliderSettingByPathArray(
			//             avatarRoot,
			//             new string[] { "chest_collider" },
			//             "Armature/Hips/tail/tail.044"
			//         );
			//     }
			//     if (RirikaTarget.upperleg_collider3)
			//     {
			//         DelColliderSettingByPathArray(
			//             avatarRoot,
			//             new string[] { "upperleg_L_collider", "upperleg_R_collider" },
			//             "Armature/Hips/tail/tail.044"
			//         );
			//     }

			//     if (RirikaTarget.plane_tail_collider)
			//     {
			//         DelColliderSettingByPathArray(
			//             avatarRoot,
			//             new string[] { "plane_tail_collider" },
			//             "Armature/Hips/tail/tail.044"
			//         );
			//         BaseAbstract.DestroyComponent<VRCPhysBoneColliderBase>(
			//             avatarRoot.Find("Armature/plane_tail_collider")
			//         );
			//     }

			//     if (RirikaTarget.tail_022)
			//     {
			//         DelPBByPathArray(
			//             avatarRoot,
			//             "Armature/Hips/tail/tail.044/tail.001/tail.002/tail.003/tail.004/tail.005/tail.006/tail.007/tail.008/tail.009/tail.010/tail.011/tail.012/tail.013/tail.014/tail.018/tail.021/tail.022"
			//         );

			//         DelPBByPathArray(
			//             avatarRoot,
			//             "Armature/Hips/tail/tail.044/tail.001/tail.002/tail.003/tail.004/tail.005/tail.006/tail.007/tail.008/tail.009/tail.010/tail.011/tail.012/tail.013/tail.014/tail.018/tail.021/tail.024"
			//         );
			//     }
			//     if (RirikaTarget.Skirt_Root)
			//         DelPBByPathArray(
			//             avatarRoot,
			//             "Armature/Hips/Skirt_Root/Skirt_Root_L",
			//             "Armature/Hips/Skirt_Root/Skirt_Root_R"
			//         );
			//     if (RirikaTarget.upperleg_collider2)
			//         DelColliderSettingByPathArray(
			//             avatarRoot,
			//             new string[] { "upperleg_L_collider", "upperleg_R_collider" },
			//             "Armature/Hips/Skirt_Root/Skirt_Root_L",
			//             "Armature/Hips/Skirt_Root/Skirt_Root_R"
			//         );
			//     if (RirikaTarget.Head_002)
			//     {
			//         DelPBByPathArray(
			//             avatarRoot,
			//             "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/Front_hair1_root/Head.002"
			//         );
			//     }
			//     if (RirikaTarget.side_1_root)
			//     {
			//         DelPBByPathArray(
			//             avatarRoot,
			//             "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/side_1_root"
			//         );
			//     }
			//     if (RirikaTarget.sidehair)
			//     {
			//         DelPBByPathArray(
			//             avatarRoot,
			//             "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/side_2_root/side_ani_L/sidehair_L.003"
			//         );
			//         DelPBByPathArray(
			//             avatarRoot,
			//             "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/side_2_root/side_ani_R/sidehair_R.003"
			//         );
			//     }
			//     if (RirikaTarget.Front_hair2_root)
			//     {
			//         DelPBByPathArray(
			//             avatarRoot,
			//             "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/Front_hair2_root"
			//         );
			//     }
			//     if (RirikaTarget.side_3_root)
			//     {
			//         DelPBByPathArray(
			//             avatarRoot,
			//             "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/side_3_root"
			//         );
			//     }
			//     if (RirikaTarget.Side_root)
			//     {
			//         DelPBByPathArray(
			//             avatarRoot,
			//             "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/Side_root"
			//         );
			//     }
			//     if (RirikaTarget.backhair)
			//     {
			//         DelPBByPathArray(
			//             avatarRoot,
			//             "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/back_hair_root/back_hair_root_L/backhair_L"
			//         );

			//         DelPBByPathArray(
			//             avatarRoot,
			//             "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/back_hair_root/back_hair_root_R/backhair_R"
			//         );
			//     }
			//     if (RirikaTarget.plane_collider)
			//     {
			//         DelColliderSettingByPathArray(
			//             avatarRoot,
			//             new string[] { "plane_collider" },
			//             "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/back_hair_root/back_hair_root_L/backhair_L",
			//             "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/back_hair_root/back_hair_root_R/backhair_R"
			//         );
			//         BaseAbstract.DestroyComponent<VRCPhysBoneColliderBase>(
			//             avatarRoot.Find("Armature/plane_collider")
			//         );
			//     }
			//     if (RirikaTarget.head_collider1)
			//     {
			//         DelColliderSettingByPathArray(
			//             avatarRoot,
			//             new string[] { "head_collider" },
			//             "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/back_hair_root/back_hair_root_L/backhair_L",
			//             "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/back_hair_root/back_hair_root_R/backhair_R"
			//         );
			//     }
			//     if (RirikaTarget.upperArm_collider)
			//     {
			//         DelColliderSettingByPathArray(
			//             avatarRoot,
			//             new string[] { "upperArm_L_collider", "upperArm_R_collider" },
			//             "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/back_hair_root/back_hair_root_L/backhair_L",
			//             "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/back_hair_root/back_hair_root_R/backhair_R"
			//         );
			//         BaseAbstract.DestroyComponent<VRCPhysBoneColliderBase>(
			//             avatarRoot.Find(
			//                 "Armature/Hips/Spine/Chest/Shoulder_L/Upperarm_L/upperArm_L_collider"
			//             )
			//         );
			//         BaseAbstract.DestroyComponent<VRCPhysBoneColliderBase>(
			//             avatarRoot.Find(
			//                 "Armature/Hips/Spine/Chest/Shoulder_R/Upperarm_R/upperArm_R_collider"
			//             )
			//         );
			//     }
			//     if (RirikaTarget.upperleg_collider1)
			//     {
			//         DelColliderSettingByPathArray(
			//             avatarRoot,
			//             new string[] { "upperleg_L_collider", "upperleg_R_collider" },
			//             "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/back_hair_root/back_hair_root_L/backhair_L",
			//             "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/back_hair_root/back_hair_root_R/backhair_R"
			//         );
			//     }
			//     if (RirikaTarget.chest_collider1)
			//     {
			//         DelColliderSettingByPathArray(
			//             avatarRoot,
			//             new string[] { "chest_collider", "Upperarm_R" },
			//             "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/back_hair_root/back_hair_root_R/backhair_R",
			//             "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/back_hair_root/back_hair_root_L/backhair_L"
			//         );
			//     }
			//     if (RirikaTarget.back_side_root)
			//     {
			//         DelPBByPathArray(
			//             avatarRoot,
			//             "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/back_side_root"
			//         );
			//     }
			//     if (RirikaTarget.hair_2)
			//     {
			//         DelPBByPathArray(
			//             avatarRoot,
			//             "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/side_2_root/sidehair_L"
			//         );

			//         DelPBByPathArray(
			//             avatarRoot,
			//             "Armature/Hips/Spine/Chest/Neck/Head/Hair_root/side_2_root/sidehair_R"
			//         );
			//     }

			//     if (RirikaTarget.chest_collider1 && RirikaTarget.chest_collider2)
			//         BaseAbstract.DestroyComponent<VRCPhysBoneColliderBase>(
			//             avatarRoot.Find("Armature/Hips/Spine/Chest/chest_collider")
			//         );

			//     if (
			//         RirikaTarget.upperleg_collider1
			//         && RirikaTarget.upperleg_collider2
			//         && RirikaTarget.upperleg_collider3
			//     )
			//     {
			//         BaseAbstract.DestroyComponent<VRCPhysBoneColliderBase>(
			//             avatarRoot.Find("Armature/Hips/Upperleg_L/upperleg_L_collider")
			//         );
			//         BaseAbstract.DestroyComponent<VRCPhysBoneColliderBase>(
			//             avatarRoot.Find("Armature/Hips/Upperleg_R/upperleg_R_collider")
			//         );
			//     }

			//     if (RirikaTarget.head_collider1 && RirikaTarget.head_collider2)
			//         BaseAbstract.DestroyComponent<VRCPhysBoneColliderBase>(
			//             avatarRoot.Find("Armature/Hips/Spine/Chest/Neck/Head/head_collider")
			//         );
			//     if (RirikaTarget.Breast_collider)
			//     {
			//         BaseAbstract.DestroyComponent<VRCPhysBoneColliderBase>(
			//             avatarRoot.Find("Armature/Hips/Spine/Chest/Breast_R")
			//         );
			//         BaseAbstract.DestroyComponent<VRCPhysBoneColliderBase>(
			//             avatarRoot.Find("Armature/Hips/Spine/Chest/Breast_L")
			//         );
			//     }
			// }
			// Remove4AAO(avatarRoot, RirikaTarget.AAORemoveFlg);
		}
	}
}
