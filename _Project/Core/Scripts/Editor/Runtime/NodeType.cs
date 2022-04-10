using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AttributeUsage(AttributeTargets.Class, Inherited = false)]
public class NodeType : Attribute
{
    public readonly Type type;

    public NodeType(Type type)
    {
        this.type = type;
    }
}
