using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA.Ririka {
	internal partial class RirikaReframeEditor : ReframeEditor {
		bool questArea;

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
		SerializedProperty ribbon;
		SerializedProperty frill;
		SerializedProperty bag;
		SerializedProperty nuigurumi;
		SerializedProperty long_hair;
		SerializedProperty tail;
		SerializedProperty bag_wing;
		SerializedProperty bag_ribbon;
		SerializedProperty Cloth;

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

		SerializedProperty upperleg_collider1;
		SerializedProperty upperleg_collider2;
		SerializedProperty upperleg_collider3;
		SerializedProperty plane_collider;
		private int pbTCount = 247;
		private int pbCCount = 394;
		private int pbCount = 28;

		protected static readonly List<PhysBoneInfo> PhysBoneInfoList = new() {
			new() {
				name = "ヒップ",
				flgName = "Butt",
				TransformCount = 4,
				ColliderCount = 0,
				PBCount = 2,
			},
			new() {
				name = "お腹",
				flgName = "stomach",
				TransformCount = 2,
				ColliderCount = 0,
				PBCount = 1,
			},
			new() {
				name = "胸",
				flgName = "Breast",
				TransformCount = 6,
				ColliderCount = 8,
				PBCount = 2,
				titlesAndNames = new[] { ("腕干渉", "upperArm_collider1", 1f) },
			},
			new() {
				name = "bob",
				autodeletePropName = "HairDelFlg",
				flgName = "bob",
				TransformCount = 27,
				ColliderCount = 34,
				PBCount = 1,
				titlesAndNames = new[] { ("腕干渉", "upperArm_collider2", 1f) },
			},
			new() {
				name = "bobtwin",
				autodeletePropName = "HairDelFlg",
				flgName = "bobtwin",
				TransformCount = 8,
				ColliderCount = 6,
				PBCount = 2,
				titlesAndNames = new[] { ("腕干渉", "upperArm_collider3", 1f) },
			},
			new() {
				name = "front_root",
				autodeletePropName = "HairDelFlg",
				flgName = "front_root",
				TransformCount = 13,
				ColliderCount = 0,
				PBCount = 1,
			},
			new() {
				name = "twintail",
				autodeletePropName = "HairDelFlg",
				flgName = "twintail",
				TransformCount = 9,
				ColliderCount = 6,
				PBCount = 1,
				titlesAndNames = new[] {
					("腕干渉", "upperArm_collider5", 2f),
					("胸部干渉", "chest_collider1", 1f)
				},
			},
			new() {
				name = "side_root",
				autodeletePropName = "HairDelFlg",
				flgName = "side_root",
				TransformCount = 11,
				ColliderCount = 16,
				PBCount = 1,
				titlesAndNames = new[] { ("腕干渉", "upperArm_collider4", 1f) },
			},
			new() {
				name = "long_hair",
				autodeletePropName = "HairDelFlg",
				flgName = "long_hair",
				TransformCount = 39,
				ColliderCount = 23,
				PBCount = 4,
				titlesAndNames = new[] {
					("腕干渉", "upperArm_collider6", 2.35f),
					("胸部干渉", "chest_collider2", 1f),
					("脚干渉", "upperleg_collider1", 2f),
					("お尻干渉", "hip_collider1", 1f),
				},
			},
			new() {
				name = "頭の羽",
				autodeletePropName = "AccessoryDelFlg",
				flgName = "acce_wing",
				TransformCount = 11,
				ColliderCount = 0,
				PBCount = 1,
			},
			new() {
				name = "イヤリング",
				autodeletePropName = "AccessoryDelFlg",
				flgName = "earring",
				TransformCount = 11,
				ColliderCount = 0,
				PBCount = 1,
			},
			new() {
				name = "レッグベルト",
				autodeletePropName = "AccessoryDelFlg",
				flgName = "Leg_acce",
				TransformCount = 2,
				ColliderCount = 0,
				PBCount = 1,
			},
			new() {
				name = "bag",
				autodeletePropName = "BagFlg",
				flgName = "bag",
				TransformCount = 3,
				ColliderCount = 0,
				PBCount = 1,
			},
			new() {
				name = "nuigurumi",
				autodeletePropName = "BagFlg",
				flgName = "nuigurumi",
				TransformCount = 4,
				ColliderCount = 0,
				PBCount = 1,
			},
			new() {
				name = "bag_wing",
				autodeletePropName = "BagFlg",
				flgName = "bag_wing",
				TransformCount = 14,
				ColliderCount = 0,
				PBCount = 2,
			},
			new() {
				name = "bag_ribbon",
				autodeletePropName = "BagFlg",
				flgName = "bag_ribbon",
				TransformCount = 6,
				ColliderCount = 0,
				PBCount = 2,
			},

			new() {
				name = "ribbon",
				autodeletePropName = "ClothFlg",
				flgName = "ribbon",
				TransformCount = 9,
				ColliderCount = 0,
				PBCount = 1,
			},
			new() {
				name = "frill",
				autodeletePropName = "ClothFlg",
				flgName = "frill",
				TransformCount = 4,
				ColliderCount = 2,
				PBCount = 1,
				titlesAndNames = new[] { ("腕干渉", "upperArm_collider7", 1f) },
			},
			new() {
				name = "スカート",
				autodeletePropName = "ClothFlg",
				flgName = "Cloth",
				TransformCount = 49,
				ColliderCount = 36,
				titlesAndNames = new[] {
					("脚干渉", "upperleg_collider2", 2f),
					("お尻干渉", "hip_collider2", 1f)
				},
				PBCount = 1,
			},
			new() {
				name = "tail",
				autodeletePropName = "TailFlg",
				flgName = "tail",
				TransformCount = 15,
				ColliderCount = 14,
				PBCount = 1,
				titlesAndNames = new[] {
					("地面干渉", "plane_collider", 1f),
					("脚干渉", "upperleg_collider3", 2f),
					("お尻干渉", "hip_collider3", 1f),
				},
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
				if (questFlg1.boolValue) {
					serializedObject.ApplyModifiedProperties();
					serializedObject.Update();
					TPSFlg.boolValue = true;
					TeppekiFlg.boolValue = true;
					ClairvoyanceFlg.boolValue = true;
					ColliderFlg.boolValue = true;
					BacklightFlg.boolValue = true;
					WhiteBreathFlg.boolValue = true;
					EightBitFlg.boolValue = true;
					PenCtrlFlg.boolValue = true;
					HeartGunFlg.boolValue = true;
					CandyFlg.boolValue = true;
					NeonFlg.boolValue = true;
					HairFlg.boolValue = true;
					HandheartFlg.boolValue = true;
					NoisepanelFlg.boolValue = true;
					PetFlg.boolValue = true;
					MesugakiFaceFlg.boolValue = true;
					PhoneFlg.boolValue = true;
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
					bob.boolValue = HairDelFlg.boolValue || !HairFlg5.boolValue;
					bobtwin.boolValue =
						HairDelFlg.boolValue || !(HairFlg3.boolValue && HairFlg5.boolValue);
					front_root.boolValue = true;
					side_root.boolValue = HairDelFlg.boolValue || HairFlg2.boolValue;
					twintail.boolValue = HairDelFlg.boolValue || !HairFlg7.boolValue;
					long_hair.boolValue = HairDelFlg.boolValue || !HairFlg4.boolValue;
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
