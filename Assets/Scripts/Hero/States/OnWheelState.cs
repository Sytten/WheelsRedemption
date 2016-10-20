using UnityEngine;

public class OnWheelState : State {

    private readonly int jumpPower = 350;

    private Hero hero;
    private Rigidbody2D heroRigidbody;

    public OnWheelState(Hero hero) {
        this.hero = hero;
        heroRigidbody = hero.GetComponent<Rigidbody2D>();
    }

    public override void OnCollisionEnter2D(Collision2D collision) {
        Behavior behavior = collision.gameObject.GetComponent<Behavior>();

        if (behavior != null) {
            behavior.Execute(this);
        }
    }

    public override void Jump() {
        //Remove the parent wheel
        hero.transform.parent = null;

        //Enable physic
        heroRigidbody.isKinematic = false;

        //Stop the player and apply the force
        heroRigidbody.velocity = Vector2.zero;
        heroRigidbody.AddForce(hero.transform.up * jumpPower);

        hero.ChangeState(hero.inAirState);
    }
}