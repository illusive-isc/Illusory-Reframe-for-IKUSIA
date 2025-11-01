using System.Collections.Generic;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA.Rurune {
	internal class Closet : Base {
		internal override List<string> GetParameters() =>
			new() { "accesary", "boots", "Cloth", "Glove", "jacket", "socks", "string", "AllOff" };

		internal override List<string> GetMenuPath() => new() { "closet", "cloth" };

		internal override void ChangeObj(params string[] delPath) {
			SetWeight(
				avatarRoot.Find("underwear"),
				"bra_off",
				((RuruneReframe)reframe).JacketFlg || ((RuruneReframe)reframe).ClothFlg ? 0 : 100
			);
			SetWeight(
				avatarRoot.Find("underwear"),
				"string_off",
				((RuruneReframe)reframe).ClothFlg4 ? 100 : 0
			);
			SetWeight(
				avatarRoot.Find("jacket"),
				"tail_off",
				((RuruneReframe)reframe).TailFlg ? 100 : 0
			);
			SetWeight(
				avatarRoot.Find("cloth"),
				"jacket_on",
				((RuruneReframe)reframe).JacketFlg ? 0 : 100
			);
			SetWeight(
				avatarRoot.Find("cloth"),
				"tail_off",
				((RuruneReframe)reframe).TailDelFlg ? 100 : 0
			);
			SetWeight(
				avatarRoot.Find("acce"),
				"cloth_off",
				((RuruneReframe)reframe).ClothFlg ? 100 : 0
			);
			SetWeight(
				avatarRoot.Find("acce"),
				"skirt",
				((RuruneReframe)reframe).ClothFlg ? 100 : 0
			);
			SetWeight(
				avatarRoot.Find("acce"),
				"tail_off",
				((RuruneReframe)reframe).TailDelFlg ? 100 : 0
			);
		}
	}
}
