using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour {

	public GameObject sprite = null;

	public int minJumpPower = 250;
	public int maxJumpPower = 350;

	private bool isGrounded = true;
	private bool timerStarted = false;
	private float jumpPower = 0;
	private Rigidbody2D rigidbodyComponent = null;

	// Use this for initialization
	void Start () {
		jumpPower = minJumpPower;
		rigidbodyComponent = sprite.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {

		// Check if the hero has landed
		if (!isGrounded && rigidbodyComponent.velocity.y == 0) {
			isGrounded = true;
		}

		// Start a timer to calculate the final jump power
		if (Input.GetKeyDown (KeyCode.Space) && isGrounded && !timerStarted) {
			timerStarted = true;
		}

		// Jump only if the hero is currently grounded
		if (Input.GetKeyUp (KeyCode.Space) && isGrounded) {

			if (jumpPower > maxJumpPower) {
				jumpPower = maxJumpPower;
			}

			// Jump
			rigidbodyComponent.AddForce(Vector2.up * jumpPower);

			// Update states
			isGrounded = false;
			timerStarted = false;
			jumpPower = minJumpPower;
		}

		// Increment the jump power
		if (timerStarted) {
			jumpPower += maxJumpPower * Time.deltaTime / 2;
		}
	}
}
