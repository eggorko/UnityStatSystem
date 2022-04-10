using NUnit.Framework;
using System.Collections;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

namespace newlinebraces.statsystem
{
    public class AttributesTests
    {

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            EditorSceneManager.LoadSceneInPlayMode("Assets/_Project/_Scripts/StatSystem/Test/Scenes/Test.unity", new LoadSceneParameters(LoadSceneMode.Single));
        }

        [UnityTest]
        public IEnumerator Attribute_WhenModifierApplied_DoesNotExceedMaxValue()
        {
            yield return null;
            StatController statController = GameObject.FindObjectOfType<StatController>();
            Attribute health = statController.stats["Health"] as Attribute;
            Assert.AreEqual(100, health.currentValue);
            Assert.AreEqual(100, health.value);
            health.ApplyModifier(new StatModifier { magnitude = 10, type = ModifierType.Addative });
            Assert.AreEqual(100, health.currentValue);
        }
        [UnityTest]
        public IEnumerator Attribute_WhenModifierApplied_DoesGoBelowZero()
        {
            yield return null;
            StatController statController = GameObject.FindObjectOfType<StatController>();
            Attribute health = statController.stats["Health"] as Attribute;
            Assert.AreEqual(100, health.currentValue);
            Assert.AreEqual(100, health.value);
            health.ApplyModifier(new StatModifier { magnitude = -150, type = ModifierType.Addative });
            Assert.AreEqual(0, health.currentValue);
        }
    }
}