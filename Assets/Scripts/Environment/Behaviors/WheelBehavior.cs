using UnityEngine;
using System.Collections;

public class WheelBehavior : Behavior {

    public bool isSticky = true;

    public override void Execute(InAirState state) {
        if(isSticky) {
            state.AttachHeroToLastCollision();
        }
    }

}
