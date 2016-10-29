using UnityEngine;

public abstract class SubscriberComponent<T> : MonoBehaviour, IEventSubscriber<T> where T : IEvent {

    protected virtual void Start() {
        EventManager.Subscribe<T>(this);
    }

    public abstract void Handle(T eventReceived);

    protected virtual void OnDestroy() {
        EventManager.UnSubscribe<T>(this);
    }
}
