using UnityEngine;
using UnityEngine.UI;

public class RestartLevelButtonAction : MonoBehaviour {

    void Start() {
        Button playButton = GetComponent<Button>();
        playButton.onClick.AddListener(() => LevelManager.RestartScene());
    }
}