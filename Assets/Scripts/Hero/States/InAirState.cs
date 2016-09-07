using UnityEngine;
using System.Collections;

public class InAirState : IState {

    private Hero hero = null;
    private Collision2D lastCollision = null;

    public InAirState(Hero hero) {
        this.hero = hero;
    }

    public virtual void Start() {
    }

    public virtual void Update() {
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

    public void LandHeroOnPlatform() {
        hero.ChangeState(hero.onPlatformState);
    }
    
    public void AttachHeroToLastCollision() {
        if(lastCollision != null) {
            hero.transform.parent = lastCollision.transform;
            hero.ChangeState(hero.onWheelState);
        }
    }
}
