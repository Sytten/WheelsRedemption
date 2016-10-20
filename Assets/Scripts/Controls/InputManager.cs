using UnityEngine;

public class InputManager : MonoBehaviour {

    public static readonly Touch DEFAULT_TOUCH = new Touch();

#pragma warning disable 0414
    private static int previousTouchCount = 0;

    private void Update() {
#if UNITY_EDITOR
        if (Input.GetKeyUp(KeyCode.Space)) {
            EventManager.Publish(new InputEvent().withTouch(DEFAULT_TOUCH));
        }
#elif UNITY_ANDROID
        if (Input.touchCount == 0 && previousTouchCount > 0) {
            previousTouchCount = Input.touchCount;
            EventManager.Publish(new InputEvent().withTouch(DEFAULT_TOUCH));
        } else if (Input.touchCount > 0 && previousTouchCount == 0) {
            previousTouchCount = Input.touchCount;
            EventManager.Publish(new InputEvent().withTouch(DEFAULT_TOUCH)); return true;
        }
#endif
    }
}
