using UnityEngine;
using System.Collections;

public class Rotation : MonoBehaviour {

    public enum Speed {SLOW = 1, MEDIUM, FAST};
    public enum Direction {CLOCKWISE = -1, COUNTERCLOCKWISE = 1}

    public Speed wheelSpeed = Speed.SLOW;
    public Direction direction = Direction.CLOCKWISE;
    public Transform transformComponent;

	private void Start () {
       if(transformComponent == null) {
            transformComponent = GetComponent<Transform>();
        }
	}
	
	private void Update () {
        transformComponent.Rotate(new Vector3(0, 0, (int)direction * (int)wheelSpeed));
	}
}
