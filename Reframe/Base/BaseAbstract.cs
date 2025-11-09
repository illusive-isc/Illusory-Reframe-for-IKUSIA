using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditor.Animations;
using UnityEngine;
using VRC.SDK3.Avatars.ScriptableObjects;
using static jp.illusive_isc.IllusoryReframe.IKUSIA.ReframeRuntime;
using Control = VRC.SDK3.Avatars.ScriptableObjects.VRCExpressionsMenu.Control;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA {
	public abstract class BaseAbstract : ScriptableObject {
		// protected VRCAvatarDescriptor descriptor;
		protected Transform avatarRoot;
		protected AnimatorController paryi_FX;
		protected ReframeRuntime reframe;

		protected Object AssetContainer;

		internal virtual List<string> GetParameters() => new();

		internal virtual List<string> GetMenuPath() => new();

		internal virtual List<string> GetDelPath() => new();

		internal virtual List<string> GetLayers() => new();
		public bool IsEdit() {
			return AssetContainer != null || reframe.executeMode != ExecuteModeOption.NDMF;
		}
		public bool IsNDMFEdit() {
			return AssetContainer != null && reframe.executeMode == ExecuteModeOption.NDMF;
		}

		public static void EditorOnly(Transform obj) {
			if (obj) {
				EditorOnly(obj.gameObject);
			}
		}

		public static void EditorOnly(GameObject obj) {
			if (obj) {
				obj.tag = "EditorOnly";
			}
		}

		public static void DestroyObj(Transform obj) {
			if (obj) {
				DestroyObj(obj.gameObject);
			}
		}

		public static void DestroyObj(GameObject obj) {
			if (obj) {
				DestroyImmediate(obj);
			}
		}

		public static void DestroyComponent<T>(Transform obj)
			where T : Component {
			if (obj) {
				DestroyImmediate(obj.GetComponent<T>());
			}
		}

		public void ExeDestroyObj(Transform obj) {
			if (obj) {
				DestroyObj(obj);
			}
		}

		public static void SetWeight(SkinnedMeshRenderer obj, string weightName, float weight) {
			if (obj) {
				var blendShapeIndex = obj.sharedMesh.GetBlendShapeIndex(weightName);
				if (blendShapeIndex != -1) {
					obj.SetBlendShapeWeight(blendShapeIndex, weight);
				}
			}
		}

		public static void SetWeight(Transform obj, string weightName, float weight) {
			if (obj) {
				if (obj.TryGetComponent<SkinnedMeshRenderer>(out var smr)) {
					SetWeight(smr, weightName, weight);
				}
			}
		}

		protected bool CheckBT(Motion motion, List<string> strings) {
			if (motion is BlendTree blendTree)
				return !strings.Contains(blendTree.blendParameter);
			else
				return true;
		}

		internal virtual void ChangeFxBT(List<string> Parameters) {
			foreach (var layer in paryi_FX.layers.Where(layer => layer.name == "MainCtrlTree")) {
				foreach (var state in layer.stateMachine.states) {
					if (state.state.motion is BlendTree blendTree) {
						blendTree.children = blendTree.children.Where(c => CheckBT(c.motion, Parameters)).ToArray();
					}
				}
			}
		}

		internal abstract void ParticleOptimize();

		internal virtual void EditVRCExpressions(VRCExpressionsMenu menu, List<string> menuPath) {
			if (menu == null || menuPath == null || menuPath.Count == 0)
				return;
			RemoveMenuItemRecursivelyInternal(menu, menuPath, 0);
		}

		protected bool RemoveMenuItemRecursivelyInternal(VRCExpressionsMenu menu, List<string> menuPath, int currentDepth) {
			if (currentDepth >= menuPath.Count)
				return false;

			var targetName = menuPath[currentDepth];

			for (int i = menu.controls.Count - 1; i >= 0; i--) {
				var control = menu.controls[i];

				if (control.name == targetName) {
					if (currentDepth == menuPath.Count - 1) {
						menu.controls.RemoveAt(i);
						return true;
					} else if (control.subMenu != null) {
						return RemoveMenuItemRecursivelyInternal(control.subMenu, menuPath, currentDepth + 1);
					}
				}
			}

			return false;
		}

		internal void Initialize(Transform avatarRoot, AnimatorController paryi_FX, ReframeRuntime reframe, Object AssetContainer = null) {
			this.avatarRoot = avatarRoot;
			this.paryi_FX = paryi_FX;
			this.reframe = reframe;
			this.AssetContainer = AssetContainer;
		}

		internal virtual void InitializePlus(ReframeRuntime reframe) { }

		internal virtual void ChangeObj(params string[] delPath) {
			foreach (var path in delPath)
				DestroyObj(avatarRoot.Find(path));
		}

		internal virtual void ChangeFx(List<string> Layers) {
			paryi_FX.layers = paryi_FX.layers.Where(layer => !Layers.Contains(layer.name)).ToArray();
		}

		public static void RemoveStatesAndTransitions(AnimatorStateMachine stateMachine, params AnimatorState[] statesToRemove) {
			foreach (var state in stateMachine.states) {
				state.state.transitions = state
					.state.transitions.Where(t => t.destinationState == null || !statesToRemove.Contains(t.destinationState))
					.ToArray();
			}
			stateMachine.anyStateTransitions = stateMachine
				.anyStateTransitions.Where(t => t.destinationState == null || !statesToRemove.Contains(t.destinationState))
				.ToArray();
			stateMachine.states = stateMachine.states.Where(s => !statesToRemove.Contains(s.state)).ToArray();
		}

		public static void RemoveStatesAndTransitions(AnimatorController controller, string layerName, params string[] statesToRemove) {
			var layer = controller.layers.First(l => l.name == layerName);
			if (layer != null) {
				AnimatorState[] state = layer
					.stateMachine.states.Select(cs => cs.state)
					.Where(s => s != null && statesToRemove.Contains(s.name))
					.ToArray();
				RemoveStatesAndTransitions(layer.stateMachine, state);
			}
		}

		protected void SetMaxParticle(string path, int max) {
			var particleobj = avatarRoot.Find(path);
			if (particleobj) {
				var mainModule = particleobj.GetComponent<ParticleSystem>().main;
				mainModule.maxParticles = max;
			}
		}

		public static void RemoveState4AnyState(AnimatorController controller, string layerName, params string[] excludeParams) {
			var layer = controller.layers.First(l => l.name == layerName);
			if (layer != null) {
				var anyStateTransitions = layer.stateMachine.anyStateTransitions;

				foreach (var transition in anyStateTransitions) {
					transition.conditions = transition.conditions.Where(c => !excludeParams.Contains(c.parameter)).ToArray();
				}
				layer.stateMachine.anyStateTransitions = anyStateTransitions;
			}
		}

		protected void CreateMainCtrlTree(AnimatorController controller, string childBlendTreeName, string ParameterName, ChildMotion[] childMotion) {
			CreateMainCtrlTree(controller.layers.First(l => l.name == "MainCtrlTree"), childBlendTreeName, ParameterName, childMotion);
		}

		protected void CreateMainCtrlTree(AnimatorControllerLayer layer, string childBlendTreeName, string ParameterName, ChildMotion[] childMotion) {
			CreateMainCtrlTree(layer.stateMachine.states.First(l => l.state.name == "MainCtrlTree"), childBlendTreeName, ParameterName, childMotion);
		}

		private void CreateMainCtrlTree(ChildAnimatorState state, string childBlendTreeName, string ParameterName, ChildMotion[] childMotion) {
			if (state.state.motion is BlendTree blendTree) {
				if (blendTree.children.Any(c => c.motion.name == childBlendTreeName))
					return;
				BlendTree newBlendTree = new() {
					name = childBlendTreeName,
					blendParameter = ParameterName,
					blendParameterY = "Blend",
					blendType = BlendTreeType.Simple1D,
					useAutomaticThresholds = false,
					maxThreshold = 1.0f,
					minThreshold = 0.0f,
				};
				blendTree.AddChild(newBlendTree);
				var children = blendTree.children;

				for (int i = 0; i < children.Length; i++) {
					if (children[i].motion.name == childBlendTreeName) {
						children[i].threshold = 1;
					}
				}
				blendTree.children = children;

				newBlendTree.children = childMotion;

				if (!paryi_FX.parameters.Any(p => p.name == ParameterName)) {
					paryi_FX.AddParameter(new AnimatorControllerParameter() { name = ParameterName, type = AnimatorControllerParameterType.Float });
				}
				AssetDatabase.AddObjectToAsset(newBlendTree, AssetContainer ? AssetContainer : paryi_FX);
				AssetDatabase.SaveAssets();
			}
		}

		protected void SetUpMenuToggle(string menuName, string ParameterName, ChildMotion[] childMotion, params string[] menuPath) {
			var targetMenu = GetMenuByPath(reframe.menu, menuPath);

			AddParameterIfNotExists(reframe.param, menuName);

			targetMenu.Parameters = reframe.param;
			if (targetMenu.controls.Where(c => c.name != menuName).Any()) {
				targetMenu.controls.Add(
					new Control {
						type = Control.ControlType.Toggle,
						name = menuName,
						parameter = new Control.Parameter() { name = menuName },
					}
				);
			}

			CreateMainCtrlTree(paryi_FX, menuName, ParameterName, childMotion);
		}

		protected void SetUpMenuSubMenu(
			string menuName,
			string[] subMenuNames,
			string ParameterName,
			ChildMotion[] childMotion,
			params string[] menuPath
		) {
			var targetMenu = GetMenuByPath(reframe.menu, menuPath);

			AddParameterIfNotExistsInt(reframe.param, ParameterName);

			targetMenu.Parameters = reframe.param;
			if (targetMenu.controls.Where(c => c.name != menuName).Any()) {
				var subMenu = new Control { type = Control.ControlType.SubMenu, name = menuName };
				VRCExpressionsMenu subExpressionsMenu = CreateInstance<VRCExpressionsMenu>();
				subExpressionsMenu.name = menuName;
				subExpressionsMenu.Parameters = reframe.param;
				for (int i = 0; i < subMenuNames.Length; i++) {
					var subMenuName = subMenuNames[i];
					subExpressionsMenu.controls.Add(
						new Control {
							type = Control.ControlType.Toggle,

							name = subMenuName,
							value = i + 1,
							parameter = new Control.Parameter() { name = ParameterName },
						}
					);
				}
				AssetDatabase.AddObjectToAsset(subExpressionsMenu, AssetContainer ? AssetContainer : paryi_FX);
				subMenu.subMenu = subExpressionsMenu;
				targetMenu.controls.Add(subMenu);
			}

			CreateMainCtrlTree(paryi_FX, menuName, ParameterName, childMotion);
		}

		private void AddParameterIfNotExists(VRCExpressionParameters expressionParameters, string parameterName) {
			foreach (var param in expressionParameters.parameters) {
				if (param.name == parameterName)
					return;
			}
			var newParameter = new VRCExpressionParameters.Parameter {
				name = parameterName,
				valueType = VRCExpressionParameters.ValueType.Bool,
				defaultValue = 0f,
				saved = true,
			};

			var parametersList = expressionParameters.parameters.ToList();
			parametersList.Add(newParameter);
			expressionParameters.parameters = parametersList.ToArray();
		}

		private void AddParameterIfNotExistsInt(VRCExpressionParameters expressionParameters, string parameterName) {
			// 既存のパラメータをチェック
			foreach (var param in expressionParameters.parameters) {
				if (param.name == parameterName)
					return;
			}

			var newParameter = new VRCExpressionParameters.Parameter {
				name = parameterName,
				valueType = VRCExpressionParameters.ValueType.Int,
				defaultValue = 0f,
				saved = true,
				networkSynced = false,
			};

			var parametersList = expressionParameters.parameters.ToList();
			parametersList.Add(newParameter);
			expressionParameters.parameters = parametersList.ToArray();
		}

		private VRCExpressionsMenu GetMenuByPath(VRCExpressionsMenu rootMenu, params string[] menuPath) {
			if (rootMenu == null || menuPath == null || menuPath.Length == 0)
				return rootMenu;

			var currentMenu = rootMenu;

			foreach (var pathSegment in menuPath) {
				VRCExpressionsMenu foundSubMenu = null;

				foreach (var control in currentMenu.controls) {
					if (control.name == pathSegment && control.type == Control.ControlType.SubMenu) {
						foundSubMenu = control.subMenu;
						break;
					}
				}

				if (foundSubMenu == null)
					return null;

				currentMenu = foundSubMenu;
			}

			return currentMenu;
		}

		protected ChildMotion[] CreateChildMotions(string motionName, string motionPath) {
			AnimationClip clip1 = new() { name = $"{motionName}_OFF" };
			var offCurve = new AnimationCurve();
			offCurve.AddKey(0f, 0f);
			clip1.SetCurve(motionPath, typeof(GameObject), "m_IsActive", offCurve);

			AnimationClip clip2 = new() { name = $"{motionName}_ON" };
			var onCurve = new AnimationCurve();
			onCurve.AddKey(0f, 1f);
			clip2.SetCurve(motionPath, typeof(GameObject), "m_IsActive", onCurve);

			AssetDatabase.AddObjectToAsset(clip1, AssetContainer ? AssetContainer : paryi_FX);
			AssetDatabase.AddObjectToAsset(clip2, AssetContainer ? AssetContainer : paryi_FX);
			AssetDatabase.SaveAssets();

			var childMotions = new ChildMotion[]
			{
				new() {
					motion = clip1,
					threshold = 0.0f,
					timeScale = 1,
				},
				new() {
					motion = clip2,
					threshold = 1.0f,
					timeScale = 1,
				},
			};
			return childMotions;
		}

		public static bool CreateDuplicateBSKey(
			SkinnedMeshRenderer smr,
			string fromKey,
			string toKey,
			out Mesh newMesh,
			float ratio = 1f,
			params string[] additionalCheckKeys
		) {
			var mesh = smr.sharedMesh;
			if (mesh == null) {
				newMesh = null;
				return false;
			}

			int targetIndex = -1;
			for (int i = 0; i < mesh.blendShapeCount; i++) {
				if (mesh.GetBlendShapeName(i) == fromKey) {
					targetIndex = i;
					break;
				}
			}
			if (targetIndex == -1) {
				newMesh = null;
				return false;
			}

			int frameCount = mesh.GetBlendShapeFrameCount(targetIndex);

			bool alreadyExists = false;
			for (int i = 0; i < mesh.blendShapeCount; i++) {
				if (additionalCheckKeys.Contains(mesh.GetBlendShapeName(i))) {
					alreadyExists = true;
					break;
				}
			}
			if (alreadyExists) {
				newMesh = null;
				return false;
			}

			newMesh = Instantiate(mesh);
			var deltaVerts = new Vector3[newMesh.vertexCount];
			var deltaNormals = new Vector3[newMesh.vertexCount];
			var deltaTangents = new Vector3[newMesh.vertexCount];

			for (int f = 0; f < frameCount; f++) {
				newMesh.GetBlendShapeFrameVertices(targetIndex, f, deltaVerts, deltaNormals, deltaTangents);
				for (int v = 0; v < deltaVerts.Length; v++) {
					deltaVerts[v] *= ratio;
					deltaNormals[v] *= ratio;
					deltaTangents[v] = new Vector3(deltaTangents[v].x * ratio, deltaTangents[v].y * ratio, deltaTangents[v].z * ratio);
				}

				float originalWeight = newMesh.GetBlendShapeFrameWeight(targetIndex, f);

				newMesh.AddBlendShapeFrame(toKey, originalWeight, deltaVerts, deltaNormals, deltaTangents);
			}

			smr.sharedMesh = newMesh;
			return true;
		}

		public Mesh GetOriginalMeshFromPrefab(string part, string prefabGuid) {
			GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>(AssetDatabase.GUIDToAssetPath(prefabGuid));
			if (prefab != null) {
				Transform partTransform = prefab.transform.Find(part);
				if (partTransform != null) {
					SkinnedMeshRenderer smr = partTransform.GetComponent<SkinnedMeshRenderer>();
					if (smr != null && smr.sharedMesh != null) {
						return smr.sharedMesh;
					}
				}
			}
			return null;
		}

	}
}
