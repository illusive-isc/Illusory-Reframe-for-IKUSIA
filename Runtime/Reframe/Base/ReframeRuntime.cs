using UnityEditor.Animations;
using UnityEngine;
using VRC.SDK3.Avatars.ScriptableObjects;
using VRC.SDKBase;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA {
	[AddComponentMenu("")]
	public abstract class ReframeRuntime : MonoBehaviour, IEditorOnly {
		public AnimatorController paryi_FX;
		public AnimatorController paryi_Loco;
		public AnimatorController paryi_Action;
		public AnimatorController paryi_Gesture;
		public VRCExpressionsMenu menu;
		public VRCExpressionParameters param;
		public bool maxParticleLimitFlg = false;
		public bool IKUSIA_emote = false;
		public bool AAORemoveFlg = false;
		public bool questFlg1 = false;
		public bool HeelFlg = true;
		public readonly bool ReframeFlg = true;
		public readonly bool ConstraintFlg = true;
		public ExecuteModeOption executeMode = ExecuteModeOption.NDMF;
		public TextureResizeOption textureResize = TextureResizeOption.LowerResolution;

		public enum TextureResizeOption {
			LowerResolution,
			Delete,
		}

		public enum ExecuteModeOption {
			nonNDMF,
			NDMF,
		}
	}
}
