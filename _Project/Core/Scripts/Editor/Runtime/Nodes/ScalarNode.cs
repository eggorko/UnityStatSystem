using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class ScalarNode : CodeFunctionNode
    {
        [SerializeField] protected float m_Value;
        public override float value => m_Value;
    }
