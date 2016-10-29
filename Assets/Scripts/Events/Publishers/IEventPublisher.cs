interface IEventPublisher<T> where T : IEvent {

    void Publish(T data);

    void Subscribe<V>(IEventSubscriber<V> handler) where V : T;
}