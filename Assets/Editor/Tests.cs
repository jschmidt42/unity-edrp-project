using System;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class Tests
{
    [MenuItem("ERDP/Package Access Tests")]
    public static void PackageAccessTests()
    {
        var assetPath = "Assets/Utilities/Editor/Converter.cs";
        var asset = AssetDatabase.LoadAssetAtPath<UnityEngine.Object>(assetPath);
        Debug.Log(String.Format("File.Exists({0}) returns {1}", assetPath, File.Exists(assetPath)));
        Debug.Log(String.Format("Asset object {0} exists at {1}", assetPath, AssetDatabase.GetAssetPath(asset)));

        assetPath = AssetDatabase.GetAssetPath(asset); //"UnityPackageManager/com.unity.editor.resources/Assets/Utilities/Editor/Converter.cs";
        asset = AssetDatabase.LoadAssetAtPath<UnityEngine.Object>(assetPath);
        Debug.Log(String.Format("File.Exists({0}) returns {1}", assetPath, File.Exists(assetPath)));
        Debug.Log(String.Format("Asset object {0} named {1}", assetPath, asset.name));

        assetPath = "Assets/Editor/Tests.cs";
        Debug.Log(String.Format("File.Exists({0}) returns {1}", assetPath, File.Exists(assetPath)));
        
        var assetPaths = AssetDatabase.GetAllAssetPaths().Where(p => p.EndsWith(".cs"));
        Debug.Log(String.Format("Assets {0}", String.Join(", ", assetPaths.ToArray())));

        //TODO: AssetDatabase.GetPackageRootPath("com.unity.editor.resources");
        //TODO: AssetDatabase.GetPackageAssetPath("UnityPackageManager/com.unity.editor.resources/Assets/Utilities/Editor/Converter.cs");
    }

    [MenuItem("ERDP/Get Icon Tests")]
    public static void GetIcon()
    {
        var iconTexture = EditorGUIUtility.FindTexture("UxmlScript Icon");
        Debug.Log(String.Format("Icon {0} exists at {1}", iconTexture.name, AssetDatabase.GetAssetPath(iconTexture)));

        iconTexture = EditorGUIUtility.FindTexture("UssScript Icon");
        Debug.Log(String.Format("Icon {0} exists at {1}", iconTexture.name, AssetDatabase.GetAssetPath(iconTexture)));

        iconTexture = EditorGUIUtility.FindTexture("StyleSheet Icon");
        Debug.Log(String.Format("Icon {0} exists at {1}", iconTexture.name, AssetDatabase.GetAssetPath(iconTexture)));
    }
}
