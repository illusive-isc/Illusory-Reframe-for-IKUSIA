using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditor.Animations;
using UnityEngine;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA.Rurune
{
    internal class LightGunColor : Base
    {
        protected string[] LightGunColorList =>
            new string[]
            {
                "d0c3b1ca41a11a14294727725facdd17",
                "299419c74edbb924781bcc4d6cb17494",
                "7b618e4e6b6b4b840b041098a1e1b66f",
                "4773fb745408abc4b89a0f00df3b4220",
                "3a0fcec04bfb16545afe5ada4fbedd8f",
                "3a4a9dc98684e564a83bd685bf1f556c",
                "302c73d1dfc00cd489737d692f798b18",
                "586aa24ec20e49141848fa49d3dc3843",
                "0ea8ba6dc6e80084bb0cf520a1ffddcb",
                "81cd1dbef1b4f0b4c88803d913ca0169",
                "fc68120573b34b149bb49ca27c9675af",
            };

        internal override void ChangeFxBT(List<string> Parameters)
        {
            foreach (var layer in paryi_FX.layers.Where(layer => layer.name == "MainCtrlTree"))
            {
                var state = layer
                    .stateMachine.states.Where(s =>
                        s.state != null && s.state.name == "MainCtrlTree"
                    )
                    .ToArray();
                if (state.Length != 0)
                {
                    var blendTree = state[0].state.motion as BlendTree;
                    var children = blendTree.children;

                    for (int i = 0; i < children.Length; i++)
                    {
                        var clip = children[i].motion as AnimationClip;
                        if (clip != null && clip.name.StartsWith("LightColor"))
                        {
                            var c = children[i];
                            c.motion = AssetDatabase.LoadAssetAtPath<AnimationClip>(
                                AssetDatabase.GUIDToAssetPath(
                                    LightGunColorList[(int)((RuruneReframe)reframe).lightGun]
                                )
                            );
                            children[i] = c;
                        }
                    }
                    blendTree.children = children;
                }
            }
        }
    }
}
