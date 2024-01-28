using System;
using GameScene.Extensions;
using GameScene.Level.Blockers;
using GameScene.Level.Memes;
using UnityEngine;
using UnityEngine.Serialization;
using System.Collections.Generic;
using Random = UnityEngine.Random;

namespace GameScene.Level
{
    public class RoadGenerator : MonoBehaviour
    {
        /**
         * Streets for auto generation
         */
        public List<GameObject> streets;
        
        /**
         * Visiable road from streets
         */
        public List<GameObject> road;
        
        /**
         * Player for detect current position
         */
        public GameObject playerObject;

        /**
         * Add new Street when go more then first road
         */
        void Update()
        {
            float offset = road[0].transform.position.z + road[0].GetComponent<Collider>().bounds.size.z;
            if (playerObject.transform.position.z > offset)
            {
                int randomNumberOfStreet = Mathf.FloorToInt(Random.Range(0, streets.Count));
                AddStreet(randomNumberOfStreet);
            }
        }

        /**
         * Add next street block
         */
        public void AddStreet(int streetNumber = 0)
        {
            GameObject street = streets[streetNumber];
            GameObject firstRoadBlock = road[0];
            float lastOffsetZ = road[road.Count - 1].transform.position.z + road[road.Count - 1].GetComponent<Collider>().bounds.size.z;
                
            street = Instantiate(street, new Vector3(0,0,lastOffsetZ), Quaternion.identity);
            street.transform.parent = transform;
            
            road.Add(street);
            road.Remove(firstRoadBlock);
            Destroy(firstRoadBlock);
        }
    }
}
