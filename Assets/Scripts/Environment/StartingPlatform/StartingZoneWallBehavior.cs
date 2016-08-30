using UnityEngine;
using System.Collections;

public class StartingZoneWallBehavior : DefaultStartingZoneBehavior {

	public override void Behavior(OnStartingPlatformState state) {
        state.speed *= -1;
	}
}
