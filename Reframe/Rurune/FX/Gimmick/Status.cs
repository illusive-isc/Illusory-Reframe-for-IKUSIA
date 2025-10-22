using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Animations;
using UnityEngine;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA.Rurune
{
    internal class Status : Base
    {
        internal override List<string> GetDelPath() => new() { "Advanced/Particle/6" };

        internal override void ChangeObj(params string[] delPath)
        {
#if NDMF_FOUND
            if (((RuruneReframe)reframe).StatusActiveFlg)
            {
                SetUpMenuSubMenu(
                    "Status",
                    new string[]
                    {
                        "AFK",
                        "食事",
                        "Blender",
                        "Unity",
                        "お絵描き",
                        "禁止",
                        "ゲーム",
                        "ミュート",
                    },
                    "Status",
                    new ChildMotion[]
                    {
                        NewMethod("", 0, "Advanced/Particle/6/0"),
                        NewMethod("AFK", 1, "Advanced/Particle/6/1"),
                        NewMethod("食事", 2, "Advanced/Particle/6/2"),
                        NewMethod("Blender", 3, "Advanced/Particle/6/3"),
                        NewMethod("Unity", 4, "Advanced/Particle/6/4"),
                        NewMethod("お絵描き", 5, "Advanced/Particle/6/5"),
                        NewMethod("禁止", 6, "Advanced/Particle/6/6"),
                        NewMethod("ゲーム", 7, "Advanced/Particle/6/7"),
                        NewMethod("ミュート", 8, "Advanced/Particle/6/8"),
                    },
                    "Gimmick"
                );
                if (reframe.transform.Find("Status") == null)
                    InstantiateStatusPrefab();
            }
            else
                base.ChangeObj(delPath);
#else
            base.ChangeObj(delPath);
#endif
        }

        private void InstantiateStatusPrefab()
        {
            GameObject prefab = null;
            string foundPath = null;

            // Package配下での動的検索
            prefab = FindPrefabInPackages("Status.prefab");
            if (prefab != null)
            {
                foundPath = AssetDatabase.GetAssetPath(prefab);
            }

            // 見つからない場合は固定パスを試行
            if (prefab == null)
            {
                string[] possiblePaths = {
                    "Packages/jp.illusive-isc.illusory-reframe-4-ikusia/Runtime/Status.prefab",
                    "Packages/Illusory-Reframe-for-IKUSIA/Runtime/Status.prefab",
                    "Assets/IllusoryReframe/Prefabs/Status.prefab"
                };

                foreach (var path in possiblePaths)
                {
                    prefab = AssetDatabase.LoadAssetAtPath<GameObject>(path);
                    if (prefab != null)
                    {
                        foundPath = path;
                        break;
                    }
                }
            }

            if (prefab != null)
            {
                try
                {
                    GameObject instance = (GameObject)PrefabUtility.InstantiatePrefab(prefab);

                    // reframeの子として配置
                    if (reframe != null && reframe.transform != null)
                    {
                        instance.transform.SetParent(reframe.transform);
                        instance.transform.localPosition = Vector3.zero;
                        instance.transform.localRotation = Quaternion.identity;
                        instance.transform.localScale = Vector3.one;
                    }
                    else
                    {
                        instance.transform.SetParent(avatarRoot);
                        instance.transform.localPosition = Vector3.zero;
                    }

                    Debug.Log($"Status prefab instantiated from: {foundPath}");
                }
                catch (Exception e)
                {
                    Debug.LogError($"Failed to instantiate Status prefab: {e.Message}");
                }
            }
            else
            {
                Debug.LogWarning("Status prefab not found in any of the expected locations");
            }
        }

        private ChildMotion NewMethod(string motionName, int index, string motionPath)
        {
            AnimationClip clip = new() { name = $"{motionName}_ON" };
            var onCurve = new AnimationCurve();
            onCurve.AddKey(0f, 1f);
            clip.SetCurve(motionPath, typeof(GameObject), "m_IsActive", onCurve);

            AssetDatabase.AddObjectToAsset(clip, AssetContainer ? AssetContainer : paryi_FX);
            AssetDatabase.SaveAssets();
            return new()
            {
                motion = clip,
                threshold = index,
                timeScale = 1,
            };
        }

        /// <summary>
        /// Package配下でプレハブファイルを動的に検索
        /// </summary>
        /// <param name="prefabName">検索するプレハブファイル名</param>
        /// <returns>見つかったプレハブ、見つからない場合はnull</returns>
        private GameObject FindPrefabInPackages(string prefabName)
        {
            // AssetDatabaseですべてのGUIDを検索
            string[] guids = AssetDatabase.FindAssets($"{System.IO.Path.GetFileNameWithoutExtension(prefabName)} t:GameObject");

            foreach (string guid in guids)
            {
                string path = AssetDatabase.GUIDToAssetPath(guid);

                // Packagesフォルダ配下かつ指定されたファイル名のプレハブを検索
                if (path.StartsWith("Packages/") && path.EndsWith(prefabName))
                {
                    var prefab = AssetDatabase.LoadAssetAtPath<GameObject>(path);
                    if (prefab != null)
                    {
                        Debug.Log($"Found prefab in package: {path}");
                        return prefab;
                    }
                }
            }

            // IllusoryReframe関連のPackageを優先的に検索
            string[] priorityPackages = {
                "jp.illusive-isc.illusory-reframe",
                "illusory-reframe",
                "IllusoryReframe"
            };

            foreach (string packageName in priorityPackages)
            {
                string[] commonPaths = {
                    $"Packages/{packageName}/Runtime/{prefabName}",
                    $"Packages/{packageName}/Prefabs/{prefabName}",
                    $"Packages/{packageName}/{prefabName}",
                    $"Packages/{packageName.ToLower()}/Runtime/{prefabName}",
                    $"Packages/{packageName.ToLower()}/{prefabName}"
                };

                foreach (string path in commonPaths)
                {
                    var prefab = AssetDatabase.LoadAssetAtPath<GameObject>(path);
                    if (prefab != null)
                    {
                        Debug.Log($"Found prefab via priority search: {path}");
                        return prefab;
                    }
                }
            }

            return null;
        }
    }
}
