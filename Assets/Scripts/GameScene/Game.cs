using UnityEngine;

namespace GameScene
{
    public static class Game
    {
        public static readonly Vector2Int LevelSize = new Vector2Int(3, 25);
        public const float DefaultGameSpeed = 3; // 5 tile per second
        
        public static float PlayerMovingSpeed { get; set; } = DefaultGameSpeed;

    }
}