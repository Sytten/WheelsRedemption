using UnityEngine;
using System.Collections;

public class PlatformBehavior : Behavior {

    public override void Execute(InAirState state) {
        state.LandHeroOnPlatform();
    }
}