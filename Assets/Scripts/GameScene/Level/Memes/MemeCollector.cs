using System.Collections.Generic;
using System.Linq;
using GameScene.Level.Common;
using UnityEngine;

namespace GameScene.Level.Memes
{
    public class MemeCollector : MonoBehaviour
    {
        public List<MemeCollectorItem> MemeCollectorItems = new List<MemeCollectorItem>();

        public void Start()
        {
            for (var i = 0; i < MemeDescriptions.Memes.Count; i++)
            {
                var memeDescription = MemeDescriptions.Memes[i];
                var memeCollectorItem = new MemeCollectorItem(memeDescription);
                memeCollectorItem.MemeCollectorItemObject.transform.SetParent(transform);
                memeCollectorItem.MemeCollectorItemObject.transform.SetLocalPositionAndRotation(
                    new Vector3(0, MemeDescriptions.Memes.Count - i, 0), Quaternion.identity);
                MemeCollectorItems.Add(memeCollectorItem);
            }
            transform.SetPositionAndRotation(new Vector3(-6, Game.LevelSize.y - 4, 0), Quaternion.identity);
        }

        public void CollectMemeItem(string memeItemName)
        {
            var meme = MemeCollectorItems
                .FirstOrDefault(m => m.MemeItems
                    .Any(mi => !mi.IsCollected && mi.Name == memeItemName));

            var memeItem = meme?.MemeItems.FirstOrDefault(mi => !mi.IsCollected && mi.Name == memeItemName);
            if (memeItem != null)
                memeItem.IsCollected = true;
        }

        public void UseMeme()
        {
            var meme = MemeCollectorItems.FirstOrDefault(m => m.IsCollected);

            if (meme != null)
            {
                meme.MemeItems.ForEach(mi => mi.IsCollected = false);

                var memeObj = Instantiate(meme.MemePrefab, new Vector3(-5, Game.LevelSize.y / 2, 0), Quaternion.identity);
                memeObj.GetComponent<Meme>().MemeName = meme.MemeName;
            }
        }
    }
}