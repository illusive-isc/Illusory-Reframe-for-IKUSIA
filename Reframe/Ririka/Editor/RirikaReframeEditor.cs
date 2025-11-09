using System.Diagnostics;
using UnityEditor;
using UnityEngine;
using VRC.SDK3.Avatars.Components;
using Debug = UnityEngine.Debug;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA.Ririka {
	[CustomEditor(typeof(RirikaReframe))]
	internal partial class RirikaReframeEditor : ReframeEditor {
		public override void OnInspectorGUI() {
			serializedObject.Update();
			ExecuteMode();
			EditorGUILayout.PropertyField(maxParticleLimitFlg, new GUIContent("パーティクル上限制限"));
			GUILayout.BeginHorizontal();
			GUILayout.BeginVertical();
			EditorGUILayout.PropertyField(heelFlg1, new GUIContent("ヒールON"));
			EditorGUILayout.PropertyField(heelFlg2, new GUIContent("ハイヒールON"));
			if (AssetDatabase.LoadAssetAtPath<Object>(AssetDatabase.GUIDToAssetPath("1270af4956044a14db0b58aa4fd2832b")) == null)
				GUI.enabled = false;
			EditorGUILayout.PropertyField(colorFlg0, new GUIContent("(追加アセット) 2Pカラー置き換え"));
			EditorGUILayout.PropertyField(colorFlg1, new GUIContent("(追加アセット) 黒髪カラー置き換え"));
			EditorGUILayout.PropertyField(colorFlg2, new GUIContent("デフォルトカラー置き換え"));
			{
				var RirikaReframe = (RirikaReframe)target;
				if (colorFlg0.boolValue != RirikaReframe.colorFlg0
					|| colorFlg1.boolValue != RirikaReframe.colorFlg1) {
					colorFlg2.boolValue = false;
				} else if (colorFlg2.boolValue != RirikaReframe.colorFlg2) {
					colorFlg0.boolValue = false;
					colorFlg1.boolValue = false;
				}
			}
			GUI.enabled = true;
			EditorGUILayout.PropertyField(ClosetFlg, new GUIContent("衣装メニューのみ削除"));
			if (!ClosetFlg.boolValue) {
				GUI.enabled = false;
				ClothDelFlg.boolValue = false;
				OuterFlg.boolValue = false;
				BagFlg.boolValue = false;
				SleeveFlg.boolValue = false;
				TailFlg.boolValue = false;
				CoverArmFlg.boolValue = false;
				ClothFlg.boolValue = false;
				OverKneeSocksFlg.boolValue = false;
				BootsFlg.boolValue = false;
			}

			EditorGUILayout.PropertyField(OuterFlg, new GUIContent("  ├ アウター削除"));
			EditorGUILayout.PropertyField(BagFlg, new GUIContent("  ├ バッグ削除"));
			EditorGUILayout.PropertyField(SleeveFlg, new GUIContent("  ├ スリーブ削除"));
			EditorGUILayout.PropertyField(TailFlg, new GUIContent("  ├ 尻尾削除"));
			EditorGUILayout.PropertyField(CoverArmFlg, new GUIContent("  ├ アームカバー削除"));
			EditorGUILayout.PropertyField(ClothFlg, new GUIContent("  ├ 服削除"));
			EditorGUILayout.PropertyField(OverKneeSocksFlg, new GUIContent("  ├ ニーソックス削除"));
			EditorGUILayout.PropertyField(BootsFlg, new GUIContent("  ├ 靴削除"));
			EditorGUILayout.PropertyField(AnotherClothFlg, new GUIContent("  ├ 差分衣装追加"));
			EditorGUILayout.PropertyField(ClothDelFlg, new GUIContent("  └ デフォ衣装すべて削除"));
			if (!ClothDelFlg.boolValue) {
				GUI.enabled = false;
				BraFlg.boolValue = false;
			} else {
				OuterFlg.boolValue = true;
				BagFlg.boolValue = true;
				SleeveFlg.boolValue = true;
				TailFlg.boolValue = true;
				CoverArmFlg.boolValue = true;
				ClothFlg.boolValue = true;
				OverKneeSocksFlg.boolValue = true;
				BootsFlg.boolValue = true;
			}

			EditorGUILayout.PropertyField(BraFlg, new GUIContent("      └ 下着も削除"));
			GUI.enabled = true;

			EditorGUILayout.PropertyField(AccessoryFlg, new GUIContent("アクセメニューのみ削除"));
			if (!AccessoryFlg.boolValue) {
				GUI.enabled = false;
				AccessoryFlg1.boolValue = false;
				AccessoryFlg2.boolValue = false;
				AccessoryFlg3.boolValue = false;
				AccessoryFlg4.boolValue = false;
			}
			EditorGUILayout.PropertyField(AccessoryFlg1, new GUIContent("  │   ├ 髪留めON"));
			EditorGUILayout.PropertyField(AccessoryFlg5, new GUIContent("  │   ├ イヤリングON"));
			EditorGUILayout.PropertyField(AccessoryFlg2, new GUIContent("  │   ├ 頭羽ON"));
			EditorGUILayout.PropertyField(AccessoryFlg3, new GUIContent("  │   ├ チョーカーON"));
			EditorGUILayout.PropertyField(AccessoryFlg4, new GUIContent("  │   └ レッグベルトON"));
			EditorGUILayout.PropertyField(AccessoryDelFlg, new GUIContent("  └ アクセサリ削除"));
			GUI.enabled = true;
			if (AccessoryDelFlg.boolValue) {
				AccessoryFlg1.boolValue = false;
				AccessoryFlg2.boolValue = false;
				AccessoryFlg3.boolValue = false;
				AccessoryFlg4.boolValue = false;
				AccessoryFlg5.boolValue = false;
			}
			EditorGUILayout.PropertyField(HairFlg, new GUIContent("髪毛メニューのみ削除"));
			if (!HairFlg.boolValue) {
				GUI.enabled = false;
				HairFlg1.boolValue = false;
				HairFlg2.boolValue = false;
				HairDelFlg.boolValue = false;
			}
			EditorGUILayout.PropertyField(HairFlg1, new GUIContent("  │   ├ 前髪ショートON"));
			EditorGUILayout.PropertyField(HairFlg2, new GUIContent("  │   ├ 前髪サイドON"));
			EditorGUILayout.PropertyField(HairFlg3, new GUIContent("  │   └ ボブツインON"));
			EditorGUILayout.PropertyField(HairFlg4, new GUIContent("  ├ ロングON"));
			EditorGUILayout.PropertyField(HairFlg7, new GUIContent("  ├ ツインテON"));

			if (AssetDatabase.LoadAssetAtPath<Object>(
					AssetDatabase.GUIDToAssetPath("b0fb802c479d39448bd81534f28ae96c")) == null)
				GUI.enabled = false;
			EditorGUILayout.PropertyField(HairFlg8, new GUIContent("  ├ (追加アセット) ロングツインテON"));
			if (HairFlg.boolValue)
				GUI.enabled = true;
			EditorGUILayout.PropertyField(HairFlg5, new GUIContent("  ├ ボブON"));
			if (!HairFlg5.boolValue) {
				GUI.enabled = false;
				HairFlg6.boolValue = false;
			}
			EditorGUILayout.PropertyField(HairFlg6, new GUIContent("  │   └ ショートON"));
			if (HairFlg.boolValue)
				GUI.enabled = true;
			{
				var RirikaReframe = (RirikaReframe)target;
				if (HairFlg4.boolValue != RirikaReframe.HairFlg4) {
					HairFlg5.boolValue = false;
					HairFlg7.boolValue = false;
					HairFlg8.boolValue = false;
				} else if (HairFlg5.boolValue != RirikaReframe.HairFlg5) {
					HairFlg4.boolValue = false;
					HairFlg7.boolValue = false;
					HairFlg8.boolValue = false;
				} else if (HairFlg7.boolValue != RirikaReframe.HairFlg7) {
					HairFlg4.boolValue = false;
					HairFlg5.boolValue = false;
					HairFlg8.boolValue = false;
				} else if (HairFlg8.boolValue != RirikaReframe.HairFlg8) {
					HairFlg4.boolValue = false;
					HairFlg5.boolValue = false;
					HairFlg7.boolValue = false;
				}
			}
			EditorGUILayout.PropertyField(HairDelFlg, new GUIContent("  └ 髪毛削除"));
			GUI.enabled = true;
			EditorGUILayout.PropertyField(BreastSizeFlg, new GUIContent("バストサイズ変更削除"));
			if (!BreastSizeFlg.boolValue) {
				GUI.enabled = false;
				BreastSizeFlg1.boolValue = false;
			}
			EditorGUILayout.PropertyField(BreastSizeFlg1, new GUIContent("  └ BreastSize100にする"));
			GUI.enabled = true;
			GUILayout.EndVertical();
			GUILayout.BeginVertical();
			EditorGUILayout.PropertyField(CandyFlg, new GUIContent("飴削除"));
			EditorGUILayout.PropertyField(CanDrinkFlg, new GUIContent("ジュース削除"));
			EditorGUILayout.PropertyField(DoughnutFlg, new GUIContent("ドーナツ削除"));
			EditorGUILayout.PropertyField(GamFlg, new GUIContent("ガム削除"));
			EditorGUILayout.PropertyField(TeppekiFlg, new GUIContent("鉄壁削除"));
			EditorGUILayout.PropertyField(HandheartFlg, new GUIContent("ハンドハート削除"));
			EditorGUILayout.PropertyField(NoisepanelFlg, new GUIContent("容疑者風削除"));
			EditorGUILayout.PropertyField(NeonFlg, new GUIContent("neon削除"));
			EditorGUILayout.PropertyField(MesugakiFaceFlg, new GUIContent("メスガキフェイス削除"));
			EditorGUILayout.PropertyField(PetFlg, new GUIContent("Petギミック削除"));

			EditorGUILayout.PropertyField(TPSFlg, new GUIContent("TPS削除"));
			EditorGUILayout.PropertyField(ClairvoyanceFlg, new GUIContent("透視削除"));
			EditorGUILayout.PropertyField(PhoneFlg, new GUIContent("スマホギミック削除"));
			EditorGUILayout.PropertyField(ColliderFlg, new GUIContent("コライダー・ジャンプ削除"));

			EditorGUILayout.PropertyField(BacklightFlg, new GUIContent("backlight削除"));

			EditorGUILayout.PropertyField(WhiteBreathFlg, new GUIContent("ホワイトブレス削除"));
			EditorGUILayout.PropertyField(EightBitFlg, new GUIContent("8bit削除"));
			EditorGUILayout.PropertyField(PenCtrlFlg, new GUIContent("ペン操作削除"));
			EditorGUILayout.PropertyField(HeartGunFlg, new GUIContent("ハートガン削除"));
			EditorGUILayout.PropertyField(FaceGestureFlg2, new GUIContent("デフォルトの表情プリセット削除(faceEmoなど使う場合)"));
			EditorGUILayout.PropertyField(FaceLockFlg, new GUIContent("表情固定機能削除"));
			EditorGUILayout.PropertyField(FaceValFlg, new GUIContent("顔差分変更機能削除"));

			bool prevFaceGestureFlg =
				FaceLockFlg.boolValue || FaceValFlg.boolValue || FaceGestureFlg2.boolValue;
			if (FaceGestureFlg.boolValue != prevFaceGestureFlg)
				FaceGestureFlg.boolValue = prevFaceGestureFlg;

			EditorGUILayout.PropertyField(blinkFlg, new GUIContent("まばたきをメニューから削除して常にON"));
			EditorGUILayout.PropertyField(blinkDelFlg, new GUIContent("  └ まばたきを削除"));
			if (blinkDelFlg.boolValue)
				blinkFlg.boolValue = true;
			EditorGUILayout.PropertyField(nadeFlg, new GUIContent("なでギミックをメニューから削除して常にON"));
			EditorGUILayout.PropertyField(kamitukiFlg, new GUIContent("噛みつきをメニューから削除して常にON"));
			EditorGUILayout.PropertyField(IKUSIA_emote, new GUIContent("IKUSIA_emoteをメニューのみ削除"));
			EditorGUILayout.PropertyField(IKUSIA_emote2, new GUIContent("Hand Animatonをメニューのみ削除"));
			bool prevFaceContactFlg = kamitukiFlg.boolValue || nadeFlg.boolValue;
			if (FaceContactFlg.boolValue != prevFaceContactFlg)
				FaceContactFlg.boolValue = prevFaceContactFlg;
			if (!PetFlg.boolValue)
				EditorGUILayout.PropertyField(petScale, new GUIContent("Pet大きさ変更(試作機能)"));

			GUILayout.EndVertical();
			GUILayout.EndHorizontal();

			Quest();

			serializedObject.ApplyModifiedProperties();

			if (!ExecuteButton(target as RirikaReframe))
				return;
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
						Debug.LogWarning("変換に失敗しました。" + e);
					}
				} else {
					Debug.LogWarning("VRCAvatarDescriptor が見つかりません。");
				}
				step1.Stop();
				Debug.Log("RirikaReframe: " + step1.ElapsedMilliseconds + "ms");
				isExecuting = false;
			}

			return true;
		}

		[MenuItem("GameObject/illusive_tools/Create RirikaReframe Object", true)]
		private static bool ValidateCreateRirikaReframeObject(MenuCommand menuCommand) {
			return ValidateCreateObj(menuCommand, "ririkaAvatar");
		}

		[MenuItem("GameObject/illusive_tools/Create RirikaReframe Object", false, 10)]
		private static void CreateRirikaReframeObject(MenuCommand menuCommand) {
			CreateObj<RirikaReframe>(menuCommand, "RirikaReframe");
		}
	}
}
