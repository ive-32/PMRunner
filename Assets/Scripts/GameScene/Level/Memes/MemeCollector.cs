using System.Collections.Generic;
using System.Linq;
using GameScene.Level.Common;
using UnityEngine;

namespace GameScene.Level.Memes
{
    public class MemeCollector : MonoBehaviour
    {
        public List<MemeCollectorItem> MemeCollectorItems = new List<MemeCollectorItem>();
        public GameObject targetContainer;

        public void Start()
        {
            transform.SetParent(targetContainer.transform);
            transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
            transform.name = "MemeCollector";
            for (var i = 0; i < MemeDescriptions.Memes.Count; i++)
            {
                var memeDescription = MemeDescriptions.Memes[i];
                var memeCollectorItemObject = new GameObject();
                memeCollectorItemObject.transform.name = $"MemeCollectorItem{i}";
                memeCollectorItemObject.transform.SetParent(transform);
                memeCollectorItemObject.transform.SetLocalPositionAndRotation(
                    new Vector3(-0.5f, 1.25f - i * 0.25f, 0), Quaternion.identity);
                var memeCollectorItem = memeCollectorItemObject.AddComponent<MemeCollectorItem>();
                memeCollectorItem.description = memeDescription;

                MemeCollectorItems.Add(memeCollectorItem);
            }
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

        public int UseMeme()
        {
            var meme = MemeCollectorItems.FirstOrDefault(m => m.IsCollected);

            if (meme != null)
            {
                meme.MemeItems.ForEach(mi => mi.IsCollected = false);
                var memePrefab = Resources.Load<GameObject>("Memes/MemeImage");
                var memeObj = Instantiate(
                    memePrefab,
                    targetContainer.transform.parent);
                //memeObj.transform.SetLocalPositionAndRotation(new Vector3(1200,-500,0), Quaternion.identity);
                memeObj.GetComponent<Meme>().MemeName = meme.MemeName;
                memeObj.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
                memeObj.name = "MemeCompleted";
                return meme.MemeItems.Count;
            }

            return 0;
        }
    }
}