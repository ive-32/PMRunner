using Random = UnityEngine.Random;

namespace GameScene.Level
{
    public class Blocker : BaseLevelObject
    {
        private void Awake()
        {
            var childCount = transform.childCount;
            for (var i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }

            var currentBlock = Random.Range(0, childCount);
            transform.GetChild(currentBlock).gameObject.SetActive(true);
        }
    }
}