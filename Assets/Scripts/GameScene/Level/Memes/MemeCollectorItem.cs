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
                    SpriteRenderer.color = _isCollected ? CollectedColor : UncollectedColor;
                }
            }
            public string Name;
            public SpriteRenderer SpriteRenderer;
        }
        
        private static readonly Color UncollectedColor = new Color(0.5f, 0.5f, 0.5f);
        private static readonly Color CollectedColor = new Color(0.5f, 1f, 0.8f);
        
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
                memeItem.GetComponent<SpriteRenderer>().color = UncollectedColor;
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