using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GameScene.Level.Bonuses
{
    public class Bonuses : BaseItemGenerator
    {
        private BonusesDescriptions _bonusesDescriptions;
        private GameObject _memes;
        private GameObject _bonusesItems;
        
        private void LoadBonuses()
        {
            _memes = Resources.Load<GameObject>("Bonuses/Memes");
            _bonusesItems = Resources.Load<GameObject>("Bonuses/BonusItems");
            var targetFile = Resources.Load<TextAsset>("Bonuses");

            if (targetFile is null)
                return;

            var bonusesDescriptions = JsonUtility.FromJson<BonusesDescriptions>(targetFile.ToString());
            /*foreach (var bonus in bonusesDescriptions.memes)
            {
                var memeObj = _memes.transform.Find(bonus.memeName);
                
                if (memeObj == null) 
                    continue;
                
                foreach (var bonusItem in bonus.itemNames)
                {
                    var childObj = _bonusesItems.transform.Find(bonusItem);
                    
                }
            }*/
        }

        private void Start()
        {
            LoadBonuses();
        }

        protected override void GenerateItem()
        {
            var objCoord = Random.Range(0, 3);
            Instantiate(_bonusesItems, new Vector3(objCoord, 12, 0), Quaternion.identity, transform);

        }
    }
}