using System;
using UnityEngine;

namespace newlinebraces.statsystem
{
    public class Attribute : Stat
    {
    //boop
        protected int CurrentValue;
        public int currentValue => CurrentValue;
        public event Action currentValueChanged;
        public event Action<StatModifier> appliedModifier;

        public Attribute(StatDefinition statDefinition) : base(statDefinition)
        {
            CurrentValue = value;
        }

        public virtual void ApplyModifier(StatModifier modifier)
        {
            int finalValue = CurrentValue;
            switch (modifier.type)
            {
                case ModifierType.Override:
                    finalValue = modifier.magnitude;
                    break;
                case ModifierType.Addative:
                    finalValue += modifier.magnitude;
                    break;
                case ModifierType.Multiplicative:
                    finalValue *= modifier.magnitude;
                    break;
            }
            finalValue = Mathf.Clamp(finalValue, 0, value); 

            if(currentValue != finalValue)
            {
                CurrentValue = finalValue;
                currentValueChanged?.Invoke();
                appliedModifier?.Invoke(modifier);
            }
        }
    }
}
