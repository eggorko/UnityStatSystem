using UnityEngine;

namespace newlinebraces.statsystem
{
    public enum ModifierType 
    {
        Addative,
        Multiplicative,
        Override
    }

    public class StatModifier
    {
        public Object source { get; set; }
        public int magnitude { get; set; }
        public ModifierType type { get; set; }

    }
}
