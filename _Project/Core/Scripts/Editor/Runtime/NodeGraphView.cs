using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public class NodeGraphView : GraphView
{
    public new class UxmlFactory : UxmlFactory<NodeGraphView, UxmlTraits> { }

    private NodeGraph NodeGraph;

    public NodeGraphView()
    {
        this.AddManipulator(new ContentZoomer());
        this.AddManipulator(new ContentDragger());
        this.AddManipulator(new SelectionDragger());
        this.AddManipulator(new RectangleSelector());

        SetupZoom(ContentZoomer.DefaultMinScale, ContentZoomer.DefaultMaxScale);

        GridBackground gridBackground = new GridBackground();
        Insert(0, gridBackground);
        gridBackground.StretchToParentSize();


        var styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/_Project/Core/Scripts/Editor/NodeGraphEditor.uss");

        styleSheets.Add(styleSheet);
     }

    internal void PopulateView(NodeGraph nodeGraph)
    {
        NodeGraph = nodeGraph;
        if(NodeGraph.rootNode == null)
        {
            NodeGraph.rootNode = ScriptableObject.CreateInstance<ResultNode>();
            NodeGraph.rootNode.name = nodeGraph.rootNode.GetType().Name;
            NodeGraph.rootNode.guid = GUID.Generate().ToString();
            NodeGraph.AddNode(nodeGraph.rootNode);
        }

        NodeGraph.nodes.ForEach(n => CreateAndAddNodeView(n));
    }
 
    private void CreateAndAddNodeView(CodeFunctionNode node)
    {
        Type[] types = AppDomain.CurrentDomain.GetAssemblies().SelectMany(assambley => assambley.GetTypes())
        .Where(type => typeof(NodeView).IsAssignableFrom(type) && type.IsClass && !type.IsAbstract).ToArray();

        foreach(Type type in types)
        {
            if(type.GetCustomAttributes(typeof(NodeType), false) is NodeType[] attrs && attrs.Length > 0)
            {
                if(attrs[0].type == node.GetType())
                {
                    NodeView nodeView = (NodeView)Activator.CreateInstance(type);
                    nodeView.node = node;
                    nodeView.viewDataKey = node.guid;
                    nodeView.style.left = node.position.x;
                    nodeView.style.top = node.position.y;
                    AddElement(nodeView);
                }
            }
        }

    }
}
