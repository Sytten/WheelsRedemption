using UnityEngine;
using System.Collections;

public class AspectRatio : MonoBehaviour {

    public float gameAspect = 9.0f / 16.0f;
    public Camera cameraComponent;

    private void Start() {
        float targetAspect = (float)Screen.height / (float)Screen.width;

        float scaleWidth = targetAspect / gameAspect;

        if (cameraComponent == null) {
            cameraComponent = GetComponent<Camera>();
        }

        // if scaled width is less than current width, add pillarbox
        if (scaleWidth < 1.0f) {
            float scalewidth = 1.0f / scaleWidth;

            Rect rect = cameraComponent.rect;

            rect.width = scalewidth;
            rect.height = 1.0f;
            rect.x = (1.0f - scalewidth) / 2.0f;
            rect.y = 0;

            cameraComponent.rect = rect;
        } else { // add letterbox
            Rect rect = cameraComponent.rect;

            rect.width = 1.0f;
            rect.height = scaleWidth;
            rect.x = 0;
            rect.y = (1.0f - scaleWidth) / 2.0f;

            cameraComponent.rect = rect;
        }
    }

}
