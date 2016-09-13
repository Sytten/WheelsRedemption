using UnityEngine;
using System.Collections;

public class InAirState : IState {

    private Hero hero;

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
		if (collision.collider.tag == "StartingZone") {
			hero.ChangeState(hero.onPlatformState);
        }

        Behavior behavior = collision.gameObject.GetComponent<Behavior>();

        if (behavior != null) {
            behavior.Execute(this);
        }
    }

    public virtual void OnCollisionStay2D(Collision2D collision) {
        
    }

    public virtual void OnCollisionExit2D(Collision2D collision) {
    }

    public void Jump(float jumpPower) {
    }

    public void KillHero() {
        LevelManager.Instance.RestartScene ();
    }
}
