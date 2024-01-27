using System.Linq;
using UnityEngine;

namespace GameScene.Level.Common
{
    public static class MemesSprites 
    {
        private static Sprite[] _sprites;
        private static bool _loaded;

        static MemesSprites()
        {
            LoadResources();
        }
        
        public static Sprite[] GetSprites()
        {
            if (!_loaded) 
                LoadResources();
            return _sprites;
        }

        public static Sprite GetSprite(string name)
        {
            if (!_loaded) 
                LoadResources();
            
            return _sprites.FirstOrDefault(s => s.name == name);
        }

        public static Sprite GetRandomSprite()
        {
            if (!_loaded) 
                LoadResources();
            return _sprites[Random.Range(0, _sprites.Length)];
        }
        
        public static void LoadResources()
        {
            _sprites = Resources.LoadAll<Sprite>("Memes/CompleteMemeTextures");
            _loaded = true;
        }
        
    }
}