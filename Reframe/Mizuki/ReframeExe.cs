using System.Collections.Generic;
using System.Diagnostics;
using VRC.SDK3.Avatars.Components;
using Debug = UnityEngine.Debug;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA.Mizuki
{
    public partial class ReframeExe : ExeAbstract
    {
        public void SetTarget<T>(T target)
            where T : ReframeRuntime
        {
            this.target = target;
        }

        protected override string GetPathDirPrefix() => base.GetPathDirPrefix() + "Mizuki/";

        protected override string GetFxGuid() => "eabec4db12bc4574c996310914852639";

        protected override string GetMenuGuid() => "2e95f28830e406047b35e7e58b3c0e79";

        protected override string GetParamGuid() => "ca37a7e2249e6404ea1893c197866705";

        public override void Execute(VRCAvatarDescriptor descriptor)
        {
            var stopwatch = Stopwatch.StartNew();
            var stepTimes = new Dictionary<string, long>
            {
                [stepNames[0]] = InitializeAssets<MizukiReframe>(descriptor, GetPathDirPrefix()),
                [stepNames[1]] = Edit<MizukiReframe>(
                    descriptor,
                    GetParamConfigs<Base, MizukiReframe>(target as MizukiReframe, GetNameSpace())
                ),
                [stepNames[2]] = FinalizeAssets(descriptor),
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
    }
}
