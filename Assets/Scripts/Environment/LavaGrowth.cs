using UnityEngine;
using System.Collections;

public class LavaGrowth : MonoBehaviour {

    public float growthSpeedMultiplier = 1.0f;

    void Update() {
        transform.Translate(new Vector3(0,
            Time.deltaTime * growthSpeedMultiplier,
            0));
    }
}