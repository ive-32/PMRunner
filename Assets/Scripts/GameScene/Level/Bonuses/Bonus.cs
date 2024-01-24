
using UnityEngine;

namespace GameScene.Level.Bonuses
{
    public class Bonus : BaseLevelObject
    {
        private void Start()
        {
            var sprite = CurrentObject.GetComponent<SpriteRenderer>();
            sprite.color = Random.ColorHSV(0, 1, 1, 1, 1, 1);
            CurrentObject.transform.localScale = new Vector3(0.5f, 0.5f, 1);
        }
    }
}