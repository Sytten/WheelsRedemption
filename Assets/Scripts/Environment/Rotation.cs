using UnityEngine;

public class Rotation : MonoBehaviour {

    public enum Speed { FREEZE = 0, VERY_SLOW, SLOW, MEDIUM, FAST };
    public enum Direction { CLOCKWISE = -1, COUNTERCLOCKWISE = 1 }

    public Speed speed = Speed.SLOW;
    public float speedTransitionVelocity = 2.0f;
    public float speedMutiplier = 1.0f;
    public Direction direction = Direction.CLOCKWISE;
    public Transform transformComponent;

    private Speed initialSpeed;
    private float currentSpeed;

    private void Start() {
        if (transformComponent == null) {
            transformComponent = GetComponent<Transform>();
        }
        initialSpeed = speed;
        currentSpeed = (float) speed;
    }

    private void Update() {
        currentSpeed = Math.Lerp(currentSpeed, (float) speed, speedTransitionVelocity, Time.deltaTime);

        transformComponent.Rotate(new Vector3(0, 0, (int) direction * currentSpeed * speedMutiplier));
    }

    public void IncreaseSpeed(int number) {
        speed = (Speed) Mathf.Min((int) Speed.FAST, (int) speed + number);
    }

    public void DecreaseSpeed(int number) {
        speed = (Speed) Mathf.Max(0, (int) speed - number);
    }

    public void RestoreInitialSpeed() {
        speed = initialSpeed;
    }
}