using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager {

    public static void RestartScene() {
        Scene scene = SceneManager.GetActiveScene();
        loadScene(scene.name);
    }

    public static void LoadLevel(int id) {
        loadScene(id.ToString());
    }

    public static void LoadNextLevel() {
        Scene currentScene = SceneManager.GetActiveScene();

        int sceneId = -1;

        if (!int.TryParse(currentScene.name, out sceneId)) {
            Debug.LogError("Impossible to load next level if not already in a level.");
            return;
        }

        sceneId++;
        List<int> scenesId = GetLevelsId();

        if (scenesId.Contains(sceneId)) {
            loadScene(sceneId.ToString());
        } else {
            LoadLevelsMenu();
        }
    }

    public static void LoadMainMenu() {
        loadScene("MainMenu");
    }

    public static void LoadLevelsMenu() {
        loadScene("LevelsMenu");
    }

    public static List<int> GetLevelsId() {
        List<string> scenesNames = DataManager.LoadBuildScenesNames().getScenesNames();
        List<int> levelsID = new List<int>();

        int id = 0;
        foreach (string sceneName in scenesNames) {
            if (int.TryParse(sceneName, out id)) {
                levelsID.Add(id);
            }
        }

        return levelsID;
    }

    private static void loadScene(string sceneName) {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneName);
    }
}