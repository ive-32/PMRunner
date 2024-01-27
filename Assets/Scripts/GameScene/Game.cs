using GameScene.Level.Common;
using GameScene.Level.UiElements;
using UnityEngine;

namespace GameScene
{
    public static class Game
    {
        public static readonly Vector2Int LevelSize = new Vector2Int(5, 12);
        public static readonly Vector3 LevelCenter = new Vector3(LevelSize.x / 2, LevelSize.y / 2, 0);
        public const float DefaultGameSpeed = 5; // 5 tile per second
        
        public static float PlayerMovingSpeed { get; set; } = DefaultGameSpeed;

        public static UIValue<int> Lives = new UIValue<int>(5);
        public static UIValue<int> Distance = new UIValue<int>(0);

        public static GameState GameState = GameState.BeforeGame;

    }
}