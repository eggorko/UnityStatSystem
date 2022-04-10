
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;

namespace newlinebraces.statsystem
{ 
public class Stat
{
        protected StatDefinition definition;
        protected int Value;

        public virtual int baseValue => definition.baseValue;

        public int value => Value;

        public Action valueChanged;
        protected List<StatModifier> modifiers = new List<StatModifier>();
        public Stat(StatDefinition statDefinition)
        {
            definition = statDefinition;
            CalculateValue();
        }

        public void AddModifier(StatModifier modifier)
        {
            modifiers.Add(modifier);
            CalculateValue();
        }

        public void RemoveModifier(Object source)
        {
            modifiers = modifiers.Where(m => m.source.GetInstanceID() != source.GetInstanceID()).ToList();
            CalculateValue();
        }

        protected void CalculateValue()
        {
            int finalValue = baseValue;

            modifiers.Sort((x, y) => x.type.CompareTo(y.type));

            for(int i = 0; i < modifiers.Count; i++)
            {
                StatModifier modifier = modifiers[i];

                if(modifier.type == ModifierType.Addative)
                {
                    finalValue += modifier.magnitude;
                }else if (modifier.type == ModifierType.Multiplicative)
                {
                    finalValue *= modifier.magnitude;
                }

            }

            if (definition.cap >= 0)
            {
                finalValue = Mathf.Min(finalValue, definition.cap);
            }

            if (finalValue != Value)
            {
                Value = finalValue;
                valueChanged?.Invoke();
            }
        }

    }

}