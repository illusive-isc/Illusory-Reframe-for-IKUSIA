using System.Collections.Generic;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA.Mizuki {
	internal class FreeObj : Base {
		internal override List<string> GetParameters() =>
			new() {
				"OBJ8_1",
				"OBJ8_2",
				"OBJ8_3",
				"OBJ8_4",
				"OBJ8_5",
				"OBJ8_6",
				"OBJ8_7",
				"OBJ8_8",
			};

		internal override List<string> GetMenuPath() => new() { "Object", "Object Free" };

		internal override List<string> GetDelPath() => new() { "Object" };
	}
}
