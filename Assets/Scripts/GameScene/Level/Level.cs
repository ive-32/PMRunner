using System;
using System.Collections;
using System.Collections.Generic;
using GameScene.Extensions;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;

namespace GameScene.Level
{
    
    public class Level : MonoBehaviour
    {
        public const float DefaultGameSpeed = 5; // 5 tile per second
        public readonly Vector2Int LevelSize = new Vector2Int(3, 12);
        
        public float GameSpeed { get; set; } = DefaultGameSpeed;
        [FormerlySerializedAs("tiles")] public GameObject[] Tiles;


        // Start is called before the first frame update
        private void Start()
        {
            for (var i = 0; i < LevelSize.x; i++)
            for (var j = 0; j < LevelSize.y + 3; j++)
                Instantiate(Tiles.GetObjectByName("BaseTile"), new Vector3(i, j, 0), Quaternion.identity, transform);
        }

        // Update is called once per frame
        void Update()
        {
            
        }
    }

}
