using UnityEditor.Animations;
using UnityEngine;
using VRC.SDK3.Avatars.ScriptableObjects;
using VRC.SDKBase;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA
{
    [AddComponentMenu("")]
    public abstract class ReframeAbstract : MonoBehaviour, IEditorOnly
    {
        public AnimatorController paryi_FXDef;
        public VRCExpressionsMenu menuDef;
        public VRCExpressionParameters paramDef;
        public AnimatorController paryi_FX;
        public VRCExpressionsMenu menu;
        public VRCExpressionParameters param;
        public bool AAORemoveFlg;
        public TextureResizeOption textureResize = TextureResizeOption.LowerResolution;

        public enum TextureResizeOption
        {
            LowerResolution,
            Delete,
        }
    }
}
