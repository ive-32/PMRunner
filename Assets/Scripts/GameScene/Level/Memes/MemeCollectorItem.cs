using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GameScene.Level.Memes
{
    public class MemeCollectorItem
    {
        public class MemeCollectorItemMemeItem
        {
            private bool _isCollected;
            public GameObject MemeItem;
            public bool IsCollected
            {
                get => _isCollected; 
                set
                {
                    _isCollected = value;
                    Color currentColor = SpriteRenderer.color;
                    currentColor.a = _isCollected ? CollectedAlpha : UncollectedAlpha;
                    SpriteRenderer.color = currentColor;
                }
            }
            public string Name;
            public SpriteRenderer SpriteRenderer;
        }
        
        private static readonly float UncollectedAlpha = 0.3f;
        private static readonly float CollectedAlpha = 1f;
        
        public List<MemeCollectorItemMemeItem> MemeItems;
        public GameObject Meme;
        
        public bool IsCollected => MemeItems.All(m => m.IsCollected);

        public readonly GameObject MemeCollectorItemObject;

        public MemeCollectorItem(MemeDescription description)
        {
            MemeCollectorItemObject = new GameObject();
            MemeItems = description.itemNames
                .Select(CreateMemeItemObject)
                .ToList();

            for (var i = 0; i < MemeItems.Count; i++)
            {
                var memeItem = MemeItems[i].MemeItem.gameObject; 
                memeItem.transform.SetParent(MemeCollectorItemObject.transform);
                memeItem.transform.SetLocalPositionAndRotation(new Vector3(i, 0, 0), Quaternion.identity);
                Color currentColor = memeItem.GetComponent<SpriteRenderer>().color;
                currentColor.a = UncollectedAlpha;
                memeItem.GetComponent<SpriteRenderer>().color = currentColor;
            }
        }

        private MemeCollectorItemMemeItem CreateMemeItemObject(string name)
        {
            var gameObject = new GameObject();
            var spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
            spriteRenderer.sprite = MemeItemSprites.GetSprite(name);
            return new MemeCollectorItemMemeItem
                {
                    MemeItem = gameObject,
                    SpriteRenderer = spriteRenderer,
                    Name = name,
                    IsCollected = false,
                };
        }
    }
}