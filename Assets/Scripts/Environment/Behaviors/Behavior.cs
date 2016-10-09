using UnityEngine;

public abstract class Behavior : MonoBehaviour {

    public virtual void Execute(OnPlatformState state) {
        Execute((State) state);
    }

    public virtual void Execute(InAirState state) {
        Execute((State) state);
    }

    public virtual void Execute(OnWheelState state) {
        Execute((State) state);
    }

    public virtual void Execute(State state) {
    }
}