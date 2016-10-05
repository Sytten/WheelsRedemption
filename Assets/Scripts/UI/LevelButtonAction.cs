using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelButtonAction : MonoBehaviour {

    public int levelID = 1;

	void Start () {
        Button playButton = GetComponent<Button>();
        playButton.onClick.AddListener(() => LevelManager.LoadLevel(levelID));
	}
}
