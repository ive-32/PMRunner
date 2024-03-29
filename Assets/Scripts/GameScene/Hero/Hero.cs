using System.Linq;
using GameScene.Level;
using GameScene.Level.Blockers;
using GameScene.Level.Memes;
using UnityEngine;

namespace GameScene.Hero
{
    public class Hero : MonoBehaviour
    {
        private int _targetPositionX = 1;
        private const float PlayerSpeed = 1.5f;
        private float _timeToRestore = 0;

        private IIntersectable _blockers;
        private IIntersectable _memeItems;

        private MemeCollector _memeCollector;
        private GameObject _memeCollectorObject;
        private Animator _animator;

        private void Start()
        {
            var levelObj = transform.parent.gameObject;
            _blockers = levelObj.GetComponentInChildren<BlockerGenerator>().GetComponent<BaseItemGenerator>();
            _memeItems = levelObj.GetComponentInChildren<MemeItemsGenerator>().GetComponent<BaseItemGenerator>();
            _memeCollectorObject = new GameObject();
            _memeCollector = _memeCollectorObject.AddComponent<MemeCollector>();
            _animator = gameObject.GetComponentInChildren<Animator>();

        }

        private void Update()
        {
            if (_timeToRestore <= 0)
            {
                DoSideSteps();

                CheckCrash();

                CheckCollectMemeItem();

                if (Input.GetKeyUp(KeyCode.Space))
                {
                    _memeCollector.UseMeme();
                    Jump();
                }
            }
            else
            {
                DoPauseAfterFalling();
            }
        }

        private void TryMoveToLeft()
        {
            _targetPositionX = transform.position.x >= 1 
                ? Mathf.RoundToInt(transform.position.x) - 1
                : Mathf.RoundToInt(0);
        }
        
        private void TryMoveToRight()
        {
            _targetPositionX = transform.position.x <= Game.LevelSize.x - 2 
                ? Mathf.RoundToInt(transform.position.x) + 1
                : Mathf.RoundToInt(Game.LevelSize.x - 1);
        }

        private void CheckCrash()
        {
            var blockers = _blockers.GetNearestObjects(transform.position, 0.3f);
            
            if (blockers.Any())
            {
                blockers.ForEach(b => Destroy(b.gameObject));
                //Game.PlayerMovingSpeed = Game.DefaultGameSpeed / 2;
                var clips = _animator.GetCurrentAnimatorClipInfo(0);
                var clip = clips.Where(c => c.clip.name == "Fall flat").ToList();
                
                _timeToRestore = clip.Any() ? clip[0].clip.length : 1f;
                _animator.SetTrigger("Fall");
            }
        }

        private void CheckCollectMemeItem()
        {
            var memeItems = _memeItems.GetNearestObjects(transform.position, 0.5f);

            foreach (var memeItem in memeItems)
            {
                _memeCollector.CollectMemeItem(memeItem.GetComponent<MemeItem>().MemeName);
                Destroy(memeItem.gameObject);
            }
        }
        
        private void DoPauseAfterFalling()
        {
            _timeToRestore -= Time.deltaTime;
            if (_timeToRestore <= 0)
            {
                _timeToRestore = 0;
                Game.PlayerMovingSpeed = Game.DefaultGameSpeed;
            }
        }

        private void Jump()
        {
            _animator.SetTrigger("Jump");
        }

        private void DoSideSteps()
        {
            var axis = Input.GetAxisRaw("Horizontal");
            switch (axis)
            {
                case < 0 : TryMoveToLeft(); break;
                case > 0 : TryMoveToRight(); break;
                    
            }

            var currentPosition = transform.position;

            if (Mathf.Abs(_targetPositionX - currentPosition.x) > Mathf.Epsilon)
            {
                var targetPosition = new Vector3(_targetPositionX, currentPosition.y, currentPosition.z);
                var direction = targetPosition - currentPosition;
                var delta = direction.normalized * (Time.deltaTime * PlayerSpeed);
                if (delta.magnitude < direction.magnitude)
                    transform.position += delta;
                else
                    transform.SetPositionAndRotation(targetPosition, Quaternion.identity);
            }

        }
    }
}