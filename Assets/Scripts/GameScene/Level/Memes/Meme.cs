
using UnityEngine;

namespace GameScene.Level.Memes
{
    public class Meme : BaseLevelObject
    {
        [System.NonSerialized] public string MemeName;
        private void Start()
        {
            var sprite = Resources.Load<Sprite>($"Memes/CompleteMemeTextures/{MemeName}");
            
            CurrentObject.GetComponent<SpriteRenderer>().sprite = sprite;
            Destroy(gameObject, 1);
        }
    }
}