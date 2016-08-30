using UnityEngine;
using System.Collections;

public class OnStartingPlatformState : State {

    public Hero hero;
    public Rigidbody2D heroRigidbody;

    public int speed = 0;

    public OnStartingPlatformState(Hero hero) {
        this.hero = hero;
        heroRigidbody = hero.GetComponentInParent<Rigidbody2D>();
    }

    public virtual void Start() {
    }

    public virtual void Update() {
        Vector3 position = hero.transform.position;
        hero.transform.position = new Vector3(position.x + (speed * Time.deltaTime), position.y, position.z);
    }

    public virtual void FixedUpdate() {
    }

    public virtual void LateUpdate() {
    }

    public virtual void OnCollisionEnter2D(Collision2D collision) {
        DefaultStartingZoneBehavior behavior = collision.gameObject.GetComponent<DefaultStartingZoneBehavior>();

        if (behavior != null) {
            behavior.Behavior(this);
        }
    }

    public virtual void OnCollisionStay2D(Collision2D collision) {
    }

    public virtual void OnCollisionExit2D(Collision2D collision) {
    }

    public void Jump(float jumpPower) {
        heroRigidbody.AddForce(Vector2.up * jumpPower);
        hero.ChangeState(new JumpingState(hero));
    }
}
