using UnityEngine;

public abstract class State {

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
    }

    public virtual void OnCollisionExit2D(Collision2D collision) {
    }

    public virtual void OnTriggerEnter2D(Collider2D collider) {
    }

    public virtual void KillHero() {
        Time.timeScale = 0f;
        InGameMenuDisplay.LoadLoseMenu();
    }

    public virtual void HeroWin() {
        Time.timeScale = 0f;
        InGameMenuDisplay.LoadWinMenu();
    }
}