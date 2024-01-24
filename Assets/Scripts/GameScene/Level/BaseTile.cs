using System;
using UnityEngine;

namespace GameScene.Level
{
    public class BaseTile : MonoBehaviour
    {

        private void Update()
        {
            transform.position += new Vector3(0, -Game.PlayerMovingSpeed * Time.deltaTime, 0);
            if (transform.position.y <= -1)
                transform.SetPositionAndRotation(
                    new Vector3(transform.position.x, transform.position.y + Game.LevelSize.y + 2, 0), 
                    Quaternion.identity);
        }
    }
}