using NUnit.Framework;
using System.Collections;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

namespace newlinebraces.statsystem
{

    public class PrimaryStatsTests 
    {
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            EditorSceneManager.LoadSceneInPlayMode("Assets/_Project/_Scripts/StatSystem/Test/Scenes/Test.unity", new LoadSceneParameters(LoadSceneMode.Single));
        }

        [UnityTest]
        public IEnumerator Attribute_WhenAddCalled_ChangeBaseValue()
        {
            yield return null;
            StatController statController = GameObject.FindObjectOfType<StatController>();
            PrimaryStat strength = statController.stats["Strength"] as PrimaryStat;
            Assert.AreEqual(1, strength.value);
            strength.Add(1);
            Assert.AreEqual(2, strength.value);
        }

    }
}