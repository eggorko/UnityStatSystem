using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "NodeGraph", menuName = "Core/NodeGraph", order = 0)]
public class NodeGraph : ScriptableObject
{
    public CodeFunctionNode rootNode;
    public List<CodeFunctionNode> nodes = new List<CodeFunctionNode>();

    public void AddNode(CodeFunctionNode node)
    {
        nodes.Add(node);
        AssetDatabase.AddObjectToAsset(node, this);
        EditorUtility.SetDirty(this);
        AssetDatabase.SaveAssets();
    }
}

