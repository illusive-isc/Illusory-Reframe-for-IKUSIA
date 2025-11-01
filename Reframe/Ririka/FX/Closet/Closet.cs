using System.Collections.Generic;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA.Ririka {
	internal class Closet : Base {
		internal override List<string> GetParameters() =>
			new() { "accesary", "boots", "Cloth", "Glove", "jacket", "socks", "string", "AllOff" };

		internal override List<string> GetMenuPath() => new() { "closet", "cloth" };

		internal override void ChangeObj(params string[] delPath) {
			// SetWeight(
			// 	avatarRoot.Find("underwear"),
			// 	"bra_off",
			// 	((RirikaReframe)reframe).JacketFlg || ((RirikaReframe)reframe).ClothFlg ? 0 : 100
			// );
			// SetWeight(
			// 	avatarRoot.Find("underwear"),
			// 	"string_off",
			// 	((RirikaReframe)reframe).ClothFlg4 ? 100 : 0
			// );
			// SetWeight(
			// 	avatarRoot.Find("jacket"),
			// 	"tail_off",
			// 	((RirikaReframe)reframe).TailFlg ? 100 : 0
			// );
			// SetWeight(
			// 	avatarRoot.Find("cloth"),
			// 	"jacket_on",
			// 	((RirikaReframe)reframe).JacketFlg ? 0 : 100
			// );
			// SetWeight(
			// 	avatarRoot.Find("cloth"),
			// 	"tail_off",
			// 	((RirikaReframe)reframe).TailDelFlg ? 100 : 0
			// );
			// SetWeight(
			// 	avatarRoot.Find("acce"),
			// 	"cloth_off",
			// 	((RirikaReframe)reframe).ClothFlg ? 100 : 0
			// );
			// SetWeight(
			// 	avatarRoot.Find("acce"),
			// 	"skirt",
			// 	((RirikaReframe)reframe).ClothFlg ? 100 : 0
			// );
			// SetWeight(
			// 	avatarRoot.Find("acce"),
			// 	"tail_off",
			// 	((RirikaReframe)reframe).TailDelFlg ? 100 : 0
			// );
		}
	}
}
