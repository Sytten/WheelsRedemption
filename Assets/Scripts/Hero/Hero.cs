using UnityEngine;
using System.Collections;

public class Hero : MonoBehaviour {

	public enum Direction { RIGHT = 1, LEFT = -1 };

	public int speed = 1;
	public Direction direction = Direction.LEFT;

	void Start () {
		speed *= (int)direction;
	}

	void Update () {
		Vector3 position = transform.position;
		transform.position = new Vector3(position.x + (speed * Time.deltaTime), position.y, position.z);
	}

	void OnCollisionEnter(Collision collision) {
		DefaultBehavior behavior = collision.gameObject.GetComponent<DefaultBehavior> ();
		behavior.HeroBehavior (gameObject);
	}
}
