public class EventManager {

    private static Dispatcher<IEvent> dispatcher = new Dispatcher<IEvent>();

    public static void Publish(IEvent data) {
        dispatcher.Publish(data);
    }

    public static void Subscribe<T>(IEventSubscriber<T> handler) where T : IEvent {
        dispatcher.Subscribe<T>(handler);
    }
}