using System.Collections.Generic;
using System.Diagnostics;
using VRC.SDK3.Avatars.Components;
using Debug = UnityEngine.Debug;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA.Mizuki
{
    public partial class ReframeExe : ExeAbstract
    {
        public ReframeExe(MizukiReframe target)
        {
            this.target = target;
        }

        string pathDirPrefix = "Assets/IllusoryReframe/Mizuki";

        public override void Execute(VRCAvatarDescriptor descriptor)
        {
            var stopwatch = Stopwatch.StartNew();
            var stepTimes = new Dictionary<string, long>
            {
                ["InitializeAssets"] = InitializeAssets<MizukiReframe>(
                    descriptor,
                    pathDirPrefix,
                    "eabec4db12bc4574c996310914852639",
                    "2e95f28830e406047b35e7e58b3c0e79",
                    "ca37a7e2249e6404ea1893c197866705"
                ),
                ["EditProcessing"] = Edit<MizukiReframe>(descriptor, GetParamConfigs(descriptor)),
                ["FinalizeAssets"] = FinalizeAssets(descriptor),
            };
            stopwatch.Stop();
            Debug.Log(
                $"最適化を実行しました！総処理時間: {stopwatch.ElapsedMilliseconds}ms ({stopwatch.Elapsed.TotalSeconds:F2}秒)"
            );

            foreach (var kvp in stepTimes)
            {
                Debug.Log($"[Performance] {kvp.Key}: {kvp.Value}ms");
            }
        }

        protected ParamProcessConfig[] GetParamConfigs(VRCAvatarDescriptor descriptor)
        {
            return GetParamConfigs<Base, MizukiReframe>(
                descriptor,
                target as MizukiReframe,
                "jp.illusive_isc.IllusoryReframe.IKUSIA.Mizuki"
            );
        }
    }
}
