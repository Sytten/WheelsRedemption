using UnityEngine;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class DataManager {

    private static string PLAYER_STATISTICS_FILE = Application.dataPath + "/playerStatistics.bin";

    private static BinaryFormatter binaryFormatter = new BinaryFormatter();

	public static void SavePlayerStatistics(PlayerStatistics playerStatistics) {
        FileStream file = File.Create(PLAYER_STATISTICS_FILE);
        binaryFormatter.Serialize(file, playerStatistics);
    }

    public static PlayerStatistics LoadPlayerStatistics() {
        PlayerStatistics playerStatistics = null;

        if (File.Exists(PLAYER_STATISTICS_FILE)) {
            FileStream file = File.Open(PLAYER_STATISTICS_FILE, FileMode.Open);
            playerStatistics = (PlayerStatistics) binaryFormatter.Deserialize(file);
            file.Close();
        }

        return playerStatistics;
    }
}
