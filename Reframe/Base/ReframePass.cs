#if NDMF_FOUND
using System;
using nadena.dev.ndmf;
using UnityEngine;
using VRC.SDK3.Avatars.Components;
using static jp.illusive_isc.IllusoryReframe.IKUSIA.ReframeRuntime;
using Object = UnityEngine.Object;

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
                    if (reframe.executeMode == ExecuteModeOption.nonNDMF)
                    {
                        descriptor.expressionsMenu = reframe.menu;
                        descriptor.expressionParameters = reframe.param;
                        descriptor.baseAnimationLayers[0].animatorController = reframe.paryi_Loco;
                        descriptor.baseAnimationLayers[2].animatorController = reframe.paryi_Gesture;
                        descriptor.baseAnimationLayers[3].animatorController = reframe.paryi_Action;
                        descriptor.baseAnimationLayers[4].animatorController = reframe.paryi_FX;
                    }
                    else
                    {
                        try
                        {
                            ExeAbstract exe = CreateReframeExecutorFromNamespace(
                                reframe.GetType().Name
                            );
                            exe.SetTarget(reframe);
                            exe.SetAssetContainer(context.AssetContainer);
                            exe.Execute(descriptor);
                        }
                        catch (Exception e)
                        {
                            Debug.LogWarning("変換に失敗しました。" + e);
                        }
                    }
                }
                if (reframe.transform.childCount == 0)
                    Object.DestroyImmediate(reframe.gameObject);
            }
        }

        private ExeAbstract CreateReframeExecutorFromNamespace(string reframename)
        {
            Type exeType = null;
            if (reframename.Contains("Mizuki"))
                exeType = typeof(Mizuki.ReframeExe);
            if (reframename.Contains("Rurune"))
                exeType = typeof(Rurune.ReframeExe);
            // if (reframename.Contains("Mao"))
            //     exeType = typeof(Mao.ReframeExe);
            // if (reframename.Contains("Ririka"))
            //     exeType = typeof(Ririka.ReframeExe);

            if (exeType == null)
                return null;
            return Activator.CreateInstance(exeType) as ExeAbstract;
        }
    }
}
#endif
