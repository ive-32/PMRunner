using System;
using UnityEngine;

namespace GameScene.Level
{
    public class BaseTile : MonoBehaviour
    {

        [NonSerialized] public Level Level = default!;

        private void Awake()
        {
            Level = transform.GetComponentInParent<Level>();
        }

        private void Update()
        {
            transform.position += new Vector3(0, -Level.GameSpeed * Time.deltaTime, 0);
            if (transform.position.y <= -1)
                transform.SetPositionAndRotation(
                    new Vector3(transform.position.x, transform.position.y + Level.LevelSize.y + 2, 0), 
                    Quaternion.identity);
        }
    }
}