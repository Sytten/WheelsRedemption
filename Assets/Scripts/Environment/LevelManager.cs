using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager
{
    public static void RestartScene() {
        Scene scene = SceneManager.GetActiveScene(); 
        SceneManager.LoadScene(scene.name);
    }
}
