using UnityEngine;

public class InputManager : MonoBehaviour {

    private InputStrategy inputStrategy;

    private void Start() {
#if UNITY_EDITOR
        inputStrategy = new MouseStrategy();
#elif UNITY_ANDROID
        inputStrategy = new TouchStrategy();
#endif
    }

    private void Update() {
        inputStrategy.Update();
    }
}