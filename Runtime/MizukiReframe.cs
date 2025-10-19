using UnityEngine;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA
{
    [AddComponentMenu("MizukiReframe")]
    public class MizukiReframe : ReframeAbstract
    {
        [SerializeField]
        private bool ClothFlg = false;

        [SerializeField]
        private bool ClothDelFlg = false;
        public bool ClothDelFlg2 = false;

        public bool ArmAcceFlg2 = false;

        [SerializeField]
        private bool StatusFlg = false;

        public bool heelFlg1 = true;

        public bool heelFlg2 = false;
        public bool HeelFlg = false;

        [SerializeField]
        private bool FreeClothFlg = false;

        public bool TPSFlg = false;

        public bool ClairvoyanceFlg = false;

        [SerializeField]
        private bool JointBallFlg = false;

        [SerializeField]
        private bool TeleportFlg = false;

        [SerializeField]
        private bool FaceEffectFlg = false;

        [SerializeField]
        private bool FreeObjFlg = false;

        [SerializeField]
        private bool NailGaoFlg = false;

        public bool NailGaoFlg2 = false;

        [SerializeField]
        private bool ArmAcceFlg = false;

        [SerializeField]
        private bool BeltFlg = false;
        public bool BeltFlg2 = false;
        public bool LegBeltFlg2 = false;
        public bool OuterFlg2 = false;
        public bool ShoesFlg2 = false;

        [SerializeField]
        private bool LegBeltFlg = false;

        [SerializeField]
        private bool OuterFlg = false;

        [SerializeField]
        private bool ShoesFlg = false;

        [SerializeField]
        private bool AvatarLightFlg = false;

        [SerializeField]
        private bool ColliderFlg = false;

        [SerializeField]
        private bool PictureFlg = false;

        [SerializeField]
        private bool HairFlg = false;

        [SerializeField]
        private bool CameraPictureFlg = false;

        [SerializeField]
        private bool BreastSizeFlg = false;
        public bool BreastSizeFlg1 = false;
        public bool BreastSizeFlg2 = false;
        public bool BreastSizeFlg3 = true;

        [SerializeField]
        private bool LightGunFlg = false;

        [SerializeField]
        private bool WhiteBreathFlg = false;

        [SerializeField]
        private bool FreeGimmickFlg = false;

        [SerializeField]
        private bool DrinkFlg = false;

        [SerializeField]
        private bool IssyouFlg = false;

        [SerializeField]
        private bool HelpFlg = false;

        [SerializeField]
        private bool FootStampFlg = false;

        [SerializeField]
        private bool EightBitFlg = false;

        [SerializeField]
        private bool PenCtrlFlg = false;

        public bool FreeParticleFlg = false;
        public bool HandTrailFlg = false;
        public bool NailTrailFlg = false;

        public bool FaceGestureFlg = false;
        public bool FaceGestureFlg2 = false;

        public bool FaceLockFlg = false;

        public bool FaceValFlg = false;

        public bool kamitukiFlg = false;
        public bool FaceContactFlg = false;

        public bool nadeFlg = false;

        public bool blinkFlg = false;

        public bool AccesaryFlg = false;
        public bool AccesaryFlg2 = false;

        public bool EarAngryFlg = false;

        public bool EarTailFlg = false;
        public bool EarTailFlg2 = false;

        public bool ElfEarFlg = false;
        public bool ElfEarFlg2 = false;

        public bool EyemaskFlg = false;
        public bool EyemaskFlg2 = false;

        public bool FronthairLeftFlg = false;

        public bool FronthairRightFlg = false;

        public bool HeadDressFlg = false;
        public bool HeadDressFlg2 = false;
        public bool MenuFlg = false;
        public bool FreeMenuFlg = false;

        public bool Butt;
        public bool Skirt_Root;
        public bool Breast;
        public bool Cheek;
        public bool ahoge;
        public bool Backhair;
        public bool Front;
        public bool Frontside;
        public bool side;
        public bool headband_Root;
        public bool tang;
        public bool TigerEar;
        public bool Shoulder_Ribbon;
        public bool coat_hand;
        public bool Hand_frills;
        public bool tail;
        public bool Leg_frills;

        public bool Upperleg_collider1;
        public bool Upperleg_collider2;
        public bool Chest_collider;
        public bool Butt_collider;
        public bool UpperArm_collider1;
        public bool UpperArm_collider2;
        public bool Shoulder_collider;
    }
}
