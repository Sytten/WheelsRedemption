using UnityEngine;

public class WheelInputSubscriber : SubscriberComponent<InputEvent> {
    public Rotation rotation;

    protected override void Start() {
        base.Start();

        if (rotation == null) {
            rotation = GetComponent<Rotation>();
        }
    }

    public override void Handle(InputEvent data) {
        if (gameObject.GetComponent<Collider2D>().OverlapPoint(data.GetWorldPosition()) && data.GetPhase() == TouchPhase.Began) {
            rotation.DecreaseSpeed(2);
        } else if (data.GetPhase() == TouchPhase.Ended) {
            rotation.RestoreInitialSpeed();
        }
    }
}
