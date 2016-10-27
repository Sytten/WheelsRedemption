public interface IEventSubscriber<T> where T : IEvent {

    void Handle(T eventReceived);
}