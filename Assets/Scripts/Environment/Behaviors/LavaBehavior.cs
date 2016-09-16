using UnityEngine;
using System.Collections;

public class LavaBehavior : Behavior {

    public override void Execute (OnPlatformState state)
    {
        Execute((IState)state);
    }

    public override void Execute (InAirState state)
    {
        Execute((IState)state);
    }

    public override void Execute(IState state) {
        state.KillHero ();
    }
}
