using UnityEngine;

public class InGameMenuDisplay : MonoBehaviour {

    public static void LoadWinMenu() {
        GameObject menuFramework = loadMenuFramework();

        GameObject winMenu = Instantiate(Resources.Load("Win Menu") as GameObject);

        winMenu.transform.SetParent(menuFramework.GetComponentInChildren<RectTransform>(), false);
    }

    public static void LoadLoseMenu() {
        GameObject menuFramework = loadMenuFramework();

        GameObject loseMenu = Instantiate(Resources.Load("Lose Menu") as GameObject);

        loseMenu.transform.SetParent(menuFramework.GetComponentInChildren<RectTransform>(), false);

    }

    private static GameObject loadMenuFramework() {
        GameObject menuFramework = Instantiate(Resources.Load("Menu Framework") as GameObject);

        menuFramework.GetComponentInChildren<Canvas>().worldCamera = Camera.current;

        return menuFramework;
    }
}