using UnityEditor;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA.Ririka {
	internal partial class RirikaReframeEditor : ReframeEditor {
		static bool isExecuting = false;
		SerializedProperty colorFlg0;
		SerializedProperty colorFlg1;
		SerializedProperty colorFlg2;
		SerializedProperty ClothFlg0;
		SerializedProperty ClothFlg;
		SerializedProperty ClothFlg1;
		SerializedProperty ClothFlg2;
		SerializedProperty ClothFlg3;
		SerializedProperty ClothFlg4;
		SerializedProperty ClothFlg5;
		SerializedProperty ClothFlg6;
		SerializedProperty ClothFlg7;
		SerializedProperty ClothFlg8;
		SerializedProperty ClothFlg9;
		SerializedProperty ClothFlg10;
		SerializedProperty heelFlg1;
		SerializedProperty heelFlg2;
		SerializedProperty AccessoryFlg0;
		SerializedProperty AccessoryFlg1;
		SerializedProperty AccessoryFlg2;
		SerializedProperty AccessoryFlg3;
		SerializedProperty AccessoryFlg4;
		SerializedProperty HairFlg0;
		SerializedProperty HairFlg1;
		SerializedProperty HairFlg2;
		SerializedProperty HairFlg3;
		SerializedProperty HairFlg4;
		SerializedProperty HairFlg5;
		SerializedProperty HairFlg6;
		SerializedProperty HairFlg7;
		SerializedProperty HairFlg8;
		SerializedProperty HairFlg;
		SerializedProperty petScale;
		SerializedProperty petFlg;
		SerializedProperty TPSFlg;
		SerializedProperty ClairvoyanceFlg;
		SerializedProperty phoneFlg;
		SerializedProperty phoneFlg1;
		SerializedProperty ColliderFlg;
		SerializedProperty BreastSizeFlg;
		SerializedProperty BreastSizeFlg2;
		SerializedProperty backlightFlg;
		SerializedProperty WhiteBreathFlg;
		SerializedProperty EightBitFlg;
		SerializedProperty PenCtrlFlg;
		SerializedProperty HeartGunFlg;

		// SerializedProperty FaceGestureFlg;
		SerializedProperty FaceLockFlg;
		SerializedProperty FaceValFlg;
		SerializedProperty blinkFlg;
		SerializedProperty kamitukiFlg;
		SerializedProperty nadeFlg;
		SerializedProperty candyFlg;
		SerializedProperty drinkFlg;
		SerializedProperty doughnutFlg;
		SerializedProperty gamFlg;
		SerializedProperty teppekiFlg;
		SerializedProperty handHeartFlg;
		SerializedProperty noisepanelFlg;
		SerializedProperty neonFlg;
		SerializedProperty mesugakiFaceFlg;
		SerializedProperty mesugakiFaceFlg1;
		SerializedProperty questFlg1;

		private void OnEnable() {
			AutoInitializeSerializedProperties(this);
		}
	}
}
