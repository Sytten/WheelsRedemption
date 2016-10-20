public interface IEventSubscriber<T> {

    void Handle(T eventReceived);
}