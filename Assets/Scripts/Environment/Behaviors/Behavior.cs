using UnityEngine;
using System.Collections;

public abstract class Behavior : MonoBehaviour {

    public virtual void Execute(OnPlatformState state) {
        Execute ((IState)state);
    }

	public abstract void Execute(IState state);
}
