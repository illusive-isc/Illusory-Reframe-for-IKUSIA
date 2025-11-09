using System.Diagnostics;
using UnityEditor;
using UnityEngine;
using VRC.SDK3.Avatars.Components;
using Debug = UnityEngine.Debug;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA.Rurune {
	[CustomEditor(typeof(RuruneReframe))]
	internal partial class RuruneReframeEditor : ReframeEditor {
		public override void OnInspectorGUI() {
			serializedObject.Update();
			ExecuteMode();
			GUILayout.BeginHorizontal();
			GUILayout.BeginVertical();
			EditorGUILayout.PropertyField(
				maxParticleLimitFlg,
				new GUIContent("パーティクル上限制限")
			);
			EditorGUILayout.PropertyField(heelFlg1, new GUIContent("ヒールON"));
			EditorGUILayout.PropertyField(heelFlg2, new GUIContent("ハイヒールON"));

			EditorGUILayout.PropertyField(ClosetFlg, new GUIContent("衣装メニューのみ削除"));
			if (!ClosetFlg.boolValue) {
				GUI.enabled =
					JacketFlg.boolValue =
					ClothFlg.boolValue =
					AcceFlg.boolValue =
					StringFlg.boolValue =
					GloveFlg.boolValue =
					SocksFlg.boolValue =
					BootsFlg.boolValue =
					UnderwearFlg.boolValue =
						false;
			}
			EditorGUILayout.PropertyField(JacketFlg, new GUIContent("  ├ ジャケット削除"));

			EditorGUILayout.PropertyField(ClothFlg, new GUIContent("  ├ シャツ＆スカート削除"));
			EditorGUILayout.PropertyField(AcceFlg, new GUIContent("  ├ アクセサリ削除"));
			EditorGUILayout.PropertyField(StringFlg, new GUIContent("  ├ string削除"));
			EditorGUILayout.PropertyField(GloveFlg, new GUIContent("  ├ グローブ削除"));
			EditorGUILayout.PropertyField(SocksFlg, new GUIContent("  ├ ソックス削除"));
			EditorGUILayout.PropertyField(BootsFlg, new GUIContent("  ├ 靴削除"));
			EditorGUILayout.PropertyField(ClosetDelFlg, new GUIContent("  └ 服全削除"));
			if (ClosetDelFlg.boolValue) {
				JacketFlg.boolValue = true;
				ClothFlg.boolValue = true;
				AcceFlg.boolValue = true;
				StringFlg.boolValue = true;
				GloveFlg.boolValue = true;
				SocksFlg.boolValue = true;
				BootsFlg.boolValue = true;
				UnderwearFlg.boolValue = true;
			}
			EditorGUILayout.PropertyField(UnderwearFlg, new GUIContent("      └ 下着削除"));
			GUI.enabled = true;

			EditorGUILayout.PropertyField(BreastSizeFlg, new GUIContent("バストサイズ変更削除"));
			if (!BreastSizeFlg.boolValue) {
				GUI.enabled = false;
				BreastSizeFlg1.boolValue = false;
				BreastSizeFlg2.boolValue = false;
				BreastSizeFlg3.boolValue = false;
			}
			EditorGUILayout.PropertyField(BreastSizeFlg1, new GUIContent("  ├ smallにする"));
			EditorGUILayout.PropertyField(BreastSizeFlg2, new GUIContent("  ├ 100にする"));
			EditorGUILayout.PropertyField(BreastSizeFlg3, new GUIContent("  └ 瑞希100にする"));
			GUI.enabled = true;
			{
				var reframe = (RuruneReframe)target;
				if (BreastSizeFlg1.boolValue != reframe.BreastSizeFlg1) {
					BreastSizeFlg2.boolValue = false;
					BreastSizeFlg3.boolValue = false;
				} else if (BreastSizeFlg2.boolValue != reframe.BreastSizeFlg2) {
					BreastSizeFlg1.boolValue = false;
					BreastSizeFlg3.boolValue = false;
				} else if (BreastSizeFlg3.boolValue != reframe.BreastSizeFlg3) {
					BreastSizeFlg1.boolValue = false;
					BreastSizeFlg2.boolValue = false;
				}
			}

			EditorGUILayout.PropertyField(
				HairFlg,
				new GUIContent("髪毛/ヘッドフォンをメニューから削除")
			);
			if (!HairFlg.boolValue)
				GUI.enabled =
					HairFlg10.boolValue =
					HairFlg11.boolValue =
					HairFlg20.boolValue =
					HairFlg12.boolValue =
					HairFlg30.boolValue =
					HairFlg60.boolValue =
					HairFlg50.boolValue =
					HairFlg51.boolValue =
					HairFlg40.boolValue =
						false;
			if (HairFlg60.boolValue)
				GUI.enabled =
					HairFlg10.boolValue =
					HairFlg11.boolValue =
					HairFlg20.boolValue =
					HairFlg12.boolValue =
					HairFlg30.boolValue =
						false;
			EditorGUILayout.PropertyField(HairFlg10, new GUIContent("  │   ├ ぱっつんON"));
			if (!HairFlg10.boolValue)
				GUI.enabled = HairFlg11.boolValue = false;
			EditorGUILayout.PropertyField(HairFlg11, new GUIContent("  │   │   └ ショートON"));
			if (HairFlg.boolValue && !HairFlg60.boolValue)
				GUI.enabled = true;
			EditorGUILayout.PropertyField(HairFlg20, new GUIContent("  │   ├ 前髪左分けON"));
			{
				var reframe = (RuruneReframe)target;
				if (HairFlg10.boolValue != reframe.HairFlg10)
					HairFlg20.boolValue = false;
				else if (HairFlg20.boolValue != reframe.HairFlg20)
					HairFlg10.boolValue = false;
			}

			EditorGUILayout.PropertyField(HairFlg22, new GUIContent("  │   ├ 髪留めON"));
			EditorGUILayout.PropertyField(HairFlg12, new GUIContent("  │   ├ 前髪サイドON"));
			EditorGUILayout.PropertyField(HairFlg30, new GUIContent("  │   └ サイドON"));
			if (HairFlg.boolValue)
				GUI.enabled = true;
			EditorGUILayout.PropertyField(HairFlg60, new GUIContent("  └ hair削除"));
			EditorGUILayout.PropertyField(HairFlg50, new GUIContent("      ├ ヘッドホン削除"));
			if (!HairFlg50.boolValue)
				GUI.enabled = HairFlg51.boolValue = false;
			EditorGUILayout.PropertyField(HairFlg51, new GUIContent("      │   └ particle削除"));
			if (HairFlg.boolValue)
				GUI.enabled = true;
			EditorGUILayout.PropertyField(HairFlg40, new GUIContent("      └ hair2削除"));
			GUI.enabled = true;
			EditorGUILayout.PropertyField(TailGizaFlg, new GUIContent("尻尾ぎざぎざ"));
			EditorGUILayout.PropertyField(TailDelFlg, new GUIContent("尻尾削除"));
			EditorGUILayout.PropertyField(TailRibbonFlg, new GUIContent("  └ リボン削除"));
			if (TailDelFlg.boolValue)
				TailRibbonFlg.boolValue = true;
			GUILayout.EndVertical();

			GUILayout.BeginVertical();
			EditorGUILayout.PropertyField(PetFlg, new GUIContent("ペット削除"));
			EditorGUILayout.PropertyField(TPSFlg, new GUIContent("TPS削除"));
			EditorGUILayout.PropertyField(ClairvoyanceFlg, new GUIContent("透視削除"));
			EditorGUILayout.PropertyField(ColliderFlg, new GUIContent("コライダー・ジャンプ削除"));
			EditorGUILayout.PropertyField(PictureFlg, new GUIContent("撮影ギミック削除"));
			{
				if (LightGunFlg.boolValue)
					GUI.enabled = false;
				int selected = lightGun.enumValueIndex;
				var prevLabelWidth = EditorGUIUtility.labelWidth;
				EditorGUIUtility.labelWidth = 200f;
				lightGun.enumValueIndex = EditorGUILayout.Popup(
					"ライトガン色変更",
					selected,
					new[]
					{
						"LightColor0",
						"LightColor1",
						"LightColor2",
						"LightColor3",
						"LightColor4",
						"LightColor5",
						"LightColor6",
						"LightColor7",
						"LightColor8",
						"LightColor9",
						"LightColor10",
					}
				);
				GUI.enabled = true;
				EditorGUIUtility.labelWidth = prevLabelWidth;
			}
			EditorGUILayout.PropertyField(LightGunFlg, new GUIContent("ライトガン削除"));
			LightGunColorFlg.boolValue = !LightGunFlg.boolValue;
			EditorGUILayout.PropertyField(WhiteBreathFlg, new GUIContent("ホワイトブレス削除"));
			EditorGUILayout.PropertyField(BubbleBreathFlg, new GUIContent("バブルブレス削除"));
			EditorGUILayout.PropertyField(WaterStampFlg, new GUIContent("ウォータースタンプ削除"));
			EditorGUILayout.PropertyField(EightBitFlg, new GUIContent("8bit削除"));
			{
				if (PenCtrlFlg.boolValue)
					GUI.enabled = false;
				int selected = PenColor1.enumValueIndex;
				var prevLabelWidth = EditorGUIUtility.labelWidth;
				EditorGUIUtility.labelWidth = 200f;
				PenColor1.enumValueIndex = EditorGUILayout.Popup(
					"ペン色１変更",
					selected,
					new[]
					{
						"PenColor1",
						"PenColor2",
						"PenColor3",
						"PenColor4",
						"PenColor5",
						"PenColor6",
						"PenColor7",
						"PenColor8",
						"PenColor9",
						"PenColor10",
						"PenColor11",
						"PenColor12",
						"PenColor13",
						"PenColor14",
						"PenColor15",
						"PenColor16",
						"PenColor17",
						"PenColor18",
					}
				);
				GUI.enabled = true;
				EditorGUIUtility.labelWidth = prevLabelWidth;
			}
			{
				if (PenCtrlFlg.boolValue)
					GUI.enabled = false;
				int selected = PenColor2.enumValueIndex;
				var prevLabelWidth = EditorGUIUtility.labelWidth;
				EditorGUIUtility.labelWidth = 200f;
				PenColor2.enumValueIndex = EditorGUILayout.Popup(
					"ペン色２変更",
					selected,
					new[]
					{
						"PenColor1",
						"PenColor2",
						"PenColor3",
						"PenColor4",
						"PenColor5",
						"PenColor6",
						"PenColor7",
						"PenColor8",
						"PenColor9",
						"PenColor10",
						"PenColor11",
						"PenColor12",
						"PenColor13",
						"PenColor14",
						"PenColor15",
						"PenColor16",
						"PenColor17",
						"PenColor18",
					}
				);
				GUI.enabled = true;
				EditorGUIUtility.labelWidth = prevLabelWidth;
			}

			EditorGUILayout.PropertyField(PenCtrlFlg, new GUIContent("ペン操作削除"));
			PenColorFlg.boolValue = !PenCtrlFlg.boolValue;
			EditorGUILayout.PropertyField(HeartGunFlg, new GUIContent("ハートガン削除"));
			EditorGUILayout.PropertyField(
				FaceGestureFlg2,
				new GUIContent("デフォルトの表情プリセット削除(faceEmoなど使う場合)")
			);
			EditorGUILayout.PropertyField(FaceLockFlg, new GUIContent("表情固定機能削除"));
			EditorGUILayout.PropertyField(FaceValFlg, new GUIContent("顔差分変更機能削除"));

			bool prevFaceGestureFlg =
				FaceLockFlg.boolValue || FaceValFlg.boolValue || FaceGestureFlg2.boolValue;
			if (FaceGestureFlg.boolValue != prevFaceGestureFlg)
				FaceGestureFlg.boolValue = prevFaceGestureFlg;

			EditorGUILayout.PropertyField(
				blinkFlg,
				new GUIContent("まばたきをメニューから削除して常にON")
			);
			EditorGUILayout.PropertyField(blinkDelFlg, new GUIContent("  └ まばたきを削除"));
			if (blinkDelFlg.boolValue)
				blinkFlg.boolValue = true;
			EditorGUILayout.PropertyField(
				nadeFlg,
				new GUIContent("なでギミックをメニューから削除して常にON")
			);
			EditorGUILayout.PropertyField(
				kamitukiFlg,
				new GUIContent("噛みつきをメニューから削除して常にON")
			);
			bool prevFaceContactFlg = kamitukiFlg.boolValue || nadeFlg.boolValue;
			if (FaceContactFlg.boolValue != prevFaceContactFlg)
				FaceContactFlg.boolValue = prevFaceContactFlg;
			EditorGUILayout.PropertyField(
				IKUSIA_emote,
				new GUIContent("IKUSIA_emoteをメニューのみ削除")
			);
			if (!IKUSIA_emote.boolValue) {
				GUI.enabled = IKUSIA_emote1.boolValue = false;
			}
			EditorGUILayout.PropertyField(IKUSIA_emote1, new GUIContent("  └ 手動のAFKは残す"));
			GUI.enabled = true;
			GUILayout.Space(10);
			if (AssetDatabase.GUIDToAssetPath("ec7fbd8af3a3d86498b65f757efa7283") != "")
				EditorGUILayout.PropertyField(Zapu_nFlg, new GUIContent("Zapu-n追加"));

#if NDMF_FOUND
			EditorGUILayout.PropertyField(JointBallActiveFlg, new GUIContent("JointBall追加"));
			EditorGUILayout.PropertyField(StatusActiveFlg, new GUIContent("Status追加"));
#else
            JointBallActiveFlg.boolValue = false;
            StatusActiveFlg.boolValue = false;
#endif
			GUILayout.EndVertical();
			GUILayout.EndHorizontal();

			Quest();

			serializedObject.ApplyModifiedProperties();

			if (!ExecuteButton(target as RuruneReframe)) {
				return;
			}
			EditData();
		}

		protected bool ExecuteButton<T>(T target)
			where T : ReframeRuntime {
			if (
				GUILayout.Button(
					target.executeMode == ReframeRuntime.ExecuteModeOption.NDMF
						? "選択したオブジェクトのみ削除（実行時にアニメーションを削除）"
						: "選択しギミックを削除"
				)
			) {
				if (isExecuting) {
					Debug.LogWarning("現在実行中です。しばらくお待ちください。");
					return false;
				}
				isExecuting = true;
				var step1 = Stopwatch.StartNew();
				if (target.transform.root.TryGetComponent(out VRCAvatarDescriptor descriptor)) {
					try {
						ReframeExe reframe = CreateInstance<ReframeExe>();
						reframe.SetTarget(target);
						reframe.Execute(descriptor);
					} catch (System.Exception e) {
						Debug.LogWarning("変換に失敗しました。" + e.Message);
					}
				} else {
					Debug.LogWarning("VRCAvatarDescriptor が見つかりません。");
				}
				step1.Stop();
				Debug.Log("RuruneReframe: " + step1.ElapsedMilliseconds + "ms");
				isExecuting = false;
			}

			return true;
		}

		[MenuItem("GameObject/illusive_tools/Create RuruneReframe Object", true)]
		private static bool ValidateCreateRuruneReframeObject(MenuCommand menuCommand) {
			return ValidateCreateObj(menuCommand, "ruruneAvatar");
		}

		[MenuItem("GameObject/illusive_tools/Create RuruneReframe Object", false, 10)]
		private static void CreateRuruneReframeObject(MenuCommand menuCommand) {
			CreateObj<RuruneReframe>(menuCommand, "RuruneReframe");
		}
	}
}
