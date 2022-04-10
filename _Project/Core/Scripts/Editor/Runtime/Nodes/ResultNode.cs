using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultNode : CodeFunctionNode
{
    [HideInInspector]
    public CodeFunctionNode child;

    public override float value => child.value;
}
