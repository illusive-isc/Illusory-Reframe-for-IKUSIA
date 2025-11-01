using System.Collections.Generic;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA.Mizuki {
	internal class JointBall : Base {
		internal override List<string> GetParameters() => new() { "Gimmick1_8" };

		internal override List<string> GetMenuPath() => new() { "Gimmick", "JointBall" };

		internal override List<string> GetDelPath() => new() { "Advanced/Gimmick1/8" };
	}
}
