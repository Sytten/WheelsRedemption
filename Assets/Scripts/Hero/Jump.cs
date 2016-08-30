using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour {

	public int minJumpPower = 250;
	public int maxJumpPower = 350;

    public Hero hero = null;

    private bool timerStarted = false;
	private float jumpPower = 0;

	void Start () {
		jumpPower = minJumpPower;

        if (hero == null) {
            hero = GetComponent<Hero>();
        }
	}
	
	void Update () {
		// Start a timer to calculate the final jump power
		if (Input.GetKeyDown (KeyCode.Space) && !timerStarted) {
			timerStarted = true;
		}

		// Jump only if the hero is currently grounded
		if (Input.GetKeyUp (KeyCode.Space)) {

			if (jumpPower > maxJumpPower) {
				jumpPower = maxJumpPower;
			}

            hero.Jump(jumpPower);
		
			timerStarted = false;
			jumpPower = minJumpPower;
		}

		// Increment the jump power
		if (timerStarted) {
			jumpPower += maxJumpPower * Time.deltaTime / 2;
		}
	}
}
