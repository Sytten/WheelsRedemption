using UnityEngine;

public class InputEvent : IEvent {

    private Vector2 position;
    private TouchPhase phase;

    public Vector2 GetWorldPosition() {
        return Camera.main.ScreenToWorldPoint(position);
    }

    public Vector2 GetPosition() {
        return position;
    }

    public TouchPhase GetPhase() {
        return phase;
    }

    public void SetPosition(Vector2 position) {
        this.position = position;
    }

    public void SetPhase(TouchPhase phase) {
        this.phase = phase;
    }

    public InputEvent WithPosition(Vector2 position) {
        SetPosition(position);
        return this;
    }

    public InputEvent WithPhase(TouchPhase phase) {
        SetPhase(phase);
        return this;
    }
}
