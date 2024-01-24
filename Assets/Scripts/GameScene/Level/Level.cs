using GameScene.Extensions;
using UnityEngine;
using UnityEngine.Serialization;

namespace GameScene.Level
{
    
    public class Level : MonoBehaviour
    {
        [FormerlySerializedAs("tiles")] public GameObject[] Tiles;
        [FormerlySerializedAs("hero")] public GameObject Hero;

        private GameObject _blockers;
        private GameObject _bonusItems;
        private GameObject _floorTiles;
        
        // Start is called before the first frame update
        private void Start()
        {
            _blockers = CreateEmptyChildContainer("Blockers");
            _blockers.gameObject.AddComponent<Blockers>();

            _blockers = CreateEmptyChildContainer("BonusItems");
            _blockers.gameObject.AddComponent<Bonuses.Bonuses>();
            
            for (var i = 0; i < Game.LevelSize.x; i++)
            for (var j = 0; j < Game.LevelSize.y + 3; j++)
                Instantiate(Tiles.GetObjectByName("BaseTile"), new Vector3(i, j, 0), Quaternion.identity, transform);

            Instantiate(Hero, new Vector3(1, 2, 0), Quaternion.identity, transform);
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
