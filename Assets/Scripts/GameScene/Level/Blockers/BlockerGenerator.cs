using UnityEngine;

namespace GameScene.Level.Blockers
{
    public class BlockerGenerator : BaseItemGenerator
    {
        private GameObject _blockerItem;

        private void Start()
        {
            _blockerItem = Resources.Load<GameObject>("Blockers/Blocker");
        }

        protected override void GenerateItem()
        {
            var objCoord = Random.Range(0, 3);
            Instantiate(_blockerItem, new Vector3(objCoord, 12, 0), Quaternion.identity, transform);
        }
    }
}