using UnityEngine;
using System.Collections;

public class Following : MonoBehaviour {

    public GameObject target;
    public Camera cameraComponent;
    public float smoothTime = 0.05f;

    public bool useBoundaries = false;
    public float lowerBoundary = 0;
    public float upperBoundary = 0;

    private float currentVelocity;
    private float cameraHeight = 0;

    void Start() {
        if (target == null) {
            target = GameObject.FindGameObjectWithTag("Player");
        }

        if (cameraComponent == null) {
            cameraComponent = GetComponent<Camera>();
        }

        cameraHeight = cameraComponent.orthographicSize;
    }

    void FixedUpdate() {
        float verticalPosition = Mathf.SmoothDamp(transform.position.y, target.transform.position.y, ref currentVelocity, smoothTime);

        if (useBoundaries) {
            if (verticalPosition < lowerBoundary) {
                verticalPosition = lowerBoundary;
            } else if (verticalPosition + cameraHeight > upperBoundary) {
                verticalPosition = upperBoundary - cameraHeight;
            }
        }

        transform.position = new Vector3(transform.position.x, verticalPosition, transform.position.z);
    }
}