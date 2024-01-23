using GameScene.Extensions;
using UnityEngine;
using UnityEngine.Serialization;

namespace GameScene.Level
{
    
    public class Level : MonoBehaviour
    {
        [FormerlySerializedAs("tiles")] public GameObject[] Tiles;
        [FormerlySerializedAs("hero")] public GameObject Hero;


        // Start is called before the first frame update
        private void Start()
        {
            for (var i = 0; i < Game.LevelSize.x; i++)
            for (var j = 0; j < Game.LevelSize.y + 3; j++)
                Instantiate(Tiles.GetObjectByName("BaseTile"), new Vector3(i, j, 0), Quaternion.identity, transform);

            Instantiate(Hero, new Vector3(1, 2, 0), Quaternion.identity);
        }

        // Update is called once per frame
        void Update()
        {
            
        }
    }

}
