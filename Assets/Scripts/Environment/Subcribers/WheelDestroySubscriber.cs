using UnityEngine;

class WheelDestroySubscriber : SubscriberComponent<DestroyEvent> {

    public Sprite newSprite = null;
    public SpriteRenderer spriteRenderer = null;

    protected override void Start() {
        base.Start();

        if (spriteRenderer == null) {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }
    }

    public override void Handle(DestroyEvent eventReceived) {
        int parentId = transform.parent.gameObject.GetInstanceID();

        if (eventReceived.GetInstanceId() == parentId) {
            spriteRenderer.sprite = newSprite;
        }
    }
}