using SyntaxTree.VisualStudio.Unity.Bridge;
using UnityEditor;

[InitializeOnLoad]
public class UnityVSFixEditorResourcesScriptPaths
{
    static UnityVSFixEditorResourcesScriptPaths()
    {
        ProjectFilesGenerator.ProjectFileGeneration += (name, content) =>
        {
            content = content.Replace("UnityPackageManager\\com.unity.editor.resources", "C:\\work\\unity\\External\\PackageManager\\Editor\\com.unity.editor.resources\\package");
            return content;
        };
    }
}

[InitializeOnLoad]
public class UnityVSProjectGenerationFix
{
    static UnityVSProjectGenerationFix()
    {
        ProjectFilesGenerator.ProjectFileGeneration += (name, content) =>
        {
            content = content.Replace("</AssemblyName>", EditorSettings.Internal_UserGeneratedProjectSuffix + "</AssemblyName>");
            return content;
        };
    }
}
