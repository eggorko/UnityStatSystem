using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
    public class TitleAttribute : Attribute
    {
        public string[] title;

        public TitleAttribute(params string[] title)
        {
            this.title = title;
        }
    }

