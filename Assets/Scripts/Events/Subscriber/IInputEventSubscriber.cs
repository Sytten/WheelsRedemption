public interface IInputEventReceiver : IEventSubscriber<InputEvent> {

    new void Handle(InputEvent data);
}