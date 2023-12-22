using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor.Callbacks;
using Unity.VisualScripting;
using System;

public class BehaviourTreeEditor : EditorWindow
{
    BehaviourTreeView treeView;
    InspectorView inspectorView;

    [MenuItem("Behaviour Tree/Editor")]
    public static void OpenWindow()
    {
        BehaviourTreeEditor wnd = GetWindow<BehaviourTreeEditor>();
        wnd.titleContent = new GUIContent("Behaviour Tree Editor");
    }

    [OnOpenAsset]
    public static bool OnOpenAsset(int instanceId, int line)
    {
        if (Selection.activeObject is BehaviourTree)
        {
            OpenWindow();
            return true;
        }

        return false;
    }

    public void CreateGUI()
    {
        // Each editor window contains a root VisualElement object
        VisualElement root = rootVisualElement;

        // Instantiate UXML
        CloneVisualTree(root);


        FindAndSetStyleSheet(root);

        treeView = root.Q<BehaviourTreeView>();
        inspectorView = root.Q<InspectorView>();
        treeView.OnNodeSelected = OnNodeSelectionChanged;
        OnSelectionChange();
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

    private void OnEnable()
    {
        EditorApplication.playModeStateChanged -= OnPlayModeStateChanged;
        EditorApplication.playModeStateChanged += OnPlayModeStateChanged;
    }

    private void OnDisable()
    {
        EditorApplication.playModeStateChanged -= OnPlayModeStateChanged;
    }
    private void OnPlayModeStateChanged(PlayModeStateChange obj)
    {
        switch (obj)
        {
            case PlayModeStateChange.EnteredEditMode:
                OnSelectionChange();
                break;
            case PlayModeStateChange.ExitingEditMode:
                break;
            case PlayModeStateChange.EnteredPlayMode:
                OnSelectionChange();
                break;
            case PlayModeStateChange.ExitingPlayMode:
                break;
        }
        
    }

    private void OnSelectionChange()
    {
        BehaviourTree tree = Selection.activeObject as BehaviourTree;
        if (!tree)
        {
            if (Selection.activeObject != null)
            {
                BehaviourTreeRunner runner = Selection.activeObject.GetComponent<BehaviourTreeRunner>();
                if (runner != null)
                {
                    tree = runner.tree;
                }
            }
        }

        if (Application.isPlaying)
        {
            if (tree)
            {
                treeView?.PopulateView(tree);
            }
        }
        else
        {
            if (tree && AssetDatabase.CanOpenAssetInEditor(tree.GetInstanceID()))
            {
                treeView?.PopulateView(tree);
            }
        }
    }

    void OnNodeSelectionChanged(NodeView nodeView)
    {
        inspectorView.UpdateSelection(nodeView);
    }

    private void OnInspectorUpdate()
    {
        treeView?.UpdateNodeStates();
    }
}
