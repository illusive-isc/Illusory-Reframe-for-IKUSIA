using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using VRC.SDK3.Avatars.Components;
using VRC.SDK3.Avatars.ScriptableObjects;
using UnityEditor.Animations;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA.Ririka {
	internal class Hair : Base {
		bool AccessoryFlg1;
		bool HairFlg1;
		bool HairFlg2;
		bool HairFlg3;
		bool HairFlg4;
		bool HairFlg5;
		bool HairFlg6;
		bool HairFlg7;
		bool HairFlg8;
		bool HairFlg;
		bool colorFlg0;
		internal override List<string> GetParameters() => new()
		{
			"Object1",
			"Object8",
			"Object3",
			"Object2",
			"Object4",
			"Object5",
			"Object7",
		};
		internal override List<string> GetLayers() => new() { "hair ctrl" };

		internal override List<string> GetMenuPath() => new() { "closet", "Hair" };

		internal override void InitializePlus(ReframeRuntime reframe) {
			AccessoryFlg1 = (reframe as RirikaReframe).AccessoryFlg1;
			HairFlg1 = (reframe as RirikaReframe).HairFlg1;
			HairFlg2 = (reframe as RirikaReframe).HairFlg2;
			HairFlg3 = (reframe as RirikaReframe).HairFlg3;
			HairFlg4 = (reframe as RirikaReframe).HairFlg4;
			HairFlg5 = (reframe as RirikaReframe).HairFlg5;
			HairFlg6 = (reframe as RirikaReframe).HairFlg6;
			HairFlg7 = (reframe as RirikaReframe).HairFlg7;
			HairFlg8 = (reframe as RirikaReframe).HairFlg8;
			HairFlg = (reframe as RirikaReframe).HairDelFlg;
			colorFlg0 = (reframe as RirikaReframe).colorFlg0;
		}


		internal override void ChangeFxBT(List<string> Parameters) {
			foreach (var layer in paryi_FX.layers.Where(layer => layer.name == "MainCtrlTree")) {
				foreach (var state in layer.stateMachine.states) {
					if (state.state.motion is BlendTree blendTree) {
						blendTree.children = blendTree
							.children.Where(c => c.motion.name != "Object")
							.ToArray();
					}
				}
			}
		}

		internal override void ChangeObj(params string[] delPath) {
			if (avatarRoot.Find("hair_main") is Transform hair_main) {
				SetWeight(hair_main, "front_short", HairFlg1 ? 100 : 0);
				SetWeight(hair_main, "side_off", HairFlg2 ? 0 : 100);
				SetWeight(hair_main, "twintail_on", HairFlg7 ? 100 : 0);
			}
			if (avatarRoot.Find("hair_bob") is Transform hair_bob) {
				hair_bob.gameObject.SetActive(HairFlg5);
				SetWeight(hair_bob, "bob_twin_off", HairFlg3 ? 0 : 100);
				SetWeight(hair_bob, "bob_back_short", HairFlg6 ? 100 : 0);
			}
			if (avatarRoot.Find("hair_back_long") is Transform hair_back_long) {
				hair_back_long.gameObject.SetActive(HairFlg4);
				SetWeight(hair_back_long, "back_long_twin_off", HairFlg3 ? 0 : 100);
			}
			if (avatarRoot.Find("cloth_Accessories") is Transform cloth_Accessories) {
				if (AccessoryFlg1) {
					cloth_Accessories
						.gameObject.GetComponent<SkinnedMeshRenderer>()
						.SetBlendShapeWeight(3, HairFlg2 ? 0 : 100);
					cloth_Accessories
						.gameObject.GetComponent<SkinnedMeshRenderer>()
						.SetBlendShapeWeight(4, HairFlg2 ? 0 : 100);
				}
				cloth_Accessories
					.gameObject.GetComponent<SkinnedMeshRenderer>()
					.SetBlendShapeWeight(2, HairFlg7 || HairFlg8 || HairFlg ? 100 : 0);
			}

			if (!HairFlg && HairFlg8) {
				var prefab = AssetDatabase.LoadAssetAtPath<Object>(AssetDatabase.GUIDToAssetPath("b0fb802c479d39448bd81534f28ae96c"));
				bool alreadyExists = false;
				GameObject instance = (GameObject)PrefabUtility.InstantiatePrefab(prefab);
				foreach (Transform child in avatarRoot)
					if (child.name == prefab.name) {
						alreadyExists = true;
						DestroyImmediate(instance);
						instance = child.gameObject;
						break;
					}
				if (!alreadyExists) {
					if (instance != null) {
						instance.transform.SetParent(avatarRoot, false);

						// Undo.RegisterCreatedObjectUndo(instance, "Instantiate Asset");
					}
				}
				var twin = instance.transform.Find("Backhair_twin.003");
				if (twin != null) {
					if (twin.TryGetComponent<SkinnedMeshRenderer>(out var renderer)) {
						var materials = renderer.sharedMaterials;
						materials[0] = colorFlg0
							? AssetDatabase.LoadAssetAtPath<Material>(AssetDatabase.GUIDToAssetPath("98b8fd92f51ca3643bf67a12ed2c7333"))
							: AssetDatabase.LoadAssetAtPath<Material>(AssetDatabase.GUIDToAssetPath("47af70148badc2b4bb17d0632669cd67"));
						renderer.sharedMaterials = materials;
					}
				}
			}
			if (!HairFlg)
				return;
			base.ChangeObj(
				"hair_back_long",
				"hair_bob",
				"hair_main",
				"Advanced/Hair rotation");
			if (AccessoryFlg1)
				base.ChangeObj("Armature/Hips/Spine/Chest/Neck/Head/Hair_root");
			else {
				base.ChangeObj(
					"Armature/Hips/Spine/Chest/Neck/Head/Hair_root/bob_root",
					"Armature/Hips/Spine/Chest/Neck/Head/Hair_root/front_root",
					"Armature/Hips/Spine/Chest/Neck/Head/Hair_root/long_root",
					"Armature/Hips/Spine/Chest/Neck/Head/Hair_root/twintail_root",
					"Armature/Hips/Spine/Chest/Neck/Head/Hair_root/side_hair_R/");
			}
			if((reframe as RirikaReframe).HairDelFlg)
				base.ChangeObj("Armature/Hips/Spine/Chest/Neck/Head/Hair_root");
		}
	}
}
