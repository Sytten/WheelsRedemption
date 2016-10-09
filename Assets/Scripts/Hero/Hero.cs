using UnityEngine;
using System.Collections;

public class Hero : MonoBehaviour {

    public IState onPlatformState { get; private set; }
    public IState inAirState { get; private set; }
    public IState onWheelState { get; private set; }

    private IState currentState;

    public void ChangeState(IState newState) {
        currentState = newState;
        currentState.Start();
    }

    private void Start() {
        onPlatformState = new OnPlatformState(this);
        inAirState = new InAirState(this);
        onWheelState = new OnWheelState(this);

        ChangeState(onPlatformState);
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

    private void OnTriggerEnter2D(Collider2D collider) {
        currentState.OnTriggerEnter2D(collider);
    }
}