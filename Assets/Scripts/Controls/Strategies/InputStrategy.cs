using UnityEngine;

public abstract class InputStrategy {

    public static readonly InputEvent DEFAULT_INPUT_EVENT = InputEventTranslator.toEvent(new Touch());

    protected SubscriberComponent<InputEvent> inputSubscriber = null;

    public abstract void Update();

    protected SubscriberComponent<InputEvent> tryToGetInputEventReceiver(Vector2 position) {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(position), Vector2.zero);

        if (hit) {
            GameObject gameObject = hit.collider.gameObject;
            return gameObject.GetComponent<SubscriberComponent<InputEvent>>();
        }

        return null;
    }
}