#if NDMF_FOUND
using nadena.dev.ndmf;
using UnityEngine;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA
{
    public class ReframePass : Pass<ReframePass>
    {
        protected override void Execute(BuildContext context)
        {
            foreach (
                ReframeAbstract Override in context.AvatarRootObject.GetComponentsInChildren<ReframeAbstract>()
            )
                Object.DestroyImmediate(Override.gameObject);
        }
    }
}
#endif
