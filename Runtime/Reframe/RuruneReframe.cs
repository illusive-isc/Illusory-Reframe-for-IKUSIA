using UnityEngine;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA {
	[AddComponentMenu("ILLUSORY OVERRIDE/IllusoryReframe/RuruneReframe")]
	public class RuruneReframe : ReframeRuntime {
		public bool Zapu_nFlg;
		public bool StatusFlg = true;
		public bool StatusActiveFlg;
		public bool FaceEffectFlg = true;
		public bool JointBallFlg = true;
		public bool JointBallActiveFlg;
		public bool heelFlg1;

		public bool heelFlg2;

		[SerializeField]
		private bool ClosetFlg;

		[SerializeField]
		private bool ClosetDelFlg;

		public bool JacketFlg;

		public bool ClothFlg;

		public bool AcceFlg;

		public bool ClothFlg4;

		[SerializeField]
		private bool GloveFlg;

		[SerializeField]
		private bool SocksFlg;

		[SerializeField]
		private bool BootsFlg;

		[SerializeField]
		private bool UnderwearFlg;

		[SerializeField]
		private bool BreastSizeFlg;

		public bool BreastSizeFlg1;

		public bool BreastSizeFlg2;

		public bool BreastSizeFlg3;

		[SerializeField]
		private bool HairFlg;

		public bool HairFlg10;

		public bool HairFlg11;

		public bool HairFlg12;

		public bool HairFlg20;

		public bool HairFlg22;

		public bool HairFlg30;

		public bool HairFlg40;

		public bool HairFlg50;

		public bool HairFlg51;

		public bool HairFlg60;

		public bool TailFlg = true;
		public bool TailDelFlg;
		public bool TailGizaFlg = true;

		[SerializeField]
		private bool TailRibbonFlg;

		[SerializeField]
		private bool PetFlg;

		public bool TPSFlg;

		public bool ClairvoyanceFlg;

		public bool ColliderFlg;

		[SerializeField]
		private bool PictureFlg;

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

		[SerializeField]
		private bool WhiteBreathFlg;

		[SerializeField]
		private bool BubbleBreathFlg;

		[SerializeField]
		private bool WaterStampFlg;

		[SerializeField]
		private bool EightBitFlg;

		[SerializeField]
		private bool PenCtrlFlg;

		public bool HeartGunFlg;

		[SerializeField]
		private bool FaceGestureFlg;

		public bool FaceGestureFlg2;

		public bool FaceLockFlg;

		public bool FaceValFlg;
		public bool blinkFlg;
		public bool blinkDelFlg;

		public bool kamitukiFlg;

		public bool nadeFlg;

		[SerializeField]
		private bool FaceContactFlg;

		public bool IKUSIA_emote1;

		public bool Skirt_Root;

		public bool Breast;

		public bool backhair;

		public bool back_side_root;

		public bool Head_002;

		public bool Front_hair2_root;

		public bool side_1_root;

		public bool hair_2;

		public bool sidehair;

		public bool side_3_root;

		public bool Side_root;

		public bool tail_044;

		public bool tail_022;

		[SerializeField]
		private bool tail_024;

		public bool chest_collider1;

		public bool chest_collider2;

		public bool upperleg_collider1;

		public bool upperleg_collider2;

		public bool upperleg_collider3;

		public bool upperArm_collider;

		public bool head_collider1;

		public bool head_collider2;

		public bool Breast_collider;

		public bool plane_collider;

		public bool plane_tail_collider;
		public bool particle_headphone = true;
	}
}
