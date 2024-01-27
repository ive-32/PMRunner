using UnityEngine;

namespace GameScene.Level
{
    public abstract class BaseLevelObject : MonoBehaviour
    {
        protected GameObject CurrentObject;
        protected virtual void Awake()
        {
            var childCount = transform.childCount;
            for (var i = 0; i < childCount; i++)
            {
                var obj = transform.GetChild(i).gameObject;
                if (obj.name == "ItemSprite")
                    CurrentObject = obj;
            }
        }

        protected virtual void Update()
        {
            transform.position += new Vector3(0, -Game.PlayerMovingSpeed * Time.deltaTime, 0);
            if (transform.position.y <= -1)
                Destroy(gameObject);
        }
    }
}