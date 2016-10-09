using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class LevelsDisplay : MonoBehaviour {

    public GameObject levelButtonPrefab;

	void Start () {
        List<int> levelsId = LevelManager.getLevelsID();

        foreach (int levelId in levelsId) {
            GameObject levelButton = Instantiate(levelButtonPrefab) as GameObject;

            levelButton.name = "Level" + levelId.ToString();
            levelButton.GetComponent<LevelButtonAction>().levelId = levelId;
            levelButton.GetComponentInChildren<Text>().text = levelId.ToString();

            levelButton.transform.SetParent(transform, false);
        }
	}
}
