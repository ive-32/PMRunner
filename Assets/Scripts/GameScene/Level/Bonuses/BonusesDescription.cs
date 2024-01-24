using UnityEngine;

namespace GameScene.Level.Bonuses
{
    [System.Serializable]
    public class BonusesDescription
    {
        public string[] itemNames;
        public string memeName;

        [System.NonSerialized] public GameObject[] Items;
        [System.NonSerialized] public GameObject Meme;
    }
    
    [System.Serializable]
    public class BonusesDescriptions
    {
        public BonusesDescription[] memes;
    }

}