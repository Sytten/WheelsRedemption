using UnityEngine;
using System.Collections;

public class OnWheelState : IState {

	private Hero hero;

	public OnWheelState(Hero hero) {
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
