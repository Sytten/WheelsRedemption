using UnityEngine;

public class InputManager : MonoBehaviour {

    public static readonly InputEvent DEFAULT_INPUT_EVENT = InputEventTranslator.toEvent(new Touch());
    public static readonly int DEFAULT_FINGER_ID = -1000;

#pragma warning disable 0414
    private int fingerId = DEFAULT_FINGER_ID;
    private SubscriberComponent<InputEvent> inputSubscriber = null;

    private void Update() {

#if UNITY_EDITOR
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
#elif UNITY_ANDROID
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
#endif
    }

    private SubscriberComponent<InputEvent> tryToGetInputEventReceiver(Vector2 position) {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(position), Vector2.zero);

        if (hit) {
            GameObject gameObject = hit.collider.gameObject;
            return gameObject.GetComponent<SubscriberComponent<InputEvent>>();
        }

        return null;
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
