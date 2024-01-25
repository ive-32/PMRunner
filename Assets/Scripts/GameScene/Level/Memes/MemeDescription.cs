using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GameScene.Level.Memes
{
    [System.Serializable]
    public class MemeDescription
    {
        public string[] itemNames;
        public string memeName;

        [System.NonSerialized] public GameObject[] Items;
        [System.NonSerialized] public GameObject Meme;
    }

    public static class MemeDescriptions
    {
        [System.Serializable]
        private class MemeDescriptionsContainer { public MemeDescription[] memes; }
        
        public static List<MemeDescription> Memes;

        public static void LoadMemeDescriptions()
        {
            var targetFile = Resources.Load<TextAsset>("MemesDescription");

            var container = JsonUtility.FromJson<MemeDescriptionsContainer>(targetFile.ToString());
            
            Memes = container.memes.OrderBy(m => m.itemNames.Length).ToList();
        }
    }

}