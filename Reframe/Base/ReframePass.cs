#if NDMF_FOUND
using jp.illusive_isc.IllusoryReframe.IKUSIA.Mizuki;
using nadena.dev.ndmf;
using UnityEngine;
using VRC.SDK3.Avatars.Components;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA
{
    public class ReframePass : Pass<ReframePass>
    {
        protected override void Execute(BuildContext context)
        {
            foreach (
                ReframeRuntime reframe in context.AvatarRootObject.GetComponentsInChildren<ReframeRuntime>()
            )
            {
                if (reframe.transform.root.TryGetComponent(out VRCAvatarDescriptor descriptor))
                {
                    try
                    {
                        ReframeExe exe = new();
                        exe.SetTarget(reframe);
                        exe.SetAssetContainer(context.AssetContainer);
                        exe.Execute(descriptor);
                    }
                    catch (System.Exception)
                    {
                        Debug.LogWarning("変換に失敗しました。");
                    }
                }
                Object.DestroyImmediate(reframe.gameObject);
            }
        }
    }
}
#endif
