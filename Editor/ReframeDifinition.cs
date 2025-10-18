#if NDMF_FOUND
using jp.illusive_isc.IllusoryReframe.IKUSIA;
using nadena.dev.ndmf;

[assembly: ExportsPlugin(typeof(ReframeDifinition))]

namespace jp.illusive_isc.IllusoryReframe.IKUSIA
{
    public class ReframeDifinition : Plugin<ReframeDifinition>
    {
        public override string QualifiedName => "IllusoryOverride.Reframe";
        public override string DisplayName => "IllusoryReframe";

        protected override void Configure()
        {
            InPhase(BuildPhase.Transforming)
                .BeforePlugin("nadena.dev.modular-avatar")
                .Run(ReframePass.Instance);
        }
    }
}
#endif
