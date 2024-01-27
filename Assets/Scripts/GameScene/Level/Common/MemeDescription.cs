using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GameScene.Level.Common
{
    [System.Serializable]
    public class MemeDescription
    {
        public string[] itemNames;
        public string memeName;
    }

    public static class MemeDescriptions
    {
        [System.Serializable]
        private class MemeDescriptionsContainer { public MemeDescription[] memes; }

        private static bool _isLoaded;
        private static List<MemeDescription> _memes;
        public static List<MemeDescription> Memes
        {
            get 
            { 
                if (!_isLoaded) LoadMemeDescriptions();
                return _memes; 
            }
        }

        public static void LoadMemeDescriptions()
        {
            if (_isLoaded) return;
            
            var targetFile = Resources.Load<TextAsset>("MemesDescription");

            var container = JsonUtility.FromJson<MemeDescriptionsContainer>(targetFile.ToString());
            
            _memes = container.memes.OrderBy(m => m.itemNames.Length).ToList();

            _isLoaded = true;
        }
    }

}