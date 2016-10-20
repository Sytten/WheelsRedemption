public class InputEventReceiver : ComponentEventSubscriber<InputEvent> {

    private void Start() {
        EventManager.Subscribe<InputEvent>(this);
    }

    public override void Handle(InputEvent data) {
    }
}