using UnityEngine;

namespace GameScene.Level
{
    public abstract class BaseLevelObject : MonoBehaviour
    {
        protected virtual void Update()
        {
            transform.position += new Vector3(0, -Game.PlayerMovingSpeed * Time.deltaTime, 0);
            if (transform.position.y <= -1)
                Destroy(this.gameObject);
        }
    }
}