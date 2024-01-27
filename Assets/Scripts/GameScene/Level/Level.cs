using GameScene.Extensions;
using GameScene.Level.Blockers;
using GameScene.Level.Common;
using GameScene.Level.Memes;
using UnityEngine;
using UnityEngine.Serialization;

namespace GameScene.Level
{
    
    public class Level : MonoBehaviour
    {
        [FormerlySerializedAs("tiles")] public GameObject[] Tiles;
        [FormerlySerializedAs("hero")] public GameObject Hero;

        private GameObject _blockers;
        private GameObject _memeItems;
        private GameObject _floorTiles;
        
        // Start is called before the first frame update
        private void Start()
        {
            MemeItemSprites.LoadResources();
            MemeDescriptions.LoadMemeDescriptions();
            
            _blockers = CreateEmptyChildContainer("Blockers");
            _blockers.gameObject.AddComponent<BlockerGenerator>();

            _memeItems = CreateEmptyChildContainer("MemeItems");
            _memeItems.gameObject.AddComponent<MemeItemsGenerator>();

            _floorTiles = CreateEmptyChildContainer("FloorItems");

            for (var i = 0; i < Game.LevelSize.x; i++)
            for (var j = 0; j < Game.LevelSize.y + 3; j++)
                Instantiate(Tiles.GetObjectByName("BaseTile"), new Vector3(i, j, 0), Quaternion.identity, _floorTiles.transform);

            Instantiate(Hero, new Vector3(Game.LevelSize.x / 2, 2, 0), Quaternion.identity, transform);
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
