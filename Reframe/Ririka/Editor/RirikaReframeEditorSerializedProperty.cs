using UnityEditor;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA.Ririka {
	internal partial class RirikaReframeEditor : ReframeEditor {
		static bool isExecuting = false;
		SerializedProperty colorFlg0;
		SerializedProperty colorFlg1;
		SerializedProperty colorFlg2;
		SerializedProperty ClosetFlg;
		SerializedProperty ClothDelFlg;
		SerializedProperty OuterFlg;
		SerializedProperty BagFlg;
		SerializedProperty SleeveFlg;
		SerializedProperty TailFlg;
		SerializedProperty CoverArmFlg;
		SerializedProperty ClothFlg;
		SerializedProperty OverKneeSocksFlg;
		SerializedProperty BootsFlg;
		SerializedProperty BraFlg;
		SerializedProperty AnotherClothFlg;
		SerializedProperty heelFlg1;
		SerializedProperty heelFlg2;
		SerializedProperty AccessoryFlg;
		SerializedProperty AccessoryFlg1;
		SerializedProperty AccessoryFlg2;
		SerializedProperty AccessoryFlg3;
		SerializedProperty AccessoryFlg4;
		SerializedProperty AccessoryFlg5;
		SerializedProperty AccessoryDelFlg;
		SerializedProperty HairFlg;
		SerializedProperty HairFlg1;
		SerializedProperty HairFlg2;
		SerializedProperty HairFlg3;
		SerializedProperty HairFlg4;
		SerializedProperty HairFlg5;
		SerializedProperty HairFlg6;
		SerializedProperty HairFlg7;
		SerializedProperty HairFlg8;
		SerializedProperty HairDelFlg;
		SerializedProperty petScale;
		SerializedProperty PetFlg;
		SerializedProperty TPSFlg;
		SerializedProperty ClairvoyanceFlg;
		SerializedProperty PhoneFlg;
		SerializedProperty phoneFlg1;
		SerializedProperty ColliderFlg;
		SerializedProperty BreastSizeFlg;
		SerializedProperty BreastSizeFlg1;
		SerializedProperty BacklightFlg;
		SerializedProperty WhiteBreathFlg;
		SerializedProperty EightBitFlg;
		SerializedProperty PenCtrlFlg;
		SerializedProperty HeartGunFlg;
		SerializedProperty FaceContactFlg;

		SerializedProperty FaceGestureFlg;
		SerializedProperty FaceGestureFlg2;
		SerializedProperty blinkDelFlg;
		SerializedProperty FaceLockFlg;
		SerializedProperty FaceValFlg;
		SerializedProperty blinkFlg;
		SerializedProperty kamitukiFlg;
		SerializedProperty nadeFlg;
		SerializedProperty CandyFlg;
		SerializedProperty CanDrinkFlg;
		SerializedProperty DoughnutFlg;
		SerializedProperty GamFlg;
		SerializedProperty TeppekiFlg;
		SerializedProperty HandheartFlg;
		SerializedProperty NoisepanelFlg;
		SerializedProperty NeonFlg;
		SerializedProperty MesugakiFaceFlg;


		SerializedProperty IKUSIA_emote2;
		SerializedProperty questFlg1;

		private void OnEnable() {
			AutoInitializeSerializedProperties(this);
		}
	}
}
