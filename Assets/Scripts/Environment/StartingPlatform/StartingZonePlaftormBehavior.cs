using UnityEngine;
using System.Collections;

public class StartingZonePlaftormBehavior : DefaultStartingZoneBehavior {

    public enum Direction { LEFT = -1, RIGHT = 1 };

    public int speed = 10;
    public Direction direction = Direction.RIGHT;

    public override void Behavior(OnStartingPlatformState state) {
        if(Mathf.Abs(state.speed) != speed) {
            state.speed = (int)direction * speed;
        }
    }
}
