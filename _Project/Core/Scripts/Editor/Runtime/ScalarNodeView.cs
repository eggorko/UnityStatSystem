using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    [NodeType(typeof(ScalarNode))]
    [Title("Math", "Scalar")]
    public class ScalarNodeView : NodeView
    {
        public ScalarNodeView()
        {
            title = "Scalar";
            node = ScriptableObject.CreateInstance<ScalarNode>();
            output = CreateOutputPort();
        }
    }

