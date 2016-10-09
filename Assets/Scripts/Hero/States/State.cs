using UnityEngine;

public interface IState {

    void Start();

    void Update();

    void FixedUpdate();

    void LateUpdate();

    void OnCollisionEnter2D(Collision2D collision);

    void OnCollisionStay2D(Collision2D collision);

    void OnCollisionExit2D(Collision2D collision);

    void OnTriggerEnter2D(Collider2D collider);

    void KillHero();
}