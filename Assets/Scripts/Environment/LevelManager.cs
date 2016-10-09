using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class LevelManager
{
    public static void RestartScene() {
        Scene scene = SceneManager.GetActiveScene(); 
        SceneManager.LoadScene(scene.name);
    }

    public static void LoadLevel(int id) {
        SceneManager.LoadScene(id.ToString());
    }

    public static void LoadMainMenu() {
        SceneManager.LoadScene("MainMenu");
    }

    public static void LoadLevelsMenu() {
        SceneManager.LoadScene("LevelsMenu");
    }

    public static List<int> getLevelsID() {
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
}
