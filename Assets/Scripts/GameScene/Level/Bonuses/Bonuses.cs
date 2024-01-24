using UnityEngine;

namespace GameScene.Level.Bonuses
{
    public class Bonuses : BaseItemGenerator
    {
        private BonusesDescription _bonusesDescription;
        
        private void LoadBonuses()
        {
            var targetFile = Resources.Load<TextAsset>("Bonuses");

            if (targetFile is null)
                return;

            _bonusesDescription = JsonUtility.FromJson<BonusesDescription>(targetFile.ToString());
        }

        protected override void GenerateItem()
        {
            
        }
    }
}