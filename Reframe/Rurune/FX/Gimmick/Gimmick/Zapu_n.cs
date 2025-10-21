using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA.Rurune
{
    internal class Zapu_n : Base
    {
        internal override void ChangeObj(params string[] delPath)
        {
            var prefabPath = AssetDatabase.GUIDToAssetPath("ec7fbd8af3a3d86498b65f757efa7283");
            if (string.IsNullOrEmpty(prefabPath))
                return;

            var prefab = AssetDatabase.LoadAssetAtPath<GameObject>(prefabPath);
            if (prefab != null)
            {
                var ruruneReframe = avatarRoot.GetComponentInChildren<RuruneReframe>();
                Transform targetParent = avatarRoot;
                int insertIndex = 0;

                if (ruruneReframe != null)
                {
                    insertIndex = ruruneReframe.transform.GetSiblingIndex();
                }

                var existingInstance = targetParent
                    .GetComponentsInChildren<Transform>(true)
                    .FirstOrDefault(t =>
                        t != targetParent
                        && PrefabUtility.GetCorrespondingObjectFromSource(t.gameObject) == prefab
                    );

                if (existingInstance != null)
                    return;

                var instance = PrefabUtility.InstantiatePrefab(prefab, targetParent);
                if (instance is GameObject gameObject)
                {
                    gameObject.name = prefab.name;

                    gameObject.transform.SetSiblingIndex(insertIndex);
                }
            }
        }
    }
}
