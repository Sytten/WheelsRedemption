using UnityEngine;
using System.Collections;

public class WheelBehavior : Behavior {

    public override void Execute(InAirState state) {
        state.AttachHeroToLastCollision();
    }

}
