using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AssetBundleTester : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
public class ExportAssetBundles {
    [MenuItem("Assets/Build AssetBundle From Selection - Track dependencies")]
    static void ExportResource () {
        // Bring up save panel
        string path = EditorUtility.SaveFilePanel ("Save Resource", "", "New Resource", "unity3d");
        if (path.Length != 0) {
            // Build the resource file from the active selection.
            Object[] selection = Selection.GetFiltered(typeof(Object), SelectionMode.DeepAssets);
            BuildPipeline.BuildAssetBundles(Selection.activeObject, selection, path, 
                BuildAssetBundleOptions.CollectDependencies | BuildAssetBundleOptions.CompleteAssets);
            Selection.objects = selection;
        }
    }
    [MenuItem("Assets/Build AssetBundle From Selection - No dependency tracking")]
    static void ExportResourceNoTrack () {
        // Bring up save panel
        string path = EditorUtility.SaveFilePanel ("Save Resource", "", "New Resource", "unity3d");
        if (path.Length != 0) {
            // Build the resource file from the active selection.
            BuildPipeline.BuildAssetBundle(Selection.activeObject, Selection.objects, path);
        }
    }
}