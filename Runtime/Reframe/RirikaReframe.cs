using UnityEngine;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA {
	[AddComponentMenu("ILLUSORY OVERRIDE/IllusoryReframe/RirikaReframe")]
	public class RirikaReframe : ReframeRuntime {
		public bool colorFlg0 = false;

		public bool colorFlg1 = false;

		public bool colorFlg2 = false;

		public bool heelFlg1 = false;

		public bool heelFlg2 = false;

		public bool ClothFlg = false;

		public bool ClothFlg0 = false;

		public bool ClothFlg1 = false;

		public bool ClothFlg2 = false;

		public bool ClothFlg3 = false;

		public bool ClothFlg4 = false;

		public bool ClothFlg5 = false;

		public bool ClothFlg6 = false;

		public bool ClothFlg7 = false;

		public bool ClothFlg8 = false;

		public bool ClothFlg9 = false;

		public bool ClothFlg10 = false;

		[SerializeField]
		private bool AccessoryFlg0 = false;

		public bool AccessoryFlg1 = false;

		public bool AccessoryFlg2 = false;

		public bool AccessoryFlg3 = false;

		public bool AccessoryFlg4 = false;

		[SerializeField]
		private bool HairFlg0 = false;

		public bool HairFlg1 = false;

		public bool HairFlg2 = false;

		public bool HairFlg3 = false;

		public bool HairFlg4 = false;

		public bool HairFlg5 = false;

		public bool HairFlg6 = false;

		public bool HairFlg7 = false;

		public bool HairFlg8 = false;

		public bool HairFlg = false;

		[SerializeField]
		private float petScale = 1.0f;

		[SerializeField]
		private bool petFlg = false;

		public bool TPSFlg = false;

		public bool ClairvoyanceFlg = false;

		[SerializeField]
		private bool phoneFlg = false;

		[SerializeField]
		private bool phoneFlg1 = false;

		public bool ColliderFlg = false;

		[SerializeField]
		private bool teppekiFlg = false;

		[SerializeField]
		private bool handHeartFlg = false;

		[SerializeField]
		private bool noisepanelFlg = false;

		[SerializeField]
		private bool neonFlg = false;

		[SerializeField]
		private bool mesugakiFaceFlg = false;

		[SerializeField]
		private bool mesugakiFaceFlg1 = false;

		[SerializeField]
		private bool BreastSizeFlg = false;

		public bool BreastSizeFlg2 = false;

		[SerializeField]
		private bool WhiteBreathFlg = false;

		[SerializeField]
		private bool EightBitFlg = false;

		[SerializeField]
		private bool PenCtrlFlg = false;

		public bool HeartGunFlg = false;

		public bool FaceGestureFlg = false;

		public bool FaceLockFlg = false;

		public bool FaceValFlg = false;

		public bool blinkFlg = false;

		public bool kamitukiFlg = false;

		public bool nadeFlg = false;

		[SerializeField]
		private bool candyFlg = false;

		[SerializeField]
		private bool doughnutFlg = false;

		[SerializeField]
		private bool drinkFlg = false;

		[SerializeField]
		private bool gamFlg = false;

		[SerializeField]
		private bool backlightFlg;

		public bool Butt;
		public bool Breast;
		public bool acce_wing;
		public bool earring;
		public bool Leg_acce;
		public bool bob;
		public bool bobtwin;
		public bool front_root;
		public bool twintail;
		public bool stomach;
		public bool side_root;
		public bool ribbon;
		public bool frill;
		public bool bag;
		public bool nuigurumi;
		public bool long_hair;
		public bool tail;
		public bool bag_wing;
		public bool bag_ribbon;
		public bool Cloth;

		public bool upperArm_collider1;
		public bool upperArm_collider2;
		public bool upperArm_collider3;
		public bool upperArm_collider4;
		public bool upperArm_collider5;
		public bool upperArm_collider6;
		public bool upperArm_collider7;

		public bool chest_collider1;
		public bool chest_collider2;

		public bool hip_collider1;
		public bool hip_collider2;
		public bool hip_collider3;

		public bool upperleg_collider1;
		public bool upperleg_collider2;
		public bool upperleg_collider3;
		public bool plane_collider;

		[SerializeField]
		private bool LightGunFlg;

		[SerializeField]
		private bool LightGunColorFlg = true;

		public LightGunOption lightGun = LightGunOption.LightColor0;

		public enum LightGunOption {
			LightColor0, // デフォ色
			LightColor1, // 黄色
			LightColor2, // 赤色
			LightColor3, // ピンク色
			LightColor4, // 紫色
			LightColor5, // 青色
			LightColor6, // 水色
			LightColor7, // 水色と緑色の中間色
			LightColor8, // 緑色
			LightColor9, // 黄緑色
			LightColor10, // 黄色
		}

		[SerializeField]
		private bool PenColorFlg = true;
		public PenColorOption PenColor1 = PenColorOption.PenColor1;

		public PenColorOption PenColor2 = PenColorOption.PenColor1;

		public enum PenColorOption {
			PenColor1, // 黄色
			PenColor2, // 赤色
			PenColor3, // ピンク色
			PenColor4, // 紫色
			PenColor5, // 青色
			PenColor6, // 水色
			PenColor7, // 水色と緑色の中間色
			PenColor8, // 緑色
			PenColor9, // 黄緑色
			PenColor10, // 黄色
			PenColor11, // 黄色
			PenColor12, // 黄色
			PenColor13, // 黄色
			PenColor14, // 黄色
			PenColor15, // 黄色
			PenColor16, // 黄色
			PenColor17, // 黄色
			PenColor18, // 黄色
		}
	}
}
