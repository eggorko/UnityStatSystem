using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace newlinebraces.statsystem
{
    [CreateAssetMenu(fileName = "StatDatabase", menuName = "StatSystem/StatDatabase", order = 1)]
    public class StatDatabase : ScriptableObject
    {
        public List<StatDefinition> stats;
        public List<StatDefinition> attributes;
        public List<StatDefinition> primaryStats;
    }
}
