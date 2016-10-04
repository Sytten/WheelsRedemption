using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayButtonAction : MonoBehaviour {

	void Start () {
        Button playButton = GetComponent<Button>();
        playButton.onClick.AddListener(() => LevelManager.LoadLevel(1));
	}
}
