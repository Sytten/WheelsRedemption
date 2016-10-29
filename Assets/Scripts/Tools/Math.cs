using UnityEngine;


class Math {

    public static float Lerp(float currentValue, float targetValue, float velocity, float deltaTime) {
        if (currentValue <= targetValue) {
            float newValue = currentValue + velocity * deltaTime;
            return Mathf.Min(targetValue, newValue);
        } else {
            float newValue = currentValue - velocity * deltaTime;
            return Mathf.Max(targetValue, newValue);
        }
    }
}