using UnityEngine;
using System.Collections;

public class WallBehavior : Behavior {

	public override void Execute(OnPlatformState state) {
		state.ChangeHeroDirection();
	}

}
