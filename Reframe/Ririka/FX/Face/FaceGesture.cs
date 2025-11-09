using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditor.Animations;
using UnityEngine;
using VRC.SDK3.Avatars.ScriptableObjects;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA.Ririka {
	internal class FaceGesture : Base {
		public bool FaceGestureFlg2 = false;
		public bool FaceLockFlg = false;
		public bool FaceValFlg = false;
		public bool blinkFlg = false;
		public bool blinkDelFlg = false;

		internal override List<string> GetLayers() =>
			new() { "LeftHand", "RightHand", "LipSynk", "Blink_Control" };

		internal static readonly List<string> FaceVariation = new() { "Face_variation" };

		internal override List<string> GetParameters() => new() { "FaceLock", "Face_variation" };

		private static readonly List<string> Fist = new() { "Fist", "Fist 0" };
		private static readonly List<string> Gesture = new() {
			"Fist 0",
			"Open 0",
			"Point 0",
			"Peace 0",
			"RockNRoll 0",
			"Gun 0",
			"Thumbs up 0",
		};

		internal override void InitializePlus(ReframeRuntime reframe) {
			FaceGestureFlg2 = ((RirikaReframe)reframe).FaceGestureFlg2;
			FaceLockFlg = ((RirikaReframe)reframe).FaceLockFlg;
			FaceValFlg = ((RirikaReframe)reframe).FaceValFlg;
			blinkFlg = ((RirikaReframe)reframe).blinkFlg;
			blinkDelFlg = ((RirikaReframe)reframe).blinkDelFlg;
		}

		internal override void ChangeFx(List<string> Layers) {
			if (!FaceGestureFlg2 && FaceLockFlg)
				foreach (var layer in paryi_FX.layers.Where(layer => layer.name is "LeftHand" or "RightHand" or "Blink_Control")) {
					if (layer.name is "Blink_Control") {
						var states = layer.stateMachine.states;

						foreach (var state in states) {
							if (state.state.name == "blinkctrl") {
								foreach (var t in state.state.transitions)
									t.conditions = t
										.conditions.Where(c => c.parameter != "FaceLock")
										.ToArray();
							}
						}
						layer.stateMachine.states = states;
					}
					if (layer.name is "RightHand") {
						var states = layer.stateMachine.states;

						foreach (var state in states) {
							if (Fist.Contains(state.state.name)) {
								var parentBlendTree = state.state.motion as BlendTree;
								var newMotion = AssetDatabase.LoadAssetAtPath<Motion>(AssetDatabase.GUIDToAssetPath("f51cf46f18de7fd4dabf3a70544a4963"));
								state.state.motion = newMotion;
							}
						}
					}
					if (layer.name is "LeftHand") {
						var states = layer.stateMachine.states;

						foreach (var state in states) {
							if (Fist.Contains(state.state.name)) {
								var parentBlendTree = state.state.motion as BlendTree;
								var newMotion = AssetDatabase.LoadAssetAtPath<Motion>(AssetDatabase.GUIDToAssetPath("c246cbd1068b6384b8c4b752022f9c2e"));
								state.state.motion = newMotion;
							}
						}
					}
					var stateMachine = layer.stateMachine;
					foreach (var t in stateMachine.anyStateTransitions)
						t.conditions = t.conditions.Where(c => c.parameter != "FaceLock").ToArray();
				}
			if (!FaceGestureFlg2 && FaceValFlg)
				foreach (var layer in paryi_FX.layers.Where(layer => layer.name is "LeftHand" or "RightHand" or "Blink_Control")) {
					RemoveStatesAndTransitions(
						layer.stateMachine,
						layer
							.stateMachine.states.Where(state => Gesture.Contains(state.state.name))
							.Select(s => s.state)
							.ToArray()
					);

					if (layer.name is "Blink_Control") {
						var states = layer.stateMachine.states;

						foreach (var state in states) {
							if (state.state.name == "blinkctrl") {
								foreach (var t in state.state.transitions)
									t.conditions = t
										.conditions.Where(c => !FaceVariation.Contains(c.parameter))
										.ToArray();
								state.state.transitions = state.state.transitions[0..2];
							}
						}
						layer.stateMachine.states = states;
					}
					if (layer.name is "LeftHand" or "RightHand") {
						var anyStateTransitions = layer.stateMachine.anyStateTransitions;

						foreach (var transition in anyStateTransitions) {
							transition.conditions = transition
								.conditions.Where(c => !FaceVariation.Contains(c.parameter))
								.ToArray();
						}
						layer.stateMachine.anyStateTransitions = anyStateTransitions;
					}
				}
			if (!FaceGestureFlg2 && blinkDelFlg)
				foreach (var layer in paryi_FX.layers.Where(layer => layer.name is "Blink_Control")) {
					if (layer.name is "Blink_Control") {
						RemoveStatesAndTransitions(
							layer.stateMachine,
							layer
								.stateMachine.states.Where(state =>
									state.state.name is "blinkctrl" or "blink"
								)
								.Select(s => s.state)
								.ToArray()
						);
					}
				}
			if (!FaceGestureFlg2 && blinkDelFlg)
				foreach (var layer in paryi_FX.layers.Where(layer => layer.name is "Blink_Control")) {
					if (layer.name is "Blink_Control") {
						var states = layer.stateMachine.states;

						foreach (var state in states) {
							if (state.state.name == "blinkctrl") {
								foreach (var t in state.state.transitions)
									t.conditions = t
										.conditions.Where(c => c.parameter != "Blink off")
										.ToArray();
							}
						}
						layer.stateMachine.states = states;
					}
				}

			if (!FaceGestureFlg2)
				return;

			paryi_FX.layers = paryi_FX
				.layers.Where(layer => !Layers.Contains(layer.name))
				.ToArray();
		}

		internal override void EditVRCExpressions(VRCExpressionsMenu menu, List<string> menuPath) {
			var def = new List<string> { "Gimmick", "Face" };
			if (FaceGestureFlg2 || FaceLockFlg)
				base.EditVRCExpressions(menu, def.Concat(new List<string> { "FaceLock" }).ToList());
			if (FaceGestureFlg2 || FaceValFlg)
				base.EditVRCExpressions(
					menu,
					def.Concat(new List<string> { "Face_variation" }).ToList()
				);
			if (FaceGestureFlg2 || blinkFlg)
				base.EditVRCExpressions(
					menu,
					def.Concat(new List<string> { "Blink off" }).ToList()
				);
		}
	}
}
