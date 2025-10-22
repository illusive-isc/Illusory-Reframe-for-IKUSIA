using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA.Rurune
{
    internal partial class RuruneReframeEditor : ReframeEditor
    {
        bool questArea;

        SerializedProperty questFlg1;

        SerializedProperty Skirt_Root;
        SerializedProperty Breast;
        SerializedProperty backhair;
        SerializedProperty back_side_root;
        SerializedProperty Head_002;
        SerializedProperty Front_hair2_root;
        SerializedProperty side_1_root;
        SerializedProperty hair_2;
        SerializedProperty sidehair;
        SerializedProperty side_3_root;
        SerializedProperty Side_root;
        SerializedProperty tail_044;
        SerializedProperty tail_022;

        SerializedProperty chest_collider1;
        SerializedProperty chest_collider2;
        SerializedProperty upperleg_collider1;
        SerializedProperty upperleg_collider2;
        SerializedProperty upperleg_collider3;
        SerializedProperty upperArm_collider;
        SerializedProperty plane_collider;
        SerializedProperty head_collider1;
        SerializedProperty head_collider2;
        SerializedProperty Breast_collider;
        SerializedProperty plane_tail_collider;
        SerializedProperty particle_headphone;
        private int pbTCount = 207;
        private int pbCCount = 271;
        private int pbCount = 20;

        protected static readonly List<PhysBoneInfo> PhysBoneInfoList = new()
        {
            new()
            {
                name = "胸",
                flgName = "Breast",
                TransformCount = 6,
                ColliderCount = 0,
                PBCount = 2,
            },
            new()
            {
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
            new()
            {
                name = "尻尾リボン",
                autodeletePropName = "TailRibbonFlg",
                flgName = "tail_022",
                TransformCount = 10,
                ColliderCount = 0,
                PBCount = 2,
            },
            new()
            {
                name = "スカート",
                autodeletePropName = "HairFlg",
                flgName = "Skirt_Root",
                TransformCount = 42,
                ColliderCount = 60,
                titlesAndNames = new[] { ("脚干渉", "upperleg_collider2", 1f) },
                PBCount = 2,
            },
            new()
            {
                name = "前髪",
                autodeletePropName = "HairFlg",
                flgName = "Head_002",
                TransformCount = 4,
                ColliderCount = 0,
                PBCount = 1,
            },
            new()
            {
                name = "前髪小",
                autodeletePropName = "HairFlg",
                flgName = "side_1_root",
                TransformCount = 15,
                ColliderCount = 0,
                PBCount = 1,
            },
            new()
            {
                name = "横髪小",
                autodeletePropName = "HairFlg",
                flgName = "sidehair",
                TransformCount = 10,
                ColliderCount = 0,
                PBCount = 2,
            },
            new()
            {
                name = "ぱっつん前髪",
                autodeletePropName = "HairFlg",
                flgName = "Front_hair2_root",
                TransformCount = 10,
                ColliderCount = 0,
                PBCount = 1,
            },
            new()
            {
                name = "前髪サイド",
                autodeletePropName = "HairFlg",
                flgName = "side_3_root",
                TransformCount = 37,
                ColliderCount = 0,
                PBCount = 1,
            },
            new()
            {
                name = "サイド",
                autodeletePropName = "HairFlg",
                flgName = "Side_root",
                TransformCount = 13,
                ColliderCount = 20,
                titlesAndNames = new[] { ("胸部干渉", "Breast_collider", 1f) },
                PBCount = 1,
            },
            new()
            {
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
            new()
            {
                name = "後髪小",
                autodeletePropName = "HairFlg",
                flgName = "back_side_root",
                TransformCount = 9,
                ColliderCount = 0,
                PBCount = 1,
            },
            new()
            {
                name = "hair_2",
                autodeletePropName = "HairFlg40",
                flgName = "hair_2",
                TransformCount = 6,
                ColliderCount = 0,
                PBCount = 2,
            },
        };

        private void Quest()
        {
            questArea = EditorGUILayout.Foldout(questArea, "Quest用調整項目(素体のみ)", true);

            if (questArea)
            {
                QuestDialog(
                    target as ReframeRuntime,
                    questFlg1,
                    "Quest化に対応してないコンポーネントやシェーダーを使っているためTPS、透視、コライダー・ジャンプ、撮影ギミック、ライトガン、ホワイトブレス、8bit、ペン操作、ハートガンなどを削除します。\n"
                );

                if (questFlg1.boolValue)
                {
                    serializedObject.ApplyModifiedProperties();
                    serializedObject.Update();
                    serializedObject.Update();
                    PetFlg.boolValue = true;
                    TPSFlg.boolValue = true;
                    ClairvoyanceFlg.boolValue = true;
                    ColliderFlg.boolValue = true;
                    PictureFlg.boolValue = true;
                    LightGunFlg.boolValue = true;
                    WhiteBreathFlg.boolValue = true;
                    BubbleBreathFlg.boolValue = true;
                    WaterStampFlg.boolValue = true;
                    EightBitFlg.boolValue = true;
                    PenCtrlFlg.boolValue = true;
                    HeartGunFlg.boolValue = true;
                    HairFlg51.boolValue = true;
                    Zapu_nFlg.boolValue = false;
                    JointBallActiveFlg.boolValue = false;
                    StatusActiveFlg.boolValue = false;
                    serializedObject.ApplyModifiedProperties();
                }
                if (GUILayout.Button("おすすめ設定にする"))
                {
                    serializedObject.ApplyModifiedProperties();
                    serializedObject.Update();
                    Head_002.boolValue = false;
                    Front_hair2_root.boolValue = true;
                    side_3_root.boolValue = true;
                    Side_root.boolValue = false;
                    backhair.boolValue = false;
                    hair_2.boolValue = true;
                    Breast.boolValue = false;
                    side_1_root.boolValue = true;
                    sidehair.boolValue = true;
                    back_side_root.boolValue = true;
                    Skirt_Root.boolValue = true;
                    tail_022.boolValue = true;

                    upperleg_collider2.boolValue = true;
                    tail_044.boolValue = false;
                    head_collider2.boolValue = true;
                    chest_collider2.boolValue = false;
                    upperleg_collider3.boolValue = false;
                    plane_tail_collider.boolValue = true;
                    Breast_collider.boolValue = true;
                    plane_collider.boolValue = true;
                    head_collider1.boolValue = false;
                    upperArm_collider.boolValue = true;
                    upperleg_collider1.boolValue = true;
                    chest_collider1.boolValue = true;

                    serializedObject.ApplyModifiedProperties();
                }

                RenderProperty(PhysBoneInfoList);

                Count(PhysBoneInfoList, pbCount, pbTCount, pbCCount);
                DelMenu(textureResize, AAORemoveFlg);
            }
        }
    }
}
