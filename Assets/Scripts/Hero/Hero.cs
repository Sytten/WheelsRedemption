using UnityEngine;

public class Hero : MonoBehaviour, IEventSubscriber<InputEvent> {

    public State onPlatformState { get; private set; }
    public State inAirState { get; private set; }
    public State onWheelState { get; private set; }

    private State currentState;

    public void ChangeState(State newState) {
        currentState = newState;
        currentState.Start();
    }

    private void Start() {
        EventManager.Subscribe<InputEvent>(this);

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

    private void OnDestroy() {
        EventManager.UnSubscribe<InputEvent>(this);
    }

    public void Handle(InputEvent data) {
        if (data.Equals(InputStrategy.DEFAULT_INPUT_EVENT) || heroWasPressed(data)) {
            currentState.Jump();
        }
    }

    private bool heroWasPressed(InputEvent data) {
        if (gameObject.GetComponent<Collider2D>().bounds.Contains(data.GetWorldPosition()) && data.GetPhase() == TouchPhase.Began) {
            return true;
        }
        return false;
    }
}