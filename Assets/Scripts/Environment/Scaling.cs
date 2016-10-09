using UnityEngine;
using System.Collections;


[ExecuteInEditMode]
public class Scaling : MonoBehaviour {

    public enum Scale { SMALL = 1, MEDIUM, BIG };

    public Scale scale = Scale.SMALL;
    public Transform transformComponent;

    private void Start() {
        if (transformComponent == null) {
            transformComponent = GetComponent<Transform>();
        }

        transformComponent.localScale = new Vector3((int) scale, (int) scale, (int) scale);
    }

    private void Update() {
        if (transformComponent != null) {
            transformComponent.localScale = new Vector3((int) scale, (int) scale, (int) scale);
        }
    }
}