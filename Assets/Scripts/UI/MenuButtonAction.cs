using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuButtonAction : MonoBehaviour {

    public enum Menus { MainMenu, LevelsMenu };

    public Menus onClickMenu = Menus.MainMenu;

    void Start() {
        Button menuButton = GetComponent<Button>();

        switch (onClickMenu) {
            case Menus.MainMenu:
                menuButton.onClick.AddListener(() => LevelManager.LoadMainMenu());
                break;
            case Menus.LevelsMenu:
                menuButton.onClick.AddListener(() => LevelManager.LoadLevelsMenu());
                break;
        }
    }
}
