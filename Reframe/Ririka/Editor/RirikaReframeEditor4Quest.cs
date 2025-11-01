using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA.Ririka {
	internal partial class RirikaReframeEditor : ReframeEditor {
		bool questArea;

		SerializedProperty controller;
		SerializedProperty controllerDef;
		SerializedProperty Butt;
		SerializedProperty Breast;
		SerializedProperty acce_wing;
		SerializedProperty earring;
		SerializedProperty Leg_acce;
		SerializedProperty bob;
		SerializedProperty bobtwin;
		SerializedProperty front_root;
		SerializedProperty twintail;
		SerializedProperty stomach;
		SerializedProperty side_root;
		SerializedProperty frill;
		SerializedProperty ribbon;
		SerializedProperty bag;
		SerializedProperty nuigurumi;
		SerializedProperty long_hair;
		SerializedProperty Cloth;
		SerializedProperty tail;
		SerializedProperty bag_wing;
		SerializedProperty bag_ribbon;

		SerializedProperty upperArm_collider1;
		SerializedProperty upperArm_collider2;
		SerializedProperty upperArm_collider3;
		SerializedProperty upperArm_collider4;
		SerializedProperty upperArm_collider5;
		SerializedProperty upperArm_collider6;
		SerializedProperty upperArm_collider7;

		SerializedProperty chest_collider1;
		SerializedProperty chest_collider2;

		SerializedProperty hip_collider1;
		SerializedProperty hip_collider2;
		SerializedProperty hip_collider3;

		SerializedProperty plane_collider;
		SerializedProperty upperleg_collider1;
		SerializedProperty upperleg_collider2;
		SerializedProperty upperleg_collider3;
		private int pbTCount = 207;
		private int pbCCount = 271;
		private int pbCount = 20;

		protected static readonly List<PhysBoneInfo> PhysBoneInfoList = new() {
			new() {
				name = "胸",
				flgName = "Breast",
				TransformCount = 6,
				ColliderCount = 0,
				PBCount = 2,
			},
			new() {
				name = "尻尾",
				autodeletePropName = "TailDelFlg",
				flgName = "tail_044",
				TransformCount = 18,
				ColliderCount = 13,
				titlesAndNames = new[]
				{
					("頭の干渉", "head_collider2", 1f),
					("胸周りの干渉", "chest_collider2", 1f),
					("脚の干渉", "upperleg_collider3", 2f),
					("地面の干渉", "plane_tail_collider", 1f),
				},
				PBCount = 1,
			},
			new() {
				name = "尻尾リボン",
				autodeletePropName = "TailRibbonFlg",
				flgName = "tail_022",
				TransformCount = 10,
				ColliderCount = 0,
				PBCount = 2,
			},
			new() {
				name = "スカート",
				autodeletePropName = "HairFlg",
				flgName = "Skirt_Root",
				TransformCount = 42,
				ColliderCount = 60,
				titlesAndNames = new[] { ("脚干渉", "upperleg_collider2", 1f) },
				PBCount = 2,
			},
			new() {
				name = "前髪",
				autodeletePropName = "HairFlg",
				flgName = "Head_002",
				TransformCount = 4,
				ColliderCount = 0,
				PBCount = 1,
			},
			new() {
				name = "前髪小",
				autodeletePropName = "HairFlg",
				flgName = "side_1_root",
				TransformCount = 15,
				ColliderCount = 0,
				PBCount = 1,
			},
			new() {
				name = "横髪小",
				autodeletePropName = "HairFlg",
				flgName = "sidehair",
				TransformCount = 10,
				ColliderCount = 0,
				PBCount = 2,
			},
			new() {
				name = "ぱっつん前髪",
				autodeletePropName = "HairFlg",
				flgName = "Front_hair2_root",
				TransformCount = 10,
				ColliderCount = 0,
				PBCount = 1,
			},
			new() {
				name = "前髪サイド",
				autodeletePropName = "HairFlg",
				flgName = "side_3_root",
				TransformCount = 37,
				ColliderCount = 0,
				PBCount = 1,
			},
			new() {
				name = "サイド",
				autodeletePropName = "HairFlg",
				flgName = "Side_root",
				TransformCount = 13,
				ColliderCount = 20,
				titlesAndNames = new[] { ("胸部干渉", "Breast_collider", 1f) },
				PBCount = 1,
			},
			new() {
				name = "後ろ髪",
				autodeletePropName = "HairFlg",
				flgName = "backhair",
				TransformCount = 27,
				ColliderCount = 18,
				titlesAndNames = new[]
				{
					("地面の干渉", "plane_collider", 1f),
					("頭の干渉", "head_collider1", 1f),
					("腕の干渉", "upperArm_collider", 2f),
					("脚の干渉", "upperleg_collider1", 2f),
					("胸周りの干渉", "chest_collider1", 1f),
				},
				PBCount = 3,
			},
			new() {
				name = "後髪小",
				autodeletePropName = "HairFlg",
				flgName = "back_side_root",
				TransformCount = 9,
				ColliderCount = 0,
				PBCount = 1,
			},
			new() {
				name = "hair_2",
				autodeletePropName = "HairFlg40",
				flgName = "hair_2",
				TransformCount = 6,
				ColliderCount = 0,
				PBCount = 2,
			},
		};

		private void Quest() {
			questArea = EditorGUILayout.Foldout(questArea, "Quest用調整項目(素体のみ)", true);

			if (questArea) {
				QuestDialog(
					target as ReframeRuntime,
					questFlg1,
					"Quest化に対応してないコンポーネントやシェーダーを使っているためペット、TPS、透視、コライダー・ジャンプ、ホワイトブレス、8bit、ペン操作、ハートガンのparticle、AFKの演出の一部を削除します。\n"
				);

				EditorGUILayout.PropertyField(questFlg1, new GUIContent("quest用にギミックを削除"));

				if (questFlg1.boolValue) {
					serializedObject.ApplyModifiedProperties();
					serializedObject.Update();
					TPSFlg.boolValue = true;
					teppekiFlg.boolValue = true;
					mesugakiFaceFlg1.boolValue = true;
					ClairvoyanceFlg.boolValue = true;
					ColliderFlg.boolValue = true;
					backlightFlg.boolValue = true;
					WhiteBreathFlg.boolValue = true;
					eightBitFlg.boolValue = true;
					PenCtrlFlg.boolValue = true;
					HeartGunFlg.boolValue = true;
					candyFlg.boolValue = true;
					neonFlg.boolValue = true;
					HairFlg0.boolValue = true;
					handHeartFlg.boolValue = true;
					noisepanelFlg.boolValue = true;
					petFlg.boolValue = true;
					serializedObject.ApplyModifiedProperties();
				}
				if (GUILayout.Button("おすすめ設定にする")) {
					serializedObject.ApplyModifiedProperties();
					serializedObject.Update();
					Butt.boolValue = true;
					Breast.boolValue = false;
					stomach.boolValue = true;

					acce_wing.boolValue = true;
					earring.boolValue = true;
					Leg_acce.boolValue = true;
					bob.boolValue = HairFlg.boolValue || !HairFlg5.boolValue;
					bobtwin.boolValue =
						HairFlg.boolValue || !(HairFlg3.boolValue && HairFlg5.boolValue);
					front_root.boolValue = true;
					side_root.boolValue = HairFlg.boolValue || HairFlg2.boolValue;
					twintail.boolValue = HairFlg.boolValue || !HairFlg7.boolValue;
					long_hair.boolValue = HairFlg.boolValue || !HairFlg4.boolValue;
					Cloth.boolValue = true;
					ribbon.boolValue = true;
					frill.boolValue = true;
					tail.boolValue = false;

					bag.boolValue = true;
					nuigurumi.boolValue = true;
					bag_wing.boolValue = true;
					bag_ribbon.boolValue = true;

					upperArm_collider1.boolValue = true;
					upperArm_collider2.boolValue = true;
					upperArm_collider3.boolValue = true;
					upperArm_collider4.boolValue = true;
					upperArm_collider5.boolValue = true;
					upperArm_collider6.boolValue = true;
					upperArm_collider7.boolValue = true;

					chest_collider1.boolValue = false;
					chest_collider2.boolValue = false;

					hip_collider1.boolValue = false;
					hip_collider2.boolValue = false;
					hip_collider3.boolValue = false;

					upperleg_collider1.boolValue = true;
					upperleg_collider2.boolValue = true;
					upperleg_collider3.boolValue = true;

					plane_collider.boolValue = true;

					serializedObject.ApplyModifiedProperties();
				}

				RenderProperty(PhysBoneInfoList);

				Count(PhysBoneInfoList, pbCount, pbTCount, pbCCount);
				DelMenu(textureResize, AAORemoveFlg);
			}
		}
	}
}
