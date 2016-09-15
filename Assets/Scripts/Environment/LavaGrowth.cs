using UnityEngine;
using System.Collections;

public class LavaGrowth : MonoBehaviour {

    public float growthSpeedMultiplier = 1.0f;

	// Use this for initialization
	void Start () {
	   
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(new Vector3 (0,
            Time.deltaTime * growthSpeedMultiplier,
            0));
	}
}
