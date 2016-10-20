using System.Collections.Generic;

public class Multiplexor<T> : IEventSubscriber<T> where T : IEvent {

    private readonly List<IEventSubscriber<T>> subscribers = new List<IEventSubscriber<T>>();

    public void AttachSubscriber(IEventSubscriber<T> subscriber) {
        subscribers.Add(subscriber);
    }

    public void Handle(T data) {
        subscribers.ForEach(x => x.Handle(data));
    }
}