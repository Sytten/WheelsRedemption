using UnityEngine;

public class OnWheelState : State {

    private readonly int minJumpPower = 250;
    private readonly int maxJumpPower = 350;
    private bool timerStarted = false;
    private float jumpPower = 0;

    private Hero hero;
    private Rigidbody2D heroRigidbody;

    public OnWheelState(Hero hero) {
        this.hero = hero;
        heroRigidbody = hero.GetComponent<Rigidbody2D>();
    }

    public override void Update() {
        if (isReadytoJump()) {
            jump();
        }
    }

    public override void OnCollisionEnter2D(Collision2D collision) {
        Behavior behavior = collision.gameObject.GetComponent<Behavior>();

        if (behavior != null) {
            behavior.Execute(this);
        }
    }

    private void jump() {
        //Remove the parent wheel
        hero.transform.parent = null;

        //Enable physic
        heroRigidbody.isKinematic = false;

        //Stop the player and apply the force
        heroRigidbody.velocity = Vector2.zero;
        heroRigidbody.AddForce(hero.transform.up * jumpPower);

        hero.ChangeState(hero.inAirState);
    }

    private bool isReadytoJump() {
        if (InputManager.JumpButtonPressed() && !timerStarted) {
            timerStarted = true;
            jumpPower = minJumpPower;
        }

        if (InputManager.JumpButtonReleased()) {

            if (jumpPower > maxJumpPower) {
                jumpPower = maxJumpPower;
            }

            timerStarted = false;

            return true;
        }

        // Increment the jump power
        if (timerStarted) {
            jumpPower += maxJumpPower * Time.deltaTime / 2;
        }

        return false;
    }
}