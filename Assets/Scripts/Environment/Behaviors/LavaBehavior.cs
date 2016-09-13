using UnityEngine;
using System.Collections;

public class LavaBehavior : Behavior {

    public override void Execute(IState state) {
        state.KillHero ();
    }
}
