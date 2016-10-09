using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class ScenesNamesList {

    private List<string> scenesNames = new List<string>();

    public List<string> getScenesNames() {
        return scenesNames;
    }

    public void setScenesNames(List<string> scenesNames) {
        this.scenesNames = scenesNames;
    }

    public ScenesNamesList withScenesNames(List<string> scenesNames) {
        setScenesNames(scenesNames);
        return this;
    }
}