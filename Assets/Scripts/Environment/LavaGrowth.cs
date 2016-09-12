using UnityEngine;
using System.Collections;

public class LavaGrowth : MonoBehaviour {

    public float growthSpeedMultiplier = 1.0f;

	// Use this for initialization
	void Start () {
	   
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3 (transform.position.x,
            transform.position.y + (Time.deltaTime * growthSpeedMultiplier),
            transform.position.z);
	}
}
