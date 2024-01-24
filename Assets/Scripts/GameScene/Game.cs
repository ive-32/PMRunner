using UnityEngine;

namespace GameScene
{
    public static class Game
    {
        public static readonly Vector2Int LevelSize = new Vector2Int(3, 12);
        public const float DefaultGameSpeed = 5; // 5 tile per second
        
        public static float PlayerMovingSpeed { get; set; } = DefaultGameSpeed;

    }
}