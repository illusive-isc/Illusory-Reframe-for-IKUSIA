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
			EditorGUILayout.PropertyField(
				maxParticleLimitFlg,
				new GUIContent("パーティクル上限制限")
			);
			GUILayout.BeginHorizontal();
			GUILayout.BeginVertical();
			EditorGUILayout.PropertyField(heelFlg1, new GUIContent("ヒールON"));
			EditorGUILayout.PropertyField(heelFlg2, new GUIContent("ハイヒールON"));
			if (
				AssetDatabase.LoadAssetAtPath<Object>(
					AssetDatabase.GUIDToAssetPath("1270af4956044a14db0b58aa4fd2832b")
				) == null
			)
				GUI.enabled = false;
			EditorGUILayout.PropertyField(
				colorFlg0,
				new GUIContent("(追加アセット) 2Pカラー置き換え")
			);
			EditorGUILayout.PropertyField(
				colorFlg1,
				new GUIContent("(追加アセット) 黒髪カラー置き換え")
			);
			EditorGUILayout.PropertyField(colorFlg2, new GUIContent("デフォルトカラー置き換え"));
			{
				var RirikaReframe = (RirikaReframe)target;
				if (
					colorFlg0.boolValue != RirikaReframe.colorFlg0
					|| colorFlg1.boolValue != RirikaReframe.colorFlg1
				) {
					colorFlg2.boolValue = false;
				} else if (colorFlg2.boolValue != RirikaReframe.colorFlg2) {
					colorFlg0.boolValue = false;
					colorFlg1.boolValue = false;
				}
			}
			GUI.enabled = true;
			EditorGUILayout.PropertyField(ClothFlg0, new GUIContent("衣装メニューのみ削除"));
			if (!ClothFlg0.boolValue) {
				GUI.enabled = false;
				ClothFlg.boolValue = false;
				ClothFlg1.boolValue = false;
				ClothFlg2.boolValue = false;
				ClothFlg3.boolValue = false;
				ClothFlg4.boolValue = false;
				ClothFlg5.boolValue = false;
				ClothFlg6.boolValue = false;
				ClothFlg7.boolValue = false;
				ClothFlg8.boolValue = false;
			}

			EditorGUILayout.PropertyField(ClothFlg1, new GUIContent("  ├ アウター削除"));
			EditorGUILayout.PropertyField(ClothFlg2, new GUIContent("  ├ バッグ削除"));
			EditorGUILayout.PropertyField(ClothFlg3, new GUIContent("  ├ スリーブ削除"));
			EditorGUILayout.PropertyField(ClothFlg4, new GUIContent("  ├ 尻尾削除"));
			EditorGUILayout.PropertyField(ClothFlg5, new GUIContent("  ├ アームカバー削除"));
			EditorGUILayout.PropertyField(ClothFlg6, new GUIContent("  ├ 服削除"));
			EditorGUILayout.PropertyField(ClothFlg7, new GUIContent("  ├ ニーソックス削除"));
			EditorGUILayout.PropertyField(ClothFlg8, new GUIContent("  ├ 靴削除"));
			EditorGUILayout.PropertyField(ClothFlg10, new GUIContent("  ├ 差分衣装追加"));
			EditorGUILayout.PropertyField(ClothFlg, new GUIContent("  └ デフォ衣装すべて削除"));
			if (!ClothFlg.boolValue) {
				GUI.enabled = false;
				ClothFlg9.boolValue = false;
			} else {
				ClothFlg1.boolValue = true;
				ClothFlg2.boolValue = true;
				ClothFlg3.boolValue = true;
				ClothFlg4.boolValue = true;
				ClothFlg5.boolValue = true;
				ClothFlg6.boolValue = true;
				ClothFlg7.boolValue = true;
				ClothFlg8.boolValue = true;
			}

			EditorGUILayout.PropertyField(ClothFlg9, new GUIContent("      └ 下着も削除"));
			GUI.enabled = true;

			EditorGUILayout.PropertyField(AccessoryFlg0, new GUIContent("アクセメニューのみ削除"));
			if (!AccessoryFlg0.boolValue) {
				GUI.enabled = false;
				AccessoryFlg1.boolValue = false;
				AccessoryFlg2.boolValue = false;
				AccessoryFlg3.boolValue = false;
				AccessoryFlg4.boolValue = false;
			}
			EditorGUILayout.PropertyField(AccessoryFlg1, new GUIContent("  ├ 髪留めON"));
			EditorGUILayout.PropertyField(AccessoryFlg2, new GUIContent("  ├ 頭羽ON"));
			EditorGUILayout.PropertyField(AccessoryFlg3, new GUIContent("  ├ チョーカーON"));
			EditorGUILayout.PropertyField(AccessoryFlg4, new GUIContent("  └ レッグベルトON"));
			GUI.enabled = true;

			EditorGUILayout.PropertyField(HairFlg0, new GUIContent("髪毛メニューのみ削除"));
			if (!HairFlg0.boolValue) {
				GUI.enabled = false;
				HairFlg1.boolValue = false;
				HairFlg2.boolValue = false;
				HairFlg.boolValue = false;
			}
			EditorGUILayout.PropertyField(HairFlg1, new GUIContent("  │   ├ 前髪ショートON"));
			EditorGUILayout.PropertyField(HairFlg2, new GUIContent("  │   ├ 前髪サイドON"));
			EditorGUILayout.PropertyField(HairFlg3, new GUIContent("  │   └ ボブツインON"));
			EditorGUILayout.PropertyField(HairFlg4, new GUIContent("  ├ ロングON"));
			EditorGUILayout.PropertyField(HairFlg7, new GUIContent("  ├ ツインテON"));

			if (
				AssetDatabase.LoadAssetAtPath<Object>(
					AssetDatabase.GUIDToAssetPath("b0fb802c479d39448bd81534f28ae96c")
				) == null
			)
				GUI.enabled = false;
			EditorGUILayout.PropertyField(
				HairFlg8,
				new GUIContent("  ├ (追加アセット) ロングツインテON")
			);
			if (HairFlg0.boolValue)
				GUI.enabled = true;
			EditorGUILayout.PropertyField(HairFlg5, new GUIContent("  ├ ボブON"));
			if (!HairFlg5.boolValue) {
				GUI.enabled = false;
				HairFlg6.boolValue = false;
			}
			EditorGUILayout.PropertyField(HairFlg6, new GUIContent("  │   └ ショートON"));
			if (HairFlg0.boolValue)
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
			EditorGUILayout.PropertyField(HairFlg, new GUIContent("  └ 髪毛削除"));
			GUI.enabled = true;
			EditorGUILayout.PropertyField(BreastSizeFlg, new GUIContent("バストサイズ変更削除"));
			if (!BreastSizeFlg.boolValue) {
				GUI.enabled = false;
				BreastSizeFlg2.boolValue = false;
			}
			EditorGUILayout.PropertyField(
				BreastSizeFlg2,
				new GUIContent("  └ BreastSize100にする")
			);
			GUI.enabled = true;
			GUILayout.EndVertical();
			GUILayout.BeginVertical();
			EditorGUILayout.PropertyField(candyFlg, new GUIContent("飴削除"));
			EditorGUILayout.PropertyField(drinkFlg, new GUIContent("ジュース削除"));
			EditorGUILayout.PropertyField(doughnutFlg, new GUIContent("ドーナツ削除"));
			EditorGUILayout.PropertyField(gamFlg, new GUIContent("ガム削除"));
			EditorGUILayout.PropertyField(teppekiFlg, new GUIContent("鉄壁削除"));
			EditorGUILayout.PropertyField(handHeartFlg, new GUIContent("ハンドハート削除"));
			EditorGUILayout.PropertyField(noisepanelFlg, new GUIContent("容疑者風削除"));
			EditorGUILayout.PropertyField(neonFlg, new GUIContent("neon削除"));
			EditorGUILayout.PropertyField(mesugakiFaceFlg, new GUIContent("メスガキフェイス削除"));
			EditorGUILayout.PropertyField(
				mesugakiFaceFlg1,
				new GUIContent("  └ パーティクルのみ削除")
			);
			if (mesugakiFaceFlg.boolValue) {
				mesugakiFaceFlg1.boolValue = true;
			}
			EditorGUILayout.PropertyField(petFlg, new GUIContent("Petギミック削除"));

			EditorGUILayout.PropertyField(TPSFlg, new GUIContent("TPS削除"));
			EditorGUILayout.PropertyField(ClairvoyanceFlg, new GUIContent("透視削除"));
			EditorGUILayout.PropertyField(phoneFlg, new GUIContent("スマホギミック削除"));
			EditorGUILayout.PropertyField(
				phoneFlg1,
				new GUIContent("  └ ライトと撮影ギミック削除")
			);
			if (phoneFlg.boolValue) {
				phoneFlg1.boolValue = true;
			}
			EditorGUILayout.PropertyField(ColliderFlg, new GUIContent("コライダー・ジャンプ削除"));

			EditorGUILayout.PropertyField(backlightFlg, new GUIContent("backlight削除"));

			EditorGUILayout.PropertyField(WhiteBreathFlg, new GUIContent("ホワイトブレス削除"));
			EditorGUILayout.PropertyField(eightBitFlg, new GUIContent("8bit削除"));
			EditorGUILayout.PropertyField(PenCtrlFlg, new GUIContent("ペン操作削除"));
			EditorGUILayout.PropertyField(HeartGunFlg, new GUIContent("ハートガン削除"));
			// EditorGUILayout.PropertyField(
			//     FaceGestureFlg,
			//     new GUIContent("デフォルトの表情プリセット削除(faceEmoなど使う場合)")
			// );
			EditorGUILayout.PropertyField(FaceLockFlg, new GUIContent("FaceLock削除"));
			EditorGUILayout.PropertyField(FaceValFlg, new GUIContent("顔差分変更機能削除"));
			EditorGUILayout.PropertyField(
				blinkFlg,
				new GUIContent("まばたきをメニューから削除して常にON")
			);
			EditorGUILayout.PropertyField(
				nadeFlg,
				new GUIContent("なでギミックをメニューから削除して常にON")
			);
			EditorGUILayout.PropertyField(
				kamitukiFlg,
				new GUIContent("噛みつきをメニューから削除して常にON")
			);
			EditorGUILayout.PropertyField(
				IKUSIA_emote,
				new GUIContent("IKUSIA_emoteをメニューのみ削除")
			);
			if (!petFlg.boolValue)
				EditorGUILayout.PropertyField(petScale, new GUIContent("Pet大きさ変更(試作機能)"));

			GUILayout.EndVertical();
			GUILayout.EndHorizontal();

			// Quest();

			serializedObject.ApplyModifiedProperties();

			if (!ExecuteButton(target as RirikaReframe)) {
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
