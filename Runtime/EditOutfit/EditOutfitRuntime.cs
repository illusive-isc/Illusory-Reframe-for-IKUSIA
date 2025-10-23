using UnityEngine;
using VRC.SDKBase;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA
{
    /// <summary>
    /// EditOutfitRuntimeの具体的な実装クラス
    /// </summary>
    [AddComponentMenu("ILLUSORY OVERRIDE/IllusoryReframe/EditOutfit")]
    public class EditOutfitRuntime : MonoBehaviour, IEditorOnly
    {
        [Header("編集Target")]
        public SkinnedMeshRenderer convertTargetSMR;

        [Header("編集Target")]
        public GameObject convertTargetPrefab;
    }
}
