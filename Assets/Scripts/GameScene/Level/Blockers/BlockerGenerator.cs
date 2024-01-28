using UnityEngine;

namespace GameScene.Level.Blockers
{
    public class BlockerGenerator : MonoBehaviour
    {
        private void Start()
        {
            int childrenId = Mathf.FloorToInt(Random.Range(0, transform.childCount));
            GameObject gameObject = transform.GetChild(childrenId).gameObject;
            
            gameObject.SetActive(true);

            if (gameObject.tag == "Block")
            {
                int blockId = Mathf.FloorToInt(Random.Range(0, gameObject.transform.childCount));
                gameObject.transform.GetChild(blockId).gameObject.SetActive(true);
            }
        }
    }
}