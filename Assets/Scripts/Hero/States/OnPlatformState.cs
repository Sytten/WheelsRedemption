using UnityEngine;

public class OnPlatformState : State {

    private int speed = 10;

    private readonly int minJumpPower = 250;
    private readonly int maxJumpPower = 350;
    private bool timerStarted = false;
    private float jumpPower = 0;

    private Hero hero = null;
    private Rigidbody2D heroRigidbody = null;

    public OnPlatformState(Hero hero) {
        this.hero = hero;
        heroRigidbody = hero.GetComponent<Rigidbody2D>();
    }

    public override void Update() {
        heroRigidbody.velocity = new Vector2(speed, 0);

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

    public void ChangeHeroDirection() {
        speed *= -1;
        heroRigidbody.velocity = new Vector2(speed, 0);
    }

    private void jump() {
        heroRigidbody.velocity = Vector2.zero;
        heroRigidbody.AddForce(Vector2.up * jumpPower);
        hero.ChangeState(hero.inAirState);
    }

    private bool isReadytoJump() {
        if (Input.GetKeyDown(KeyCode.Space) && !timerStarted) {
            timerStarted = true;
            jumpPower = minJumpPower;
        }

        // Jump only if the hero is currently grounded
        if (Input.GetKeyUp(KeyCode.Space)) {

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