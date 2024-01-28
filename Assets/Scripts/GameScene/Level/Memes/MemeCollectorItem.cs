using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

namespace GameScene.Level.Memes
{
    public class MemeCollectorItem : MonoBehaviour
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
        public GameObject MemePrefab;
        public string MemeName;
        
        public bool IsCollected => MemeItems.All(m => m.IsCollected);


        public MemeDescription description;
        void Start()
        {
            MemeItems = description.itemNames
                .Select(CreateMemeItemObject)
                .ToList();

            for (var i = 0; i < MemeItems.Count; i++)
            {
                var memeItem = MemeItems[i].MemeItem.gameObject; 
                memeItem.transform.SetParent(transform);
                memeItem.transform.SetLocalPositionAndRotation(new Vector3(i * 0.25f, 0, 0), Quaternion.identity);
                memeItem.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                Color currentColor = memeItem.GetComponent<SpriteRenderer>().color;
                currentColor.a = UncollectedAlpha;
                memeItem.GetComponent<SpriteRenderer>().color = currentColor;
            }

            //MemePrefab = Resources.Load<GameObject>("Memes/Meme");
            MemePrefab = Resources.Load<GameObject>("Memes/MemeImage");
            MemeName = description.memeName;

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