using GameScene.Extensions;
using GameScene.Level.Blockers;
using GameScene.Level.Memes;
using UnityEngine;
using UnityEngine.Serialization;

namespace GameScene.Level
{
    
    public class Level : MonoBehaviour
    {
        private GameObject _memeItems;
        
        // Start is called before the first frame update
        private void Start()
        {
            MemeItemSprites.LoadResources();
            MemeDescriptions.LoadMemeDescriptions();

            //_memeItems = CreateEmptyChildContainer("MemeItems");
            //var memeItemsClass = _memeItems.gameObject.AddComponent<MemeItemsGenerator>();
            //memeItemsClass.road = transform.Find("Road").gameObject;
        }

        private GameObject CreateEmptyChildContainer(string containerName)
            => new GameObject(containerName)
                {
                    transform =
                    {
                        parent = transform,
                        position = Vector3.zero
                    }
                };
    }

}
