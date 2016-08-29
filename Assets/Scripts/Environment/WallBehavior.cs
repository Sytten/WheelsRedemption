using UnityEngine;
using System.Collections;

public class WallBehavior : DefaultBehavior {

	public override void HeroBehavior(Hero hero) {
		hero.speed *= -1;
	}
}
