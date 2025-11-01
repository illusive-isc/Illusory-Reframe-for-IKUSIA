using System.Linq;
using UnityEditor;
using UnityEngine;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA.Rurune {
	internal class Zapu_n : Base {
		internal override void ChangeObj(params string[] delPath) {
			const string targetPrefabGuid = "ec7fbd8af3a3d86498b65f757efa7283";

			// 既にこのGUIDのプレハブが追加されているかチェック
			if (IsPrefabAlreadyInstantiated(targetPrefabGuid)) {
				Debug.Log(
					$"Prefab with GUID {targetPrefabGuid} is already instantiated. Skipping."
				);
				return;
			}

			var prefabPath = AssetDatabase.GUIDToAssetPath(targetPrefabGuid);
			if (string.IsNullOrEmpty(prefabPath)) {
				Debug.LogWarning($"Prefab with GUID {targetPrefabGuid} not found.");
				return;
			}

			var prefab = AssetDatabase.LoadAssetAtPath<GameObject>(prefabPath);
			if (prefab != null) {
				var ruruneReframe = avatarRoot.GetComponentInChildren<RuruneReframe>();
				Transform targetParent = avatarRoot;
				int insertIndex = 0;

				if (ruruneReframe != null) {
					insertIndex = ruruneReframe.transform.GetSiblingIndex();
				}

				var instance = PrefabUtility.InstantiatePrefab(prefab, targetParent);
				if (instance is GameObject gameObject) {
					gameObject.name = prefab.name;
					gameObject.transform.SetSiblingIndex(insertIndex);

					Debug.Log($"Successfully instantiated prefab: {prefab.name}");
				}
			}
		}

		private bool IsPrefabAlreadyInstantiated(string guid) {
			var prefabPath = AssetDatabase.GUIDToAssetPath(guid);
			if (string.IsNullOrEmpty(prefabPath))
				return false;

			var prefab = AssetDatabase.LoadAssetAtPath<GameObject>(prefabPath);
			if (prefab == null)
				return false;

			var existingInstances = avatarRoot
				.GetComponentsInChildren<Transform>(true)
				.Where(t => t != avatarRoot)
				.Where(t => {
					var sourceObject = PrefabUtility.GetCorrespondingObjectFromSource(t.gameObject);
					if (sourceObject == prefab)
						return true;

					if (
						t.gameObject.name == prefab.name
						|| t.gameObject.name.StartsWith(prefab.name)
					)
						return true;

					var prefabRoot = PrefabUtility.GetOutermostPrefabInstanceRoot(t.gameObject);
					if (prefabRoot != null) {
						var rootSource = PrefabUtility.GetCorrespondingObjectFromSource(prefabRoot);
						if (rootSource == prefab)
							return true;
					}

					return false;
				});

			return existingInstances.Any();
		}
	}
}
