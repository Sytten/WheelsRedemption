using UnityEngine;
using System.Collections;

public class ModifySurfaceEffector : MonoBehaviour {

    public enum Direction { RIGHT = 1, LEFT = -1};

    public int newSpeed;
    public Direction newDirection;
    public SurfaceEffector2D surfaceEffector;

    private void OnTriggerEnter2D (Collider2D collider) {
        if(surfaceEffector != null) {
            surfaceEffector.speed = (int)newDirection * newSpeed;
        }
    }
}
