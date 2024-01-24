using UnityEngine;

namespace GameScene.Level
{
    public abstract class BaseLevelObject : MonoBehaviour
    {
        protected GameObject CurrentObject;
        protected virtual void Awake()
        {
            var childCount = transform.childCount;
            for (var i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }

            var currentBlock = Random.Range(0, childCount);
            CurrentObject = transform.GetChild(currentBlock).gameObject; 
            CurrentObject.SetActive(true);
        }

        protected virtual void Update()
        {
            transform.position += new Vector3(0, -Game.PlayerMovingSpeed * Time.deltaTime, 0);
            if (transform.position.y <= -1)
                Destroy(gameObject);
        }
    }
}