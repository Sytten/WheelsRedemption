using UnityEngine;
using System.Collections;

public class StickyWheelBehavior : Behavior {

    public override void Execute(InAirState state) {
            state.AttachHeroToLastCollision();
    }

}
