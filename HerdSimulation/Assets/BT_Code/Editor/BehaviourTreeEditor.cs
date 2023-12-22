using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class BehaviourTreeEditor : EditorWindow
{
    [MenuItem("Behaviour Tree/Editor")]
    public static void OpenWindow()
    {
        BehaviourTreeEditor wnd = GetWindow<BehaviourTreeEditor>();
        wnd.titleContent = new GUIContent("Behaviour Tree Editor");
    }

    public void CreateGUI()
    {
        // Each editor window contains a root VisualElement object
        VisualElement root = rootVisualElement;

        // Instantiate UXML
        CloneVisualTree(root);


        FindAndSetStyleSheet(root);
    }
   
    void CloneVisualTree(VisualElement root)
    {
        string[] locations = AssetDatabase.FindAssets("BehaviourTreeEditor");

        string uxmlPath = "";

        foreach (var item in locations)
        {
            string tempString = AssetDatabase.GUIDToAssetPath(item);
            //Debug.Log(tempString);

            if (tempString.EndsWith(".uxml"))
            {
                //Debug.Log("FOUND UXML");
                uxmlPath = tempString;
            }
        }

        if (uxmlPath != "")
        {
            var visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>(uxmlPath);
            visualTree.CloneTree(root);
        }
    }

    void FindAndSetStyleSheet(VisualElement root)
    {
        string[] locations = AssetDatabase.FindAssets("BehaviourTreeEditor");

        string ussPath = "";

        foreach (var item in locations)
        {
            string tempString = AssetDatabase.GUIDToAssetPath(item);
            //Debug.Log(tempString);

            if (tempString.EndsWith(".uss"))
            {
                //Debug.Log("FOUND USS");
                ussPath = tempString;
            }
        }

        if (ussPath != "")
        {
            var styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>(ussPath);
            root.styleSheets.Add(styleSheet);
        }
    }

}
