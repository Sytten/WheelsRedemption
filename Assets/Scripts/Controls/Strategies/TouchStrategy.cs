using UnityEngine;

class TouchStrategy : InputStrategy {

    private static readonly int DEFAULT_FINGER_ID = -1000;

    private int fingerId = DEFAULT_FINGER_ID;

    public override void Update() {
        if (fingerId == DEFAULT_FINGER_ID) {
            foreach (Touch touch in Input.touches) {
                if (touch.phase == TouchPhase.Began) {
                    fingerId = touch.fingerId;

                    inputSubscriber = tryToGetInputEventReceiver(touch.position);

                    if (inputSubscriber != null) {
                        inputSubscriber.Handle(InputEventTranslator.toEvent(touch));
                    } else {
                        EventManager.Publish(DEFAULT_INPUT_EVENT);
                    }
                }
            }
        } else if (touchHasEnded(fingerId)) {
            if (inputSubscriber != null) {
                inputSubscriber.Handle(new InputEvent().WithPosition(Input.mousePosition).WithPhase(TouchPhase.Ended));
                inputSubscriber = null;
            }
            fingerId = DEFAULT_FINGER_ID;
        }
    }

    private bool touchHasEnded(int fingerId) {
        foreach (Touch touch in Input.touches) {
            if (touch.fingerId == fingerId && touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled) {
                return false;
            }
        }
        return true;
    }
}