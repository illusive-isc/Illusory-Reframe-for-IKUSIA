using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA.Ririka {
	internal class BreastSize : Base {
		bool breastSizeFlg1,
			breastSizeFlg2,
			breastSizeFlg3;

		internal override List<string> GetParameters() => new() { "BreastSize" };

		internal override List<string> GetMenuPath() => new() { "Gimmick", "Breast_size" };

		internal override void InitializePlus(ReframeRuntime reframe) {
			// breastSizeFlg1 = ((RirikaReframe)reframe).BreastSizeFlg1;
			// breastSizeFlg2 = ((RirikaReframe)reframe).BreastSizeFlg2;
			// breastSizeFlg3 = ((RirikaReframe)reframe).BreastSizeFlg3;
		}

		internal override void ChangeObj(params string[] delPath) {
			SetBreastSizeWeights(
				"Body_b",
				"Breast_small_____胸_小",
				"Breast_big(limit)",
				"Breast_Big_____胸_大(mizuki)"
			);
			SetBreastSizeWeights(
				"acce",
				"Breast_smal",
				"Breast_big(limit)",
				"Breast_Big_____胸_大(mizuki)"
			);
			SetBreastSizeWeights(
				"cloth",
				"Breast_small_____胸_小",
				"Breast_big(limit)",
				"Breast_Big_____胸_大(mizuki)"
			);
			SetBreastSizeWeights("jacket", "", "Breast_big(limit)", "Breast_Big_____胸_大(mizuki)");
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
			string Mizuki
		) {
			var meshT = avatarRoot.Find(part);
			if (meshT == null)
				return;

			var smr = meshT.GetComponent<SkinnedMeshRenderer>();
			if (smr.sharedMesh == null)
				smr.sharedMesh = GetOriginalMeshFromPrefab(
					part,
					"3f6745202eacadf4a9559c1912432fa9"
				);
			if (breastSizeFlg3)
				BreastSizeMizuki(meshT);

			SetWeight(meshT, breastSmall, breastSizeFlg1 ? 100 : 0);
			SetWeight(meshT, Limit, breastSizeFlg2 ? 100 : 0);
			SetWeight(meshT, Mizuki, breastSizeFlg3 ? 100 : 0);
		}

		public void BreastSizeMizuki(Transform meshT) {
			var smr = meshT.GetComponent<SkinnedMeshRenderer>();
			bool flowControl = CreateDuplicateBSKey(
				smr,
				"Breast_big(limit)",
				"Breast_Big_____胸_大(mizuki)",
				out Mesh newMesh,
				2f,
				"Breast_Big_____胸_大(mizuki)"
			);
			if (!flowControl)
				return;

			AssetDatabase.AddObjectToAsset(newMesh, paryi_FX);
		}
	}
}
