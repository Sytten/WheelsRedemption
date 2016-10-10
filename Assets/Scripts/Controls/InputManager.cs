using UnityEngine;

public class InputManager {

#pragma warning disable 0414
    private static int previousTouchCount = 0;

    public static bool JumpButtonPressed() {
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.Space)) {
            return true;
        }
#elif UNITY_ANDROID
        if (Input.touchCount > 0 && previousTouchCount == 0) {
            previousTouchCount = Input.touchCount;
            return true;
        }
#endif
        return false;
    }

    public static bool JumpButtonReleased() {
#if UNITY_EDITOR
        if (Input.GetKeyUp(KeyCode.Space)) {
            return true;
        }
#elif UNITY_ANDROID
        if (Input.touchCount == 0 && previousTouchCount > 0) {
            previousTouchCount = Input.touchCount;
            return true;
        }
#endif
        return false;
    }
}
