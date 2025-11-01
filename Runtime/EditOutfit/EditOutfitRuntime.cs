using UnityEngine;
using VRC.SDKBase;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA {

	[RequireComponent(typeof(ReframeRuntime))]
	[AddComponentMenu("ILLUSORY OVERRIDE/IllusoryReframe/EditOutfit")]
	public class EditOutfitRuntime : MonoBehaviour, IEditorOnly {
		[Header("編集Target(ここにドラッグアンドドロップ)")]
		public SkinnedMeshRenderer convertTargetSMR;

		[Header("編集Target（ここにドラッグアンドドロップ）")]
		public GameObject convertTargetPrefab;
	}
}
