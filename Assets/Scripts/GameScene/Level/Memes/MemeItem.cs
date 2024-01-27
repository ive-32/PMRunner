using GameScene.Level.Common;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GameScene.Level.Memes
{
    public class MemeItem : BaseLevelObject
    {
        public string MemeName;
        protected override void Awake()
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
            spriteRenderer.color = Random.ColorHSV(0, 1, 1, 1, 1, 1);
            spriteRenderer.sprite = sprite;
            CurrentObject.transform.localScale = new Vector3(0.5f, 0.5f, 1);
            MemeName = spriteRenderer.sprite.name;
        }

    }
}