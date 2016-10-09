using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

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
}
