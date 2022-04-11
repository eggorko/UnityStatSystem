using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[NodeType(typeof(ResultNode))]
public class ResultNodeView : NodeView
{
  public ResultNodeView()
    {
        title = "Result";
        inputs.Add(CreateInputPort());
    }
}
