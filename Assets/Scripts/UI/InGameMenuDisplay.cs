using UnityEngine;

public static class InGameMenuDisplay {

    public static void LoadWinMenu() {
        GameObject menuFramework = loadMenuFramework();

        GameObject winMenu = GameObject.Instantiate(Resources.Load("Win Menu") as GameObject);

        winMenu.transform.SetParent(menuFramework.GetComponentInChildren<RectTransform>(), false);
    }

    public static void LoadLoseMenu() {
        GameObject menuFramework = loadMenuFramework();

        GameObject loseMenu = GameObject.Instantiate(Resources.Load("Lose Menu") as GameObject);

        loseMenu.transform.SetParent(menuFramework.GetComponentInChildren<RectTransform>(), false);

    }

    private static GameObject loadMenuFramework() {
        GameObject menuFramework = GameObject.Instantiate(Resources.Load("Menu Framework") as GameObject);

        menuFramework.GetComponentInChildren<Canvas>().worldCamera = Camera.main;

        return menuFramework;
    }
}