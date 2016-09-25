using UnityEngine;
using System.Collections;

public abstract class Behavior : MonoBehaviour {

    public virtual void Execute(OnPlatformState state) {
        Execute ((IState)state);
    }

    public virtual void Execute(InAirState state) {
        Execute ((IState)state);
    }

    public virtual void Execute(OnWheelState state) {
        Execute ((IState)state);
    }

    public virtual void Execute(IState state) {
    }
}
