using UnityEngine;
using System.Collections;

public abstract class Behavior : MonoBehaviour {

	public abstract void Execute(OnPlatformState state);

	public abstract void Execute(IState state);
}
