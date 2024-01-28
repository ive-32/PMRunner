
using UnityEngine;

namespace GameScene.Level.Memes
{
    public class Meme : MonoBehaviour
    {
        [System.NonSerialized] public string MemeName;
        private void Start()
        {
            var sprite = Resources.Load<Sprite>($"Memes/CompleteMemeTextures/{MemeName}");
            var obj = transform.Find("ItemSprite");
            obj.GetComponent<SpriteRenderer>().sprite = sprite;
            Destroy(gameObject, 1f);
            
        }
    }
}