using UnityEngine;
using System.Collections;

public class InAirState : IState {

    private Hero hero = null;
    private Rigidbody2D heroRigidbody;
    private Collision2D lastCollision = null;
    private bool ignoreFirstCollision = false;

    public InAirState(Hero hero) {
        this.hero = hero;
        heroRigidbody = hero.GetComponent<Rigidbody2D>();
    }

    public virtual void Start() {
    }

    public virtual void Update() {
        hero.transform.up = Vector2.Lerp(hero.transform.up, heroRigidbody.velocity.normalized, 0.1f);
    }

    public virtual void FixedUpdate() {
    }

    public virtual void LateUpdate() {
    }

    public virtual void OnCollisionEnter2D(Collision2D collision) {
        lastCollision = collision;

        Behavior behavior = collision.gameObject.GetComponent<Behavior>();

        if (behavior != null) {
            behavior.Execute(this);
        }
    }

    public virtual void OnCollisionStay2D(Collision2D collision) {
    }

    public virtual void OnCollisionExit2D(Collision2D collision) {
    }

    public virtual void OnTriggerEnter2D(Collider2D collider) {
        Behavior behavior = collider.gameObject.GetComponent<Behavior>();

        if (behavior != null) {
            behavior.Execute(this);
        }
    }

    public void LandHeroOnPlatform() {
        hero.transform.up = Vector2.up;
        hero.ChangeState(hero.onPlatformState);
    }
    
    public void AttachHeroToLastCollision() {
        if(lastCollision != null && !ignoreFirstCollision) {
            //Move the hero to contact point
            hero.transform.position = lastCollision.contacts[0].point;

            //Arrange the depth field
            hero.transform.position = new Vector3(hero.transform.position.x, hero.transform.position.y, 2);
            
            //Rotate the hero to make it face the outside
            hero.transform.up = lastCollision.contacts[0].point - (Vector2) lastCollision.transform.position;

            //Translate the hero to show it entirely 
            hero.transform.position += hero.transform.up.normalized * hero.GetComponent<BoxCollider2D>().size.y / 2.0f;

            //Make it follow the wheel movement
            hero.transform.parent = lastCollision.transform;

            //Disable physic
            hero.GetComponent<Rigidbody2D>().isKinematic = true;

            //Ignore next first collision (necessary to avoid unwanted collision with the wheel when entering this state)
            ignoreFirstCollision = true;

            hero.ChangeState(hero.onWheelState);

            return;
        }

        ignoreFirstCollision = false;
    }

    public void KillHero() {
        LevelManager.RestartScene ();
    }
}
