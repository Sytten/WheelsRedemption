﻿using UnityEngine;

public class InAirState : State {

    private Hero hero = null;
    private Rigidbody2D heroRigidbody;
    private Collision2D lastCollision = null;
    private CollisionTimer collisionTimer = new CollisionTimer(100);

    public InAirState(Hero hero) {
        this.hero = hero;
        heroRigidbody = hero.GetComponent<Rigidbody2D>();
    }

    public override void Start() {
        collisionTimer.Reset();
        collisionTimer.StartTimer();
    }

    public override void Update() {
        hero.transform.up = Vector2.Lerp(hero.transform.up, heroRigidbody.velocity.normalized, 0.1f);
    }

    public override void OnCollisionEnter2D(Collision2D collision) {
        if (!collisionTimer.IgnoreCollision()) {
            lastCollision = collision;

            Behavior behavior = collision.gameObject.GetComponent<Behavior>();

            if (behavior != null) {
                behavior.Execute(this);
            }
        }
    }

    public override void OnTriggerEnter2D(Collider2D collider) {
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
        if (lastCollision != null) {
            //Move the hero to contact point
            hero.transform.position = lastCollision.contacts[0].point;

            //Arrange the depth field
            hero.transform.position = new Vector3(hero.transform.position.x, hero.transform.position.y, 2);

            //Rotate the hero to make it face the outside
            hero.transform.up = lastCollision.contacts[0].point - (Vector2) lastCollision.transform.parent.position;

            //Translate the hero to show it entirely 
            hero.transform.position += hero.transform.up.normalized * (hero.GetComponent<BoxCollider2D>().size.y / 2.0f);

            //Make it follow the wheel movement
            hero.transform.parent = lastCollision.transform;

            //Disable physic
            heroRigidbody.constraints = RigidbodyConstraints2D.FreezeAll;

            hero.ChangeState(hero.onWheelState);

            return;
        }
    }
}