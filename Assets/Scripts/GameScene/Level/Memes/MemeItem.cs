using UnityEngine;
using Random = UnityEngine.Random;

namespace GameScene.Level.Memes
{
    public class MemeItem : MonoBehaviour
    {
        public string MemeName;
        private GameObject CurrentObject;
        protected void Awake()
        {
            var childCount = transform.childCount;
            for (var i = 0; i < childCount; i++)
            {
                var obj = transform.GetChild(i).gameObject;
                if (obj.name == "ItemSprite")
                    CurrentObject = obj;
            }
            
            var sprite = MemeItemSprites.GetRandomSprite();
            var spriteRenderer = CurrentObject.GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = sprite;
            MemeName = spriteRenderer.sprite.name;
        }

    }
}