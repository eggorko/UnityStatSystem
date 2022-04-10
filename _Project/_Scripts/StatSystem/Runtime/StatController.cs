using System;
using System.Collections.Generic;
using UnityEngine;

namespace newlinebraces.statsystem
{
    public class StatController : MonoBehaviour
    {
        [SerializeField]
        private StatDatabase statDataBase;
        protected Dictionary<string, Stat> _stats = new Dictionary<string, Stat>(StringComparer.OrdinalIgnoreCase);
        public Dictionary<string, Stat> stats => _stats;
        private bool isInitialized;
        public bool IsInitialized => isInitialized;
        public event Action initialized;
        public event Action willUnitialize;

        void Awake()
        {
         if(!IsInitialized)
            {
                Initialize();
                isInitialized = true;
                initialized?.Invoke();
            }
        }

        private void OnDestroy()
        {
            willUnitialize?.Invoke();
        }
        private void Initialize()
        {
            foreach(StatDefinition definition in statDataBase.stats)
            {
            stats.Add(definition.name, new Stat(definition));
            }

            foreach (StatDefinition definition in statDataBase.attributes)
            {
                stats.Add(definition.name, new Attribute(definition));
            }

            foreach (StatDefinition definition in statDataBase.primaryStats)
            {
                stats.Add(definition.name, new PrimaryStat(definition));
            }
        }
    }
}
