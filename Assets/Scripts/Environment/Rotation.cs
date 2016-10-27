using UnityEngine;

public class Rotation : MonoBehaviour {

    public enum Speed { FREEZE = 0, VERY_SLOW, SLOW, MEDIUM, FAST };
    public enum Direction { CLOCKWISE = -1, COUNTERCLOCKWISE = 1 }

    public Speed wheelSpeed = Speed.SLOW;
    public Direction direction = Direction.CLOCKWISE;
    public Transform transformComponent;

    private Speed initialWheelSpeed;

    private void Start() {
        if (transformComponent == null) {
            transformComponent = GetComponent<Transform>();
        }
        initialWheelSpeed = wheelSpeed;
    }

    private void Update() {
        transformComponent.Rotate(new Vector3(0, 0, (int) direction * (int) wheelSpeed * 0.75F));
    }

    public void IncreaseSpeed(int number) {
        wheelSpeed = (Speed) Mathf.Min((int) Speed.FAST, (int) wheelSpeed + number);
    }

    public void DecreaseSpeed(int number) {
        wheelSpeed = (Speed) Mathf.Max(0, (int) wheelSpeed - number);
    }

    public void RestoreInitialSpeed() {
        wheelSpeed = initialWheelSpeed;
    }
}