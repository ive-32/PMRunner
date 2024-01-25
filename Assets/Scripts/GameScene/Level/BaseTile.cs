using System;
using UnityEngine;

namespace GameScene.Level
{
    public class BaseTile : MonoBehaviour
    {

        private void Update()
        {
            transform.position += new Vector3(-Game.PlayerMovingSpeed * Time.deltaTime, 0, 0);
            if (transform.position.x <= -1)
                transform.SetPositionAndRotation(
                    new Vector3(transform.position.x + Game.LevelSize.x + 2, transform.position.y, 0), 
                    Quaternion.identity);
        }
    }
}