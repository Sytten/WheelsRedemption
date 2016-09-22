using UnityEngine;
using System.Collections;

public class FinishPlatformBehavior : Behavior {

    public override void Execute (InAirState state)
    {
        Execute ((IState)state);
    }

    public override void Execute(IState state) {
        LevelManager.RestartScene ();
    }
}
