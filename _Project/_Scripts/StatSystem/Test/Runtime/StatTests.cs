using System.Collections;
using NUnit.Framework;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

namespace newlinebraces.statsystem 
{
    public class StatTests
    {
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            EditorSceneManager.LoadSceneInPlayMode("Assets/_Project/_Scripts/StatSystem/Test/Scenes/Test.unity", new LoadSceneParameters(LoadSceneMode.Single));
        }

        [UnityTest]
        public IEnumerator Stat_WhenModifierApplied_ValueChanged()
        {
            yield return null;
            StatController statController = GameObject.FindObjectOfType<StatController>();
            Stat physicalAttack = statController.stats["PhysicalAttack"];
            Assert.AreEqual(0, physicalAttack.value); 
            physicalAttack.AddModifier(new StatModifier {magnitude = 5, type = ModifierType.Addative });
            Assert.AreEqual(5, physicalAttack.value);

        }

        [UnityTest]
        public IEnumerator Stat_WhenModifierApplied_DosentExceedCap()
        {
            yield return null;
            StatController statController = GameObject.FindObjectOfType<StatController>();
            Stat attackSpeed = statController.stats["AttackSpeed"];
            Assert.AreEqual(0, attackSpeed.value);
            attackSpeed.AddModifier(new StatModifier { magnitude = 10, type = ModifierType.Addative });
            Assert.AreEqual(5, attackSpeed.value);

        }
    }
}


