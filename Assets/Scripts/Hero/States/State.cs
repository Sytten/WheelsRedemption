using UnityEngine;

public interface State {

    void Start();

    void Update();

    void FixedUpdate();

    void LateUpdate();

    void OnCollisionEnter2D(Collision2D collision);

    void OnCollisionStay2D(Collision2D collision);

    void OnCollisionExit2D(Collision2D collision);

    void Jump(float jumpPower);
}
