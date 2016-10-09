using UnityEngine;

public class Hero : MonoBehaviour {

    public State onPlatformState { get; private set; }
    public State inAirState { get; private set; }
    public State onWheelState { get; private set; }

    private State currentState;

    public void ChangeState(State newState) {
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