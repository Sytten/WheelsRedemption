using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuButtonAction : MonoBehaviour {

    public enum Menus { MAIN, LEVELS };

    public Menus onClickMenu = Menus.MAIN;

    void Start() {
        Button menuButton = GetComponent<Button>();

        switch (onClickMenu) {
            case Menus.MAIN:
                menuButton.onClick.AddListener(() => LevelManager.LoadMainMenu());
                break;
            case Menus.LEVELS:
                menuButton.onClick.AddListener(() => LevelManager.LoadLevelsMenu());
                break;
        }
    }
}