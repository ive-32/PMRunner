using GameScene.Extensions;
using GameScene.Level.Blockers;
using GameScene.Level.Common;
using GameScene.Level.Memes;
using GameScene.Level.UiElements;
using UnityEngine;
using UnityEngine.Serialization;

namespace GameScene.Level
{
    
    public class Level : MonoBehaviour
    {
        [FormerlySerializedAs("tiles")] public GameObject[] Tiles;
        [FormerlySerializedAs("hero")] public GameObject HeroPrefab;
        [FormerlySerializedAs("StaticTextPrefab")] public GameObject UiLabelPrefab;
        [FormerlySerializedAs("SplashTextPrefab")] public GameObject UiSplashLabelPrefab;

        private GameObject _hero;
        private GameObject _blockers;
        private GameObject _memeItems;
        private GameObject _floorTiles;
        private UiLabel _lives;
        private UiLabel _distance;
        private float _timeToNextState = 0;

        private void Awake()
        {
            MemeItemSprites.LoadResources();
            MemeDescriptions.LoadMemeDescriptions();
        }

        // Start is called before the first frame update
        private void Start()
        {
            BeforeGame();
        }

        private void Update()
        {
            if (Game.Lives.IsChanged)
            {
                _lives.SetText($"Lives : {Game.Lives.Value}", true);
            }
            
            if (Game.Distance.IsChanged)
                _distance.SetText($"Distance : {Game.Distance.Value}", true);

            if (Game.GameState == GameState.InGame && Game.Lives.GetCurrentValue() == 0)
                GameOver();

            if (_timeToNextState <= 0 && Game.GameState != GameState.InGame)
            {
                switch (Game.GameState)
                {
                    case GameState.BeforeGame : StartGame(); break;
                    case GameState.GameOver : BeforeGame(); break;
                }
            }

            if (_timeToNextState > 0)
                _timeToNextState -= Time.deltaTime;
        }

        private GameObject CreateEmptyChildContainer(string containerName)
            => new GameObject(containerName)
                {
                    transform =
                    {
                        parent = transform,
                        position = Vector3.zero
                    }
                };

        private void GameOver()
        {
            Destroy(_hero.gameObject);
            Game.GameState = GameState.GameOver;
            _timeToNextState = 3;
            Game.PlayerMovingSpeed = 0;
            var splash = Instantiate(UiSplashLabelPrefab, Game.LevelCenter, Quaternion.identity);
            var splashText = splash.GetComponent<UiSplashLabel>();
            splashText.SetText("Game Over");
        }

        private void BeforeGame()
        {
            DestroyLevel();
            GenerateLevel();
            _timeToNextState = 1;
            Game.GameState = GameState.BeforeGame;
            Game.PlayerMovingSpeed = 0;
            Game.Distance.Value = 0;
            Game.Lives.Value = 5;

            var splash = Instantiate(UiSplashLabelPrefab, Game.LevelCenter, Quaternion.identity);
            var splashText = splash.GetComponent<UiSplashLabel>();
            splashText.SetText("Get Ready!");
        }
        
        private void StartGame()
        {
            AddGenerators();
            AddPlayer();
            Game.GameState = GameState.InGame;
            Game.PlayerMovingSpeed = Game.DefaultGameSpeed;
            var splash = Instantiate(UiSplashLabelPrefab, Game.LevelCenter, Quaternion.identity);
            var splashText = splash.GetComponent<UiSplashLabel>();
            splashText.SetText("Go!");
        }

        private void GenerateLevel()
        {
            _floorTiles = CreateEmptyChildContainer("FloorItems");

            for (var i = 0; i < Game.LevelSize.x; i++)
            for (var j = 0; j < Game.LevelSize.y + 3; j++)
                Instantiate(Tiles.GetObjectByName("BaseTile"), new Vector3(i, j, 0), Quaternion.identity, _floorTiles.transform);
            
            var lives = Instantiate(UiLabelPrefab, new Vector3(-4, Game.LevelSize.y - 2, 0), Quaternion.identity, transform);
            _lives = lives.GetComponent<UiLabel>();

            var distance = Instantiate(UiLabelPrefab, new Vector3(-4, Game.LevelSize.y - 3, 0), Quaternion.identity, transform);
            _distance = distance.GetComponent<UiLabel>();
        }

        private void AddGenerators()
        {
            _blockers = CreateEmptyChildContainer("Blockers");
            _blockers.gameObject.AddComponent<BlockerGenerator>();

            _memeItems = CreateEmptyChildContainer("MemeItems");
            _memeItems.gameObject.AddComponent<MemeItemsGenerator>();
        }

        private void AddPlayer()
        {
            _hero = Instantiate(HeroPrefab, new Vector3(Game.LevelCenter.x, 2, 0), Quaternion.identity, transform);
        }
        
        private void DestroyLevel()
        {
            var childCount = transform.childCount;
            for(var i = 0; i < childCount; i++)
                Destroy(transform.GetChild(i).gameObject);
        }
    }

}
