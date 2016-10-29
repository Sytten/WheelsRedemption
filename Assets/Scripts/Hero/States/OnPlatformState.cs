using UnityEngine;

public class OnPlatformState : State {

    private int speed = 10;
    private readonly int jumpPower = 350;

    private Hero hero = null;
    private Rigidbody2D heroRigidbody = null;

    public OnPlatformState(Hero hero) {
        this.hero = hero;
        heroRigidbody = hero.GetComponent<Rigidbody2D>();
    }

    public override void Update() {
        heroRigidbody.velocity = new Vector2(speed, 0);
    }

    public override void OnCollisionEnter2D(Collision2D collision) {
        Behavior behavior = collision.gameObject.GetComponent<Behavior>();

        if (behavior != null) {
            behavior.Execute(this);
        }
    }

    public override void Jump() {
        heroRigidbody.velocity = Vector2.zero;
        heroRigidbody.AddForce(Vector2.up * jumpPower);
        hero.ChangeState(hero.inAirState);
    }

    public void ChangeHeroDirection() {
        speed *= -1;
        heroRigidbody.velocity = new Vector2(speed, 0);
    }
}