namespace jp.illusive_isc.IllusoryReframe.IKUSIA.Ririka {
	internal class Constraint : Base {

		internal override void ChangeObj(params string[] delPath) {
			if (((RirikaReframe)reframe).CanDrinkFlg
				&& ((RirikaReframe)reframe).DoughnutFlg
				&& ((RirikaReframe)reframe).PhoneFlg
				&& ((RirikaReframe)reframe).PenCtrlFlg
				&& ((RirikaReframe)reframe).HeartGunFlg)
				base.ChangeObj("Advanced/Constraint/Hand_L_Constraint0");
			if (((RirikaReframe)reframe).DoughnutFlg
				&& ((RirikaReframe)reframe).PenCtrlFlg
				&& ((RirikaReframe)reframe).HeartGunFlg)
				base.ChangeObj("Advanced/Constraint/Hand_R_Constraint0");
		}
	}
}