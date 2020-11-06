using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System;
using System.IO;

public class Test
{

    [MenuItem("Tool/Build")]
    public static void BuildTestMenuItem()
    {

        Debug.Log("========================================================");
        Debug.Log(EditorPrefs.GetString("AndroidNdkRoot"));
        Debug.Log(EditorPrefs.GetString("AndroidSdkRoot"));
        Debug.Log("========================================================");

        Directory.SetCurrentDirectory(Directory.GetParent(Application.dataPath).FullName);
        string parentPath = Directory.GetCurrentDirectory();
        
        string path = parentPath + "/test.apk";

        string error = BuildPipeline.BuildPlayer(GetBuildScenes(), path, BuildTarget.Android, BuildOptions.None);
        Debug.Log("error:" + error);

    }

    public static void BuildTest()
    {
        Debug.Log("###### BuildTest");

        Directory.SetCurrentDirectory(Directory.GetParent(Application.dataPath).FullName);
        string parentPath = Directory.GetCurrentDirectory();

        string path = parentPath + "/test.apk";

        Debug.Log("========================================================");
        Debug.Log(path);
        Debug.Log("======================================================== 1. ");
        string error = BuildPipeline.BuildPlayer(GetBuildScenes(), path, BuildTarget.Android, BuildOptions.None);
        Debug.Log("###error:" + error);
        Debug.Log("======================================================== 2. ");
    }

    static string[] GetBuildScenes()
    {
        List<string> names = new List<string>();
        foreach (EditorBuildSettingsScene e in EditorBuildSettings.scenes)
        {
            if (e == null)
                continue;
            if (e.enabled)
                names.Add(e.path);
        }
        return names.ToArray();
    }
}
