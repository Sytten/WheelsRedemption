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
        List<int> levelsID = new List<int>();

        for (int i = 0; i < SceneManager.sceneCountInBuildSettings; ++i) {
            int id = 0;
            string levelName = SceneManager.GetSceneAt(i).name;
            if (int.TryParse(levelName, out id)) {
                levelsID.Add(id);
            }
        }

        return levelsID;
    }
}
