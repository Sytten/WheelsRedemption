using UnityEngine;
using UnityEngine.UI;

public class NextLevelButtonAction : MonoBehaviour {

    void Start() {
        Button playButton = GetComponent<Button>();
        playButton.onClick.AddListener(() => LevelManager.LoadNextLevel());
    }
}