using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager
{
    private static LevelManager instance;

    private LevelManager() {}

    public static LevelManager Instance
    {
        get 
        {
            if (instance == null)
            {
                instance = new LevelManager();
            }
            return instance;
        }
    }

    public void RestartScene() {
        Scene scene = SceneManager.GetActiveScene(); 
        SceneManager.LoadScene(scene.name);
    }
}
