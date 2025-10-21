using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA.Rurune
{
    internal class JointBall : Base
    {
        internal override List<string> GetDelPath() => new() { "Advanced/Gimmick1/8" };

        internal override void ChangeObj(params string[] delPath)
        {
#if NDMF_FOUND
            if (((RuruneReframe)reframe).JointBallActiveFlg)
            {
                CopyParticleMaterial();
                SetUpMenuToggle(
                    "JointBall",
                    "JointBall",
                    CreateChildMotions("JointBall", "Advanced/Gimmick1/8"),
                    "Particle"
                );
            }
            else
                base.ChangeObj(delPath);
#else
            base.ChangeObj(delPath);
#endif
        }

        private void CopyParticleMaterial()
        {
            var subEmitter2 = avatarRoot.Find(
                "Advanced/Gimmick1/8/joint_L/Base/5/5-1/5-2/SubEmitter0"
            );
            if (subEmitter2 == null)
                return;

            if (!subEmitter2.TryGetComponent<ParticleSystem>(out var targetParticleSystem))
                return;

            var targetRenderer = targetParticleSystem.GetComponent<ParticleSystemRenderer>();

            string materialGuid = "1c0f5ddf3b2360d49b6a2c5a3bcfcc87";
            string assetPath = AssetDatabase.GUIDToAssetPath(materialGuid);
            var material = AssetDatabase.LoadAssetAtPath<Material>(assetPath);

            if (material != null)
                targetRenderer.material = material;
        }
    }
}
