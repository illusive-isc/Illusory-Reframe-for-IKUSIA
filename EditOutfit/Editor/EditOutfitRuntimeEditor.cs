using System.Linq;
using UnityEditor;
using UnityEngine;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA {
	[CustomEditor(typeof(EditOutfitRuntime), true)]
	public class EditOutfitRuntimeEditor : Editor {
		private SerializedProperty convertTargetSMR;
		private SerializedProperty convertTargetPrefab;
		private Vector2 blendShapeScrollPosition = Vector2.zero;

		private void OnEnable() {
			convertTargetSMR = serializedObject.FindProperty("convertTargetSMR");
			convertTargetPrefab = serializedObject.FindProperty("convertTargetPrefab");
		}

		public override void OnInspectorGUI() {
			serializedObject.Update();

			EditOutfitRuntime targetScript = (EditOutfitRuntime)target;

			EditorGUILayout.LabelField("Edit Outfit Settings", EditorStyles.boldLabel);
			EditorGUILayout.Space();

			DrawDropArea();

			EditorGUILayout.Space();

			ConvertSMR(targetScript);
			ConvertPrefab(targetScript);
			serializedObject.ApplyModifiedProperties();
		}

		private void ConvertPrefab(EditOutfitRuntime targetScript) {
			var convertTargetPrefab = targetScript.convertTargetPrefab;
			if (targetScript.convertTargetPrefab != null) {
				EditorGUILayout.LabelField("Prefab Settings", EditorStyles.boldLabel);
				EditorGUILayout.Space();
				var actualType = targetScript.transform.GetComponent<ReframeRuntime>().GetType();
				if (targetScript.transform.GetComponent<ReframeRuntime>() != null)
					if (GUILayout.Button("Prefabのスケール調整を適用"))
						switch (actualType.Name) {
							case nameof(RuruneReframe):
								SetUpScale(convertTargetPrefab.transform,
								 	new string[] { "Armature", "Hips", "Spine", "Chest", "Neck" },
									0.95f, 1.01f);
								RenameObj(convertTargetPrefab.transform,
									"Armature/Hips/Spine/Chest/Shoulder_L/Upperarm_L/Lowerarm_L/LowerArm_twist_L", "Z_LowerArm_twist_L",
									"Armature/Hips/Spine/Chest/Shoulder_R/Upperarm_R/Lowerarm_R/LowerArm_twist_R", "Z_LowerArm_twist_R",
									"Armature/Hips/Upperleg_L/knees_L", "Z_knees_L",
									"Armature/Hips/Upperleg_R/knees_R", "Z_knees_R"
								);
								break;

							case nameof(MizukiReframe):
								SetUpScale(convertTargetPrefab.transform,
									new string[] { "Armature", "Hips", "Spine", "Chest", "Neck" },
									1.05f, 0.98f);
								RenameObj(convertTargetPrefab.transform,
									"Armature/Hips/Spine/Chest/Shoulder_L/Upperarm_L/Lowerarm_L/Z_LowerArm_twist_L", "LowerArm_twist_L",
									"Armature/Hips/Spine/Chest/Shoulder_R/Upperarm_R/Lowerarm_R/Z_LowerArm_twist_R", "LowerArm_twist_R",
									"Armature/Hips/Upperleg_L/Z_knees_L", "knees_L",
									"Armature/Hips/Upperleg_R/Z_knees_R", "knees_R"
								);
								break;

							default:
								break;
						}
			}
		}



		private static void RenameObj(Transform targetTransform, params string[] names) {
			var oldNamesPath = names.Where((name, index) => index % 2 == 0).ToArray();
			foreach (var oldNamePath in oldNamesPath) {

				var namePath = oldNamePath.Split("/");
				Transform currentTransform = targetTransform;
				var flg = true;
				foreach (var name in namePath)
					if (!GetArmatureTransformByName(currentTransform, name, out currentTransform))
						flg = false;
				if (flg)
					currentTransform.name = names.Where((name, index) => index % 2 == 1).ToArray()[oldNamesPath.ToList().IndexOf(oldNamePath)];
			}

		}
		private static void SetUpScale(Transform targetTransform, string[] path, float scale1, float scale2) {
			targetTransform.localScale = Vector3.one * scale1;
			Transform currentTransform = targetTransform;
			var flg = true;
			foreach (var name in path)
				if (!GetArmatureTransformByName(currentTransform, name, out currentTransform))
					flg = false;
			if (flg)
				currentTransform.localScale = Vector3.one * scale2;
		}

		private static bool GetArmatureTransformByName(
			Transform targetTransform,
			string name,
			out Transform resultTransform
		) {
			resultTransform = targetTransform
				.GetComponentsInChildren<Transform>(true)
				.FirstOrDefault(t =>
					t.name.StartsWith(name, System.StringComparison.OrdinalIgnoreCase)
				);
			return resultTransform != null;
		}

		private void ConvertSMR(EditOutfitRuntime targetScript) {
			if (
				targetScript.convertTargetSMR != null
				&& targetScript.convertTargetSMR.sharedMesh != null
			) {
				var mesh = targetScript.convertTargetSMR.sharedMesh;

				EditorGUILayout.LabelField($"複製したいBlendShapeを選択してください。", EditorStyles.boldLabel);

				if (mesh.blendShapeCount > 0) {
					// スクロール可能なエリアを作成
					EditorGUILayout.BeginVertical(EditorStyles.helpBox);

					EditorGUILayout.Space(5);
					blendShapeScrollPosition = EditorGUILayout.BeginScrollView(
						blendShapeScrollPosition,
						GUILayout.Height(200)
					);

					for (int i = 0; i < mesh.blendShapeCount; i++) {
						string key = $"EditOutfit_BlendShape_{mesh.name}_{i}";

						EditorGUILayout.BeginHorizontal(GUILayout.Height(EditorGUIUtility.singleLineHeight));

						bool isSelected = EditorPrefs.GetBool(key, false);
						bool newSelected = GUILayout.Toggle(isSelected, "", "Radio", GUILayout.Width(20));
						if (newSelected != isSelected && newSelected)
							for (int j = 0; j < mesh.blendShapeCount; j++)
								EditorPrefs.SetBool($"EditOutfit_BlendShape_{mesh.name}_{j}", j == i);

						EditorGUILayout.LabelField($"{i}: {mesh.GetBlendShapeName(i)}");
						EditorGUILayout.EndHorizontal();
						GUILayout.Space(2);
					}

					EditorGUILayout.EndScrollView();

					EditorGUILayout.EndVertical();

					// 選択されたBlendShapeがある場合のみ適用ボタンを表示
					string selectedBlendShapeName = GetSelectedBlendShapeName(mesh);
					if (!string.IsNullOrEmpty(selectedBlendShapeName)) {
						if (GUILayout.Button($"シェイプキーを複製して登録: {selectedBlendShapeName}")) {
							// 保存先のパスをダイアログで選択
							string defaultFileName = $"{mesh.name}_modified.asset";
							string savePath = EditorUtility.SaveFilePanel(
								"メッシュの保存先を選択",
								"Assets/IllusoryReframe",
								defaultFileName,
								"asset"
							);

							if (!string.IsNullOrEmpty(savePath)) {
								string relativePath = "Assets" + savePath[Application.dataPath.Length..];

								bool result = BaseAbstract.CreateDuplicateBSKey(
									targetScript.convertTargetSMR,
									selectedBlendShapeName,
									selectedBlendShapeName + "_plus",
									out Mesh newMesh,
									2.0f,
									selectedBlendShapeName + "_plus"
								);

								if (result) {
									// メッシュをアセットとして保存
									AssetDatabase.CreateAsset(newMesh, relativePath);
									AssetDatabase.SaveAssets();
									AssetDatabase.Refresh();

									// SkinnedMeshRendererに新しいメッシュを適用
									targetScript.convertTargetSMR.sharedMesh = newMesh;
									EditorUtility.SetDirty(targetScript.convertTargetSMR);

									Debug.Log(
										$"BlendShape '{selectedBlendShapeName}' を複製して '{selectedBlendShapeName}_plus' を作成しました。\n保存先: {relativePath}"
									);

									// プロジェクトウィンドウで作成されたアセットを選択
									EditorGUIUtility.PingObject(newMesh);
								}
							}
						}
					} else {
						EditorGUILayout.HelpBox("BlendShapeを選択してください。", MessageType.Warning);
					}
				} else
					EditorGUILayout.HelpBox("このメッシュにはBlendShapeがありません。", MessageType.Info);
			}
		}

		/// <summary>
		/// 選択されたBlendShapeのインデックスを取得（ラジオボタン用 - 単一選択）
		/// </summary>
		public static int GetSelectedBlendShapeIndex(Mesh mesh) {
			if (mesh == null)
				return -1;

			for (int i = 0; i < mesh.blendShapeCount; i++)
				if (EditorPrefs.GetBool($"EditOutfit_BlendShape_{mesh.name}_{i}", false))
					return i;
			return -1;
		}

		/// <summary>
		/// 選択されたBlendShape名を取得（ラジオボタン用 - 単一選択）
		/// </summary>
		public static string GetSelectedBlendShapeName(Mesh mesh) {
			if (mesh == null)
				return null;

			int selectedIndex = GetSelectedBlendShapeIndex(mesh);
			return selectedIndex >= 0 ? mesh.GetBlendShapeName(selectedIndex) : null;
		}

		/// <summary>
		/// 互換性のため残す - 選択されたBlendShapeのインデックス配列を取得
		/// </summary>
		public static int[] GetSelectedBlendShapeIndices(Mesh mesh) {
			int selectedIndex = GetSelectedBlendShapeIndex(mesh);
			return selectedIndex >= 0 ? new int[] { selectedIndex } : new int[0];
		}

		/// <summary>
		/// 互換性のため残す - 選択されたBlendShape名の配列を取得
		/// </summary>
		public static string[] GetSelectedBlendShapeNames(Mesh mesh) {
			string selectedName = GetSelectedBlendShapeName(mesh);
			return selectedName != null ? new string[] { selectedName } : new string[0];
		}

		private void DrawDropArea() {
			Rect dropArea = GUILayoutUtility.GetRect(0f, 60f, GUILayout.ExpandWidth(true));

			Color originalColor = GUI.backgroundColor;
			GUI.backgroundColor = new Color(0.8f, 0.9f, 1.0f, 1.0f);

			GUI.Box(dropArea, "", EditorStyles.helpBox);
			GUI.backgroundColor = originalColor;

			GUI.enabled = false;
			EditorGUI.PropertyField(
				new(
					dropArea.x + 10,
					dropArea.y,
					dropArea.width - 20,
					EditorGUIUtility.singleLineHeight * 1.5f
				),
				convertTargetSMR.objectReferenceValue == null
					? convertTargetPrefab
					: convertTargetSMR,
				GUIContent.none,
				true
			);
			GUI.enabled = true;

			Event currentEvent = Event.current;

			switch (currentEvent.type) {
				case EventType.DragUpdated:
				case EventType.DragPerform:
					if (!dropArea.Contains(currentEvent.mousePosition))
						break;

					bool canAccept = false;
					GameObject targetPrefab = null;
					SkinnedMeshRenderer targetRenderer = null;

					foreach (Object draggedObject in DragAndDrop.objectReferences) {
						if (draggedObject is GameObject gameObject) {
							if (gameObject.TryGetComponent<SkinnedMeshRenderer>(out var smr)) {
								canAccept = true;
								targetRenderer = smr;
								break;
							} else {
								canAccept = true;
								targetPrefab = gameObject;
								break;
							}
						} else if (draggedObject is SkinnedMeshRenderer renderer) {
							canAccept = true;
							targetRenderer = renderer;
							break;
						}
					}

					if (canAccept) {
						DragAndDrop.visualMode = DragAndDropVisualMode.Copy;

						if (currentEvent.type == EventType.DragPerform) {
							DragAndDrop.AcceptDrag();

							convertTargetPrefab.objectReferenceValue = targetPrefab;

							convertTargetSMR.objectReferenceValue = targetRenderer;

							serializedObject.ApplyModifiedProperties();
							Repaint();
						}
					} else
						DragAndDrop.visualMode = DragAndDropVisualMode.Rejected;

					currentEvent.Use();
					break;
			}
		}
	}
}
