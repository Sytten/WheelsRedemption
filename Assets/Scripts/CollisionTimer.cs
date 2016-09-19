using UnityEngine;
using System.Collections;
using System.Threading;

public class CollisionTimer {

    private bool ignore = true;
    private int timeBeforeCollisionsEnabled;
    private Thread timerThread;

    public CollisionTimer(int timeBeforeCollisionsEnabled) {
        this.timeBeforeCollisionsEnabled = timeBeforeCollisionsEnabled;
        timerThread = new Thread(new ThreadStart(waitBeforeEnablingCollisions));
    }

	public void StartTimer() {
        timerThread.Start();
	}
	
	private void waitBeforeEnablingCollisions() {
        Thread.Sleep(timeBeforeCollisionsEnabled);
        ignore = false;
    }

    public bool IgnoreCollision() {
        return ignore;
    }

    public void Reset() {
        timerThread = new Thread(new ThreadStart(waitBeforeEnablingCollisions));
        ignore = true;
    }
}
