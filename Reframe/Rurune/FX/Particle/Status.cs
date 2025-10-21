using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Animations;
using UnityEngine;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA.Rurune
{
    internal class Status : Base
    {
        internal override List<string> GetDelPath() => new() { "Advanced/Particle/6" };

        internal override void ChangeObj(params string[] delPath)
        {
#if NDMF_FOUND
            if (((RuruneReframe)reframe).StatusActiveFlg)
            {
                SetUpMenuSubMenu(
                    "Status",
                    new string[]
                    {
                        "AFK",
                        "食事",
                        "Blender",
                        "Unity",
                        "お絵描き",
                        "禁止",
                        "ゲーム",
                        "ミュート",
                    },
                    "Status",
                    new ChildMotion[]
                    {
                        NewMethod("", 0, "Advanced/Particle/6/0"),
                        NewMethod("AFK", 1, "Advanced/Particle/6/1"),
                        NewMethod("食事", 2, "Advanced/Particle/6/2"),
                        NewMethod("Blender", 3, "Advanced/Particle/6/3"),
                        NewMethod("Unity", 4, "Advanced/Particle/6/4"),
                        NewMethod("お絵描き", 5, "Advanced/Particle/6/5"),
                        NewMethod("禁止", 6, "Advanced/Particle/6/6"),
                        NewMethod("ゲーム", 7, "Advanced/Particle/6/7"),
                        NewMethod("ミュート", 8, "Advanced/Particle/6/8"),
                    },
                    "Gimmick"
                );
            }
            else
                base.ChangeObj(delPath);
#else
            base.ChangeObj(delPath);
#endif
        }

        private ChildMotion NewMethod(string motionName, int index, string motionPath)
        {
            AnimationClip clip = new() { name = $"{motionName}_ON" };
            var onCurve = new AnimationCurve();
            onCurve.AddKey(0f, 1f);
            clip.SetCurve(motionPath, typeof(GameObject), "m_IsActive", onCurve);

            AssetDatabase.AddObjectToAsset(clip, AssetContainer ? AssetContainer : paryi_FX);
            AssetDatabase.SaveAssets();
            return new()
            {
                motion = clip,
                threshold = index,
                timeScale = 1,
            };
        }
    }
}
