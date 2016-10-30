public class DestroyEvent : IEvent {

    public static readonly int DEFAULT_INSTANCE_ID = -1000000;

    private int instanceId = DEFAULT_INSTANCE_ID;

    public int GetInstanceId() {
        return instanceId;
    }

    public void SetInstanceId(int instanceId) {
        this.instanceId = instanceId;
    }

    public DestroyEvent withInstanceId(int instanceId) {
        SetInstanceId(instanceId);
        return this;
    }
}