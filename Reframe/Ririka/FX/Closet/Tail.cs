using System.Collections.Generic;
using UnityEngine;
using VRC.Dynamics;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA.Ririka {
	internal class Tail : Base {

		internal override List<string> GetDelPath() => new() { "Tail", "Advanced/Ground", "Armature/Hips/tail/tail.001/tail.002/tail.003" };

		internal override void ChangeObj(params string[] delPath) {
			base.ChangeObj(delPath);
			if (avatarRoot.Find("Armature/tail/tail.001") is Transform Tail)
				Tail.gameObject.GetComponent<VRCPhysBoneBase>().enabled = false;
		}
	}
}