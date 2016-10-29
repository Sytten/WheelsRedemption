using UnityEngine;

class MouseStrategy : InputStrategy {

    public override void Update() {
        if (Input.GetMouseButtonDown(0)) {
            inputSubscriber = SubscriberFinder.tryToGetEventSubscriber<InputEvent>(Input.mousePosition);

            if (inputSubscriber != null) {
                inputSubscriber.Handle(new InputEvent().WithPosition(Input.mousePosition).WithPhase(TouchPhase.Began));
            } else {
                EventManager.Publish(DEFAULT_INPUT_EVENT);
            }
        } else if (Input.GetMouseButtonUp(0) && inputSubscriber != null) {
            inputSubscriber.Handle(new InputEvent().WithPosition(Input.mousePosition).WithPhase(TouchPhase.Ended));
            inputSubscriber = null;
        }
    }
}