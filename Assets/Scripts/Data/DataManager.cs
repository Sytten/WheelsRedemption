using UnityEngine;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEditor;
using System.Linq;
using System.Text.RegularExpressions;

public class DataManager {

    private static string PLAYER_STATISTICS_FILE = Application.dataPath + "/playerStatistics.bin";
    private static string BUILD_SCENES_NAMES_FILE = Application.dataPath +  "/ScenesNamesList.asset";
    private static string SCENE_NAME_REGEX = @"([^/]*/)*([\w\d\-]*)\.unity";

    private static BinaryFormatter binaryFormatter = new BinaryFormatter();

    public static void SavePlayerStatistics(PlayerStatistics playerStatistics) {
        FileStream file = File.Create(PLAYER_STATISTICS_FILE);
        binaryFormatter.Serialize(file, playerStatistics);
    }

    public static PlayerStatistics LoadPlayerStatistics() {
        PlayerStatistics playerStatistics = new PlayerStatistics();

        if (File.Exists(PLAYER_STATISTICS_FILE)) {
            FileStream file = File.Open(PLAYER_STATISTICS_FILE, FileMode.Open);
            playerStatistics = (PlayerStatistics) binaryFormatter.Deserialize(file);
            file.Close();
        }

        return playerStatistics;
    }

    public static ScenesNamesList LoadBuildScenesNames() {
        ScenesNamesList scenesNamesList = new ScenesNamesList();

        if (File.Exists(BUILD_SCENES_NAMES_FILE)) {
            FileStream file = File.Open(BUILD_SCENES_NAMES_FILE, FileMode.Open);
            scenesNamesList = (ScenesNamesList) binaryFormatter.Deserialize(file);
            file.Close();
        }

        return scenesNamesList;
    }

    [MenuItem("Assets/Save Build Scenes Names %e")]
    private static void SaveBuildScenesNames() {
        List<string> buildScenesNames = EditorBuildSettings.scenes.Select(scene => scene.path).ToList();

        Regex sceneNameRegex = new Regex(SCENE_NAME_REGEX);
        buildScenesNames = buildScenesNames.Select(sceneName => sceneNameRegex.Replace(sceneName, "$2")).ToList();

        FileStream file = File.Create(BUILD_SCENES_NAMES_FILE);
        binaryFormatter.Serialize(file, new ScenesNamesList().withScenesNames(buildScenesNames));
    }
}
