using UnityEngine;

namespace newlinebraces.statsystem
{
    [CreateAssetMenu(fileName = "StatDefinition", menuName = "StatSystem/StatDefinition", order = 0)]
    public class StatDefinition : ScriptableObject
    {
        [SerializeField]
        private int BaseValue;
        [SerializeField]
        private int Cap = -1;
        public int baseValue => BaseValue; 
        public int cap => Cap; 
    }
}
