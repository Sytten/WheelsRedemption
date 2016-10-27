using UnityEngine;

public class InputManager : MonoBehaviour {

    public static readonly InputEvent DEFAULT_INPUT_EVENT = InputEventTranslator.toEvent(new Touch());

#pragma warning disable 0414
    private static int previousTouchCount = 0;
    private static SubscriberComponent<InputEvent> inputSubscriber = null;

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
        if (Input.touchCount > 0 && previousTouchCount == 0) {
            Touch currentTouch = Input.GetTouch(0);

            inputReceiver = tryToGetInputEventReceiver(currentTouch.position);

            if (inputReceiver != null) {
                inputReceiver.Handle(InputEventTranslator.toEvent(currentTouch));
            } else {
                EventManager.Publish(DEFAULT_INPUT_EVENT);
            }
        }
        previousTouchCount = Input.touchCount;
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
}
