using UnityEditor;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA.Rurune {
	internal partial class RuruneReframeEditor : ReframeEditor {
		static bool isExecuting = false;
		SerializedProperty heelFlg1;
		SerializedProperty heelFlg2;

		SerializedProperty ClosetFlg;
		SerializedProperty ClosetDelFlg;
		SerializedProperty JacketFlg;
		SerializedProperty ClothFlg;
		SerializedProperty AcceFlg;
		SerializedProperty StringFlg;
		SerializedProperty GloveFlg;
		SerializedProperty SocksFlg;
		SerializedProperty BootsFlg;
		SerializedProperty UnderwearFlg;

		SerializedProperty BreastSizeFlg;
		SerializedProperty BreastSizeFlg1;
		SerializedProperty BreastSizeFlg2;
		SerializedProperty BreastSizeFlg3;

		SerializedProperty HairFlg;
		SerializedProperty HairFlg10;
		SerializedProperty HairFlg11;
		SerializedProperty HairFlg12;
		SerializedProperty HairFlg20;
		SerializedProperty HairFlg22;
		SerializedProperty HairFlg30;
		SerializedProperty HairFlg40;
		SerializedProperty HairFlg50;
		SerializedProperty HairFlg51;
		SerializedProperty HairFlg60;

		SerializedProperty TailDelFlg;
		SerializedProperty TailGizaFlg;
		SerializedProperty TailRibbonFlg;
		SerializedProperty PetFlg;
		SerializedProperty TPSFlg;
		SerializedProperty ClairvoyanceFlg;
		SerializedProperty ColliderFlg;

		SerializedProperty PictureFlg;
		SerializedProperty LightGunFlg;
		SerializedProperty WhiteBreathFlg;
		SerializedProperty BubbleBreathFlg;
		SerializedProperty WaterStampFlg;
		SerializedProperty EightBitFlg;
		SerializedProperty PenCtrlFlg;
		SerializedProperty HeartGunFlg;

		SerializedProperty FaceGestureFlg;
		SerializedProperty FaceGestureFlg2;
		SerializedProperty FaceLockFlg;
		SerializedProperty FaceValFlg;
		SerializedProperty blinkFlg;
		SerializedProperty blinkDelFlg;
		SerializedProperty kamitukiFlg;
		SerializedProperty nadeFlg;
		SerializedProperty FaceContactFlg;
		SerializedProperty IKUSIA_emote1;
		SerializedProperty Zapu_nFlg;
		SerializedProperty lightGun;
		SerializedProperty LightGunColorFlg;
		SerializedProperty PenColor1;
		SerializedProperty PenColor2;
		SerializedProperty PenColorFlg;
		SerializedProperty JointBallActiveFlg;
		SerializedProperty StatusActiveFlg;

		private void OnEnable() {
			AutoInitializeSerializedProperties(this);
		}
	}
}
