using UnityEngine;
using Random = UnityEngine.Random;

namespace GameScene.Level.Memes
{
    public class MemeItemsGenerator : BaseItemGenerator
    {
        private GameObject _memeItem;

        private void Awake()
        {
            _memeItem = Resources.Load<GameObject>("Memes/MemeItem");
        }

        protected override void GenerateItem()
        {
            var objCoord = Random.Range(0, Game.LevelSize.x);
            Instantiate(_memeItem, new Vector3(objCoord, Game.LevelSize.y, 0), Quaternion.identity, transform);
        }
    }
}