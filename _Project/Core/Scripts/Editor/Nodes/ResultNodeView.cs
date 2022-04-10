using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultNodeView : NodeView
{
  public ResultNodeView()
    {
        title = "Result";
        inputs.Add(CreateInputPort());
    }
}
