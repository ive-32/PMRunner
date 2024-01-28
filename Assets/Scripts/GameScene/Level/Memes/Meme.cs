
using UnityEngine;
using UnityEngine.UI;

namespace GameScene.Level.Memes
{
    public class Meme : MonoBehaviour
    {
        [System.NonSerialized] public string MemeName;
        private void Start()
        {
            var sprite = Resources.Load<Sprite>($"Memes/CompleteMemeTextures/{MemeName}");
            //var obj = transform.Find("ItemSprite");
            var image = transform.GetComponentInChildren<Image>();
            image.sprite = sprite;
            //obj.GetComponent<SpriteRenderer>().sprite = sprite;
            Destroy(gameObject, 3f);
            
        }
    }
}