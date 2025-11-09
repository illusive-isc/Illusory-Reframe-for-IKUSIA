using UnityEditor;
using UnityEngine;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA.Ririka {
	internal class AnotherCloth : Base {

		internal override void ChangeObj(params string[] delPath) {
			var prefab = AssetDatabase.LoadAssetAtPath<GameObject>(AssetDatabase.GUIDToAssetPath("416063b3d4900a3468a716c27a8f6dee"));
			bool alreadyExists = false;
			GameObject instance = (GameObject)
				PrefabUtility.InstantiatePrefab(prefab);
			foreach (Transform child in avatarRoot)
				if (child.name == prefab.name) {
					alreadyExists = true;
					DestroyImmediate(instance);
					instance = child.gameObject;
					break;
				}
			if (!alreadyExists)
				if (instance != null)
					instance.transform.SetParent(avatarRoot, false);
		}
	}
}