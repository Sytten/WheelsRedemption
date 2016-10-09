using UnityEngine;
using System.Collections;

[System.Serializable]
public class LevelStatistics {

    public const int MAX_STARS = 3;

    private int id;
    private float bestTime;
    private int stars;

    public int GetId() {
        return id;
    }

    public int GetStars() {
        return stars;
    }

    public float GetBestTime() {
        return bestTime;
    }

    public void SetId(int Id) {
        this.id = Id;
    }

    public void SetStars(int stars) {
        if (stars > 0 && stars < MAX_STARS) {
            this.stars = stars;
        }
    }

    public void SetBestTime(float bestTime) {
        if (bestTime > 0) {
            this.bestTime = bestTime;
        }
    }

    public LevelStatistics withId(int id) {
        SetId(id);
        return this;
    }

    public LevelStatistics withStars(int stars) {
        SetStars(stars);
        return this;
    }

    public LevelStatistics withBestTime(float bestTime) {
        SetBestTime(bestTime);
        return this;
    }
}