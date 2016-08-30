using UnityEngine;

public interface State {

    void Start();

    void Update();

    void FixedUpdate();

    void LateUpdate();

    void OnCollisionEnter2D(Collision2D collsion);

    void OnCollisionStay2D(Collision2D collsion);

    void OnCollisionExit2D(Collision2D collsion);
}
