using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class PlayerStatistics : MonoBehaviour {

    private List<LevelStatistics> levelsStatistics;

    public List<LevelStatistics> GetLevelsStatistics() {
        return levelsStatistics;
    }

    public void SetLevelsStatistics(List<LevelStatistics> levelsStatistics) {
        this.levelsStatistics = levelsStatistics;
    }

    public void AddLevelStatistics(LevelStatistics levelStatistics) {
        if(levelsStatistics != null) {
            LevelStatistics currentStatistics = levelsStatistics.Find(level => level.GetId() == levelStatistics.GetId());

            if(currentStatistics != null) {
                levelsStatistics.Remove(currentStatistics);
            }

            levelsStatistics.Add(levelStatistics);
        }
    }

    public LevelStatistics SetLevelStatistics(int id) {
        return levelsStatistics.Find(level => level.GetId() == id);
    }
}
