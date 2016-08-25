using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour {

	public bool isGrounded = true;
	public float jumpPower = 1;
	public GameObject sprite = null;

	private Rigidbody2D rigidbodyComponent = null;

	// Use this for initialization
	void Start () {
		rigidbodyComponent = sprite.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp (KeyCode.Space)) {
			rigidbodyComponent.AddForce(Vector2.up * jumpPower);
			isGrounded = false;
		}
	}
}
