using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractNode : ScriptableObject
{
    
    public Vector2 position;
    [HideInInspector]
    public string guid;
}
