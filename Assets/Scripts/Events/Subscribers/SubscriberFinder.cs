using UnityEngine;

public static class SubscriberFinder {

    public static SubscriberComponent<T> tryToGetEventSubscriber<T>(Vector2 position) where T : IEvent {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(position), Vector2.zero);

        if (hit) {
            GameObject gameObject = hit.collider.gameObject;
            return gameObject.GetComponent<SubscriberComponent<T>>();
        }

        return null;
    }
}
