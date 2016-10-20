using UnityEngine;

public class InputEvent : IEvent {

    private Touch touch;

    public Touch getTouch() {
        return touch;
    }

    public void setTouch(Touch touch) {
        this.touch = touch;
    }

    public InputEvent withTouch(Touch touch) {
        setTouch(touch);
        return this;
    }
}
