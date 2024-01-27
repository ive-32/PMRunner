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
            var objCoord = Random.Range(0, Game.LevelSize.x);
            Instantiate(_blockerItem, new Vector3(objCoord, Game.LevelSize.y, 0), Quaternion.identity, transform);
        }
    }
}