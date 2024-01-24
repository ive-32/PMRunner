using System.Collections.Generic;
using GameScene.Extensions;
using UnityEngine;
using UnityEngine.Serialization;

namespace GameScene.Level
{
    
    public class Level : MonoBehaviour
    {
        [FormerlySerializedAs("tiles")] public GameObject[] Tiles;
        [FormerlySerializedAs("hero")] public GameObject Hero;
        [FormerlySerializedAs("rack")] public GameObject Blocker;

        private GameObject _objects;
        private GameObject _floorTiles;
        private float _timeToAppearBlocker = 1;
        
        // Start is called before the first frame update
        private void Start()
        {
            _objects = CreateEmptyChildContainer("Objects");
            
            for (var i = 0; i < Game.LevelSize.x; i++)
            for (var j = 0; j < Game.LevelSize.y + 3; j++)
                Instantiate(Tiles.GetObjectByName("BaseTile"), new Vector3(i, j, 0), Quaternion.identity, transform);

            Instantiate(Hero, new Vector3(1, 2, 0), Quaternion.identity, transform);
        }

        // Update is called once per frame
        void Update()
        {
            if (_timeToAppearBlocker <= 0)
            {
                var rackCoord = Random.Range(0, 3);
                Instantiate(Blocker, new Vector3(rackCoord, 12, 0), Quaternion.identity, _objects.transform);
                _timeToAppearBlocker = Random.Range(0.3f, 1f);
            }

            _timeToAppearBlocker -= Time.deltaTime;
        }

        public List<GameObject> GetNearestObjects(Vector3 position, float radius = 1)
        {
            var childCount = _objects.transform.childCount; 
            var nearestObjects = new List<GameObject>(childCount);
            
            for (var i = 0; i < childCount; i++)
            {
                var obj = _objects.transform.GetChild(i);
                if ((obj.transform.position - position).magnitude <= radius)
                    nearestObjects.Add(obj.gameObject);
            }

            return nearestObjects;
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
