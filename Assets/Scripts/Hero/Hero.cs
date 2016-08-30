using UnityEngine;
using System.Collections;

public class Hero : MonoBehaviour {

    private State currentState;

    public void ChangeState(State newState) {
        currentState = newState;
        newState.Start();
    }

    public void Jump(float jumpPower) {
        currentState.Jump(jumpPower);
    }

	private void Start() {
        currentState = new OnStartingPlatformState(this);
        currentState.Start();
	}

	private void Update() {
        currentState.Update();
	}

	private void OnCollisionEnter2D(Collision2D collision) {
        currentState.OnCollisionEnter2D(collision);
	}

    private void OnCollisionStay2D(Collision2D collision) {
        currentState.OnCollisionStay2D(collision);
    }
}
