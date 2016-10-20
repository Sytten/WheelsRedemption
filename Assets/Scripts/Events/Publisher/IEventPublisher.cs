interface IEventPublisher<T> {

    void Publish(T data);

    void Subscribe<V>(IEventSubscriber<V> handler) where V : T;
}