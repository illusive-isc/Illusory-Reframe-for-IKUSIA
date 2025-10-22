using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA.Rurune
{
    internal class BreastSize : Base
    {
        bool breastSizeFlg1,
            breastSizeFlg2,
            breastSizeFlg3;

        internal override List<string> GetParameters() => new() { "BreastSize" };

        internal override List<string> GetMenuPath() => new() { "Gimmick", "Breast_size" };

        internal override void InitializePlus(ReframeRuntime reframe)
        {
            breastSizeFlg1 = ((RuruneReframe)reframe).BreastSizeFlg1;
            breastSizeFlg2 = ((RuruneReframe)reframe).BreastSizeFlg2;
            breastSizeFlg3 = ((RuruneReframe)reframe).BreastSizeFlg3;
        }

        internal override void ChangeObj(params string[] delPath)
        {
            SetBreastSizeWeights(
                "Body_b",
                "Breast_small_____胸_小",
                "Breast_big(limit)",
                "Breast_Big_____胸_大(mizuki)"
            );
            SetBreastSizeWeights("acce", "Breast_smal", "Breast_big(limit)");
            SetBreastSizeWeights("cloth", "Breast_small_____胸_小", "Breast_big(limit)");
            SetBreastSizeWeights("jacket", "", "Breast_big(limit)");
            SetBreastSizeWeights(
                "underwear",
                "Retarget_Body_b_Breast_small_____胸_小",
                "Breast_big(limit)",
                "Breast_Big_____胸_大"
            );
        }

        private void SetBreastSizeWeights(
            string part,
            string breastSmall,
            string Limit,
            string Mizuki = ""
        )
        {
            var meshT = avatarRoot.Find(part);
            if (meshT == null)
                return;

            var smr = meshT.GetComponent<SkinnedMeshRenderer>();
            if (smr.sharedMesh == null)
                smr.sharedMesh = GetOriginalMeshFromPrefab(part);
            if (breastSizeFlg3)
                BreastSizeMizuki(meshT);

            if (Mizuki == "")
                SetWeight(meshT, "Breast_Big_mizuki_plus", breastSizeFlg3 ? 100 : 0);
            else
                SetWeight(meshT, Mizuki, breastSizeFlg3 ? 100 : 0);

            SetWeight(meshT, breastSmall, breastSizeFlg1 ? 100 : 0);
            SetWeight(
                meshT,
                Limit,
                breastSizeFlg2 || (part != "Body_b" && breastSizeFlg3) ? 100 : 0
            );
        }

        public void BreastSizeMizuki(Transform meshT)
        {
            var smr = meshT.GetComponent<SkinnedMeshRenderer>();
            var mesh = smr.sharedMesh;
            if (mesh == null)
                return;

            int targetIndex = -1;
            for (int i = 0; i < mesh.blendShapeCount; i++)
            {
                if (mesh.GetBlendShapeName(i) == "Breast_big(limit)")
                {
                    targetIndex = i;
                    break;
                }
            }
            if (targetIndex == -1)
                return;

            int frameCount = mesh.GetBlendShapeFrameCount(targetIndex);

            bool alreadyExists = false;
            for (int i = 0; i < mesh.blendShapeCount; i++)
            {
                if (
                    mesh.GetBlendShapeName(i)
                    is "Breast_Big_____胸_大(mizuki)"
                        or "Breast_Big_mizuki_plus"
                )
                {
                    alreadyExists = true;
                    break;
                }
            }
            if (alreadyExists)
                return;

            // メッシュをコピーして変更
            var newMesh = Instantiate(mesh);
            var deltaVerts = new Vector3[newMesh.vertexCount];
            var deltaNormals = new Vector3[newMesh.vertexCount];
            var deltaTangents = new Vector3[newMesh.vertexCount];

            // 新しいBlendShapeを追加
            for (int f = 0; f < frameCount; f++)
            {
                newMesh.GetBlendShapeFrameVertices(
                    targetIndex,
                    f,
                    deltaVerts,
                    deltaNormals,
                    deltaTangents
                );
                float weight = newMesh.GetBlendShapeFrameWeight(targetIndex, f);
                float newWeight = Mathf.Clamp(weight > 100f ? weight * 0.5f : weight, 0f, 100f);
                newMesh.AddBlendShapeFrame(
                    "Breast_Big_mizuki_plus",
                    newWeight,
                    deltaVerts,
                    deltaNormals,
                    deltaTangents
                );
            }

            smr.sharedMesh = newMesh;
            AssetDatabase.AddObjectToAsset(newMesh, paryi_FX);
        }

        private Mesh GetOriginalMeshFromPrefab(string part)
        {
            GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>(
                AssetDatabase.GUIDToAssetPath("3f6745202eacadf4a9559c1912432fa9")
            );
            if (prefab != null)
            {
                Transform partTransform = prefab.transform.Find(part);
                if (partTransform != null)
                {
                    SkinnedMeshRenderer smr = partTransform.GetComponent<SkinnedMeshRenderer>();
                    if (smr != null && smr.sharedMesh != null)
                    {
                        return smr.sharedMesh;
                    }
                }
            }
            return null;
        }
    }
}
