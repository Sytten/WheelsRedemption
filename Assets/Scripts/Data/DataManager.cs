using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class DataManager {

    private static string PLAYER_STATISTICS_FILE = Application.persistentDataPath + "/playerStatistics.bin";
    private static string BUILD_SCENES_NAMES_FILE = "ScenesNamesList";

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

        TextAsset file = Resources.Load(BUILD_SCENES_NAMES_FILE) as TextAsset;
        Stream fileStream = new MemoryStream(file.bytes);
        scenesNamesList = (ScenesNamesList) binaryFormatter.Deserialize(fileStream);

        return scenesNamesList;
    }
}