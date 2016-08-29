using UnityEngine;
using System.Collections;

public class WallBehavior : DefaultBehavior {

	public override void HeroBehavior(GameObject obj) {
		Debug.Log ("Hero made contact with wall!");
	}
}
