using UnityEngine;

namespace GameScene.Level.Memes
{
    public static class MemeItemTextures
    {
        private static Sprite[] _textures;
        private static bool _loaded;

        static MemeItemTextures()
        {
            LoadResources();
        }
        
        public static Sprite[] GetTextures()
        {
            if (!_loaded) 
                LoadResources();
            return _textures;
        }

        public static Sprite GetRandomTexture()
        {
            if (!_loaded) 
                LoadResources();
            return _textures[Random.Range(0, _textures.Length)];
        }
        
        public static void LoadResources()
        {
            _textures = Resources.LoadAll<Sprite>("Memes/Textures");
            _loaded = true;
        }
    }
}