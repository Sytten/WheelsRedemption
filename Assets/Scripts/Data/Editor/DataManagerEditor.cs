using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;

public class DataManagerEditor : MonoBehaviour {

    private static string BUILD_SCENES_NAMES_FILE = Application.dataPath + "/ScenesNamesList.asset";
    private static string SCENE_NAME_REGEX = @"([^/]*/)*([\w\d\-]*)\.unity";

    private static BinaryFormatter binaryFormatter = new BinaryFormatter();

    [MenuItem("Assets/Save Build Scenes Names %e")]
    private static void SaveBuildScenesNames() {
        List<string> buildScenesNames = EditorBuildSettings.scenes.Select(scene => scene.path).ToList();

        Regex sceneNameRegex = new Regex(SCENE_NAME_REGEX);
        buildScenesNames = buildScenesNames.Select(sceneName => sceneNameRegex.Replace(sceneName, "$2")).ToList();

        FileStream file = File.Create(BUILD_SCENES_NAMES_FILE);
        binaryFormatter.Serialize(file, new ScenesNamesList().withScenesNames(buildScenesNames));
    }
}
