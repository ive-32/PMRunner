using System;
using GameScene.Level;
using GameScene.Level.Memes;
using UnityEngine;
using UnityEngine.UI;

namespace GameScene.Hero
{
    public class Hero : MonoBehaviour
    {
        /**
         * Position on the road. 0 - middle
         */
        public int roadPosition = (int)Enums.PlayerRoad.Middle;

        /**
         * Distance between roads
         */
        public float roadDistance = 4.25f;
        private const float PlayerSlideSpeed = 4;

        /**
         * Speed of Main player by default
         */
        public float playerRunPower = 2.0f;

        /**
         * Speed of Main player by default
         */
        public float playerJumpPower = 8.0f;
        
        /**
         * Died menu
         */
        public GameObject diedMenu;

        /**
         * Do we need move to other road
         */
        private int playerMoveRoad = 0;
        private MemeCollector _memeCollector;
        private GameObject _memeCollectorObject;
        private IIntersectable _memeItems;

        /**
         * Set player animator
         */
        public GameObject playerObject = null;
        
        /**
         * Set player animator
         */
        private Animator _animator;
        
        /**
         * Object for move
         */
        private Rigidbody _rigidbody;

        private void Start()
        {
            _animator = playerObject.GetComponentInChildren<Animator>();
            _rigidbody = GetComponentInChildren<Rigidbody>();
            var levelObj = transform.parent.gameObject;
            _memeItems = levelObj.GetComponentInChildren<MemeItemsGenerator>().GetComponent<BaseItemGenerator>();
            _memeCollectorObject = new GameObject();
            _memeCollector = _memeCollectorObject.AddComponent<MemeCollector>();
            _memeCollector.targetContainer = transform.Find("Canvas/GameUI/MemeBox").gameObject;

        }

        private void Update()
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                _memeCollector.UseMeme();
            }
        }
        private void FixedUpdate()
        {
            if (Input.GetAxisRaw("Horizontal") == -1)
            {
                MoveToLeft();
            } else if (Input.GetAxisRaw("Horizontal") == 1)
            {
                MoveToRight();
            }
            
            DoSideSteps();
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

        private void MoveToLeft()
        {
            if (roadPosition > -1)
            {
                playerMoveRoad = roadPosition-1;
            }
        }
        
        private void MoveToRight()
        {
            if (roadPosition < 1)
            {
                playerMoveRoad = roadPosition + 1;
            }
        }
        
        private void DoPauseAfterFalling()
        {
            //_animator.SetTrigger("Fall");
            playerRunPower = 0;
            //Time.timeScale = 0; // Если хотим стопнуть игру
            diedMenu.SetActive(true);
        }

        private void Jump()
        {
            _rigidbody.velocity = new Vector3(0, playerJumpPower, 0);
            _animator.SetTrigger("Jump");
        }

        private void DoSideSteps()
        {
            var currentPosition = _rigidbody.position;
            var targetRigidBodyPosition = new Vector3(_rigidbody.position.x, _rigidbody.position.y,
                _rigidbody.position.z + Time.fixedDeltaTime * playerRunPower);

            if (Mathf.Abs(playerMoveRoad * roadDistance - currentPosition.x) > 0.1f)
            {
                var targetPosition = new Vector3(playerMoveRoad * roadDistance, currentPosition.y, currentPosition.z);
                var direction = targetPosition - currentPosition;
                var delta = direction.normalized * (Time.deltaTime * PlayerSlideSpeed);
                if (delta.magnitude > direction.magnitude)
                    delta = direction;
                targetRigidBodyPosition += delta;
            }

            _rigidbody.position = targetRigidBodyPosition;
            roadPosition = Mathf.RoundToInt(_rigidbody.position.x / roadDistance);
        }
        
        /**
         * If collider of Player have collision with other colliders
         */
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag.Equals("Block"))
            {
                collision.gameObject.SetActive(false);
                //DoPauseAfterFalling();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag.Equals("MemeItem"))
            {
                _memeCollector.CollectMemeItem(other.gameObject.GetComponent<MemeItem>().MemeName);
                Destroy(other.gameObject);
            }

        }
    }
}