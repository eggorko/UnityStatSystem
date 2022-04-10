using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor.UIElements;
using UnityEditor.Callbacks;
using System;

public class NodeGraphEditor : EditorWindow
{

    //boop
    private NodeGraph nodeGraph;
    private NodeGraphView nodeGraphView;
    private VisualElement leftPanel;
    [MenuItem("Window/UI Toolkit/NodeGraphEditor")]
    public static void ShowWindow(NodeGraph nodeGraph)
    {
        NodeGraphEditor window = GetWindow<NodeGraphEditor>();
        window.SelectNodeGraph(nodeGraph);
        window.minSize = new Vector2(800, 600);
        window.titleContent = new GUIContent("NodeGraph");
    }

    [OnOpenAsset(1)]
    public static bool OnOpenAsset(int instanceID, int line)
    { 
        if(EditorUtility.InstanceIDToObject(instanceID) is NodeGraph nodeGraph)
        {
            ShowWindow(nodeGraph);
            return true;
        }
        return false;
    }

    private void OnSelectionChange()
    {
        if(Selection.activeObject is NodeGraph nodeGraph)
        {
            SelectNodeGraph(nodeGraph);
        }
    }

    private void SelectNodeGraph(NodeGraph nodeGraph)
    {
        this.nodeGraph = nodeGraph;
        nodeGraphView.PopulateView(nodeGraph);
    }

    public void CreateGUI()
    {
        VisualElement root = rootVisualElement;

        var visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/_Project/Core/Scripts/Editor/NodeGraphEditor.uxml");
        visualTree.CloneTree(root);
        var styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/_Project/Core/Scripts/Editor/NodeGraphEditor.uss");
        root.styleSheets.Add(styleSheet);

        leftPanel = root.Q("left-panel");
        nodeGraphView = root.Q<NodeGraphView>();
    }
}