using System.Linq;
using UnityEditor;
using UnityEngine;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA
{
    [CustomEditor(typeof(EditOutfitRuntime), true)]
    public class EditOutfitRuntimeEditor : Editor
    {
        private SerializedProperty convertTargetSMR;
        private SerializedProperty convertTargetPrefab;
        private Vector2 blendShapeScrollPosition = Vector2.zero;

        private void OnEnable()
        {
            convertTargetSMR = serializedObject.FindProperty("convertTargetSMR");
            convertTargetPrefab = serializedObject.FindProperty("convertTargetPrefab");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditOutfitRuntime targetScript = (EditOutfitRuntime)target;

            EditorGUILayout.LabelField("Edit Outfit Settings", EditorStyles.boldLabel);
            EditorGUILayout.Space();

            DrawDropArea();

            EditorGUILayout.Space();

            if (
                targetScript.convertTargetSMR != null
                && targetScript.convertTargetSMR.sharedMesh != null
            )
            {
                var mesh = targetScript.convertTargetSMR.sharedMesh;

                EditorGUILayout.LabelField(
                    $"複製したいBlendShapeを選択してください。",
                    EditorStyles.boldLabel
                );

                if (mesh.blendShapeCount > 0)
                {
                    // スクロール可能なエリアを作成
                    EditorGUILayout.BeginVertical(EditorStyles.helpBox);

                    EditorGUILayout.Space(5);
                    blendShapeScrollPosition = EditorGUILayout.BeginScrollView(
                        blendShapeScrollPosition,
                        GUILayout.Height(200)
                    );

                    for (int i = 0; i < mesh.blendShapeCount; i++)
                    {
                        string key = $"EditOutfit_BlendShape_{mesh.name}_{i}";

                        EditorGUILayout.BeginHorizontal(
                            GUILayout.Height(EditorGUIUtility.singleLineHeight)
                        );

                        bool isSelected = EditorPrefs.GetBool(key, false);
                        bool newSelected = GUILayout.Toggle(
                            isSelected,
                            "",
                            "Radio",
                            GUILayout.Width(20)
                        );
                        if (newSelected != isSelected && newSelected)
                        {
                            // 他のすべてのラジオボタンを解除
                            for (int j = 0; j < mesh.blendShapeCount; j++)
                                EditorPrefs.SetBool(
                                    $"EditOutfit_BlendShape_{mesh.name}_{j}",
                                    j == i
                                );
                        }

                        EditorGUILayout.LabelField($"{i}: {mesh.GetBlendShapeName(i)}");

                        EditorGUILayout.EndHorizontal();

                        GUILayout.Space(2);
                    }

                    EditorGUILayout.EndScrollView();

                    EditorGUILayout.EndVertical();

                    // 選択されたBlendShapeがある場合のみ適用ボタンを表示
                    string selectedBlendShapeName = GetSelectedBlendShapeName(mesh);
                    if (!string.IsNullOrEmpty(selectedBlendShapeName))
                    {
                        if (
                            GUILayout.Button(
                                $"シェイプキーを複製して登録: {selectedBlendShapeName}"
                            )
                        )
                        {
                            // 保存先のパスをダイアログで選択
                            string defaultFileName = $"{mesh.name}_modified.asset";
                            string savePath = EditorUtility.SaveFilePanel(
                                "メッシュの保存先を選択",
                                "Assets/IllusoryReframe/Rurune",
                                defaultFileName,
                                "asset"
                            );

                            if (!string.IsNullOrEmpty(savePath))
                            {
                                // プロジェクトの相対パスに変換
                                string relativePath =
                                    "Assets" + savePath[Application.dataPath.Length..];

                                bool result = BaseAbstract.CreateDuplicateBSKey(
                                    targetScript.convertTargetSMR,
                                    selectedBlendShapeName,
                                    selectedBlendShapeName + "_plus",
                                    out Mesh newMesh,
                                    2.0f,
                                    selectedBlendShapeName + "_plus"
                                );

                                if (result)
                                {
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
                    }
                    else
                    {
                        EditorGUILayout.HelpBox(
                            "BlendShapeを選択してください。",
                            MessageType.Warning
                        );
                    }
                }
                else
                    EditorGUILayout.HelpBox(
                        "このメッシュにはBlendShapeがありません。",
                        MessageType.Info
                    );
            }
            serializedObject.ApplyModifiedProperties();
        }

        /// <summary>
        /// 選択されたBlendShapeのインデックスを取得（ラジオボタン用 - 単一選択）
        /// </summary>
        public static int GetSelectedBlendShapeIndex(Mesh mesh)
        {
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
        public static string GetSelectedBlendShapeName(Mesh mesh)
        {
            if (mesh == null)
                return null;

            int selectedIndex = GetSelectedBlendShapeIndex(mesh);
            return selectedIndex >= 0 ? mesh.GetBlendShapeName(selectedIndex) : null;
        }

        /// <summary>
        /// 互換性のため残す - 選択されたBlendShapeのインデックス配列を取得
        /// </summary>
        public static int[] GetSelectedBlendShapeIndices(Mesh mesh)
        {
            int selectedIndex = GetSelectedBlendShapeIndex(mesh);
            return selectedIndex >= 0 ? new int[] { selectedIndex } : new int[0];
        }

        /// <summary>
        /// 互換性のため残す - 選択されたBlendShape名の配列を取得
        /// </summary>
        public static string[] GetSelectedBlendShapeNames(Mesh mesh)
        {
            string selectedName = GetSelectedBlendShapeName(mesh);
            return selectedName != null ? new string[] { selectedName } : new string[0];
        }

        private void DrawDropArea()
        {
            Rect dropArea = GUILayoutUtility.GetRect(0f, 60f, GUILayout.ExpandWidth(true));

            Color originalColor = GUI.backgroundColor;
            GUI.backgroundColor = new Color(0.8f, 0.9f, 1.0f, 1.0f);

            GUI.Box(dropArea, "", EditorStyles.helpBox);
            GUI.backgroundColor = originalColor;

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

            Event currentEvent = Event.current;

            switch (currentEvent.type)
            {
                case EventType.DragUpdated:
                case EventType.DragPerform:
                    if (!dropArea.Contains(currentEvent.mousePosition))
                        break;

                    bool canAccept = false;
                    GameObject targetPrefab = null;
                    SkinnedMeshRenderer targetRenderer = null;

                    foreach (Object draggedObject in DragAndDrop.objectReferences)
                    {
                        if (draggedObject is GameObject gameObject)
                        {
                            if (IsOutfitPrefab(gameObject))
                            {
                                canAccept = true;
                                targetPrefab = gameObject;
                                break;
                            }
                            else if (gameObject.TryGetComponent<SkinnedMeshRenderer>(out var smr))
                            {
                                canAccept = true;
                                targetRenderer = smr;
                                break;
                            }
                        }
                        else if (draggedObject is SkinnedMeshRenderer renderer)
                        {
                            canAccept = true;
                            targetRenderer = renderer;
                            break;
                        }
                    }

                    if (canAccept)
                    {
                        DragAndDrop.visualMode = DragAndDropVisualMode.Copy;

                        if (currentEvent.type == EventType.DragPerform)
                        {
                            DragAndDrop.AcceptDrag();

                            convertTargetPrefab.objectReferenceValue = targetPrefab;

                            convertTargetSMR.objectReferenceValue = targetRenderer;

                            serializedObject.ApplyModifiedProperties();
                            Repaint();
                        }
                    }
                    else
                        DragAndDrop.visualMode = DragAndDropVisualMode.Rejected;

                    currentEvent.Use();
                    break;
            }
        }

        private bool IsOutfitPrefab(GameObject gameObject)
        {
            if (!gameObject.TryGetComponent<Animator>(out _))
                return false;

            Transform armature = null;
            foreach (Transform child in gameObject.transform)
                if (child.name.ToLower().Contains("armature"))
                {
                    armature = child;
                    break;
                }

            if (armature == null)
                return false;

            foreach (Transform child in armature)
                if (child.name.ToLower().Contains("hips") || child.name.ToLower().Contains("hip"))
                    return true;

            return false;
        }
    }
}
