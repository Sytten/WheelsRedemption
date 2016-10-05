using UnityEngine;
using System.Collections.Generic;

public class LevelsDisplay : MonoBehaviour {

    public GameObject levelButtonPrefab;

	void Start () {
        List<int> levelsID = LevelManager.getLevelsID();

        foreach (int levelID in levelsID) {
            GameObject levelButton = Instantiate(levelButtonPrefab) as GameObject;

            levelButton.GetComponent<LevelButtonAction>().levelID = levelID;

            levelButton.transform.parent = transform;
        }
	}
}
