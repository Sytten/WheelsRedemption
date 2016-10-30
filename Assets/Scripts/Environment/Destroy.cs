using UnityEngine;

public class Destroy : MonoBehaviour {

    public Behavior behaviorToRemove;

    private void Start() {
        if (behaviorToRemove == null) {
            behaviorToRemove = GetComponent<Behavior>();
        }
    }

    private void OnCollisionExit2D() {
        Destroy(behaviorToRemove);
        EventManager.Publish(new DestroyEvent().withInstanceId(gameObject.GetInstanceID()));
        enabled = false;
    }
}