using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
[assembly: InternalsVisibleTo("StatSystem.Tests")]
namespace newlinebraces.statsystem
{
    public class PrimaryStat : Stat
    {
        private int BaseValue;
        public override int baseValue => BaseValue;

        public PrimaryStat(StatDefinition statDefinition) : base(statDefinition)
        {
            BaseValue = statDefinition.baseValue;
            CalculateValue();
        }

        internal void Add(int amount)
        {
            BaseValue += amount;
            CalculateValue();
        }

        internal void Subtract(int amount)
        {
            BaseValue -= amount;
            CalculateValue();
        }
    }
    }