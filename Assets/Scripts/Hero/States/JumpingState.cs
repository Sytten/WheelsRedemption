using UnityEngine;
using System.Collections;

public class JumpingState : State {

    private Hero hero;

    public JumpingState(Hero hero) {
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
    }

    public virtual void OnCollisionStay2D(Collision2D collision) {
        if (collision.collider.tag == "StartingZone") {
            hero.ChangeState(new OnStartingPlatformState(hero));
        }
    }

    public virtual void OnCollisionExit2D(Collision2D collision) {
    }

    public void Jump(float jumpPower) {
    }
}
