using System.Collections.Generic;
using System.Linq;
using UnityEditor.Animations;
using UnityEngine;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA.Ririka {
	internal class Sleeve : Base {
		internal override void ChangeObj(params string[] delPath) {
			if (((RirikaReframe)reframe).SleeveFlg)
				if (avatarRoot.Find("Cloth") is Transform Cloth)
					SetWeight(Cloth.GetComponent<SkinnedMeshRenderer>(), "Sleeve_off", 100);
		}
	}
}