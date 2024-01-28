using System.Linq;
using GameScene.Level;
using GameScene.Level.Blockers;
using GameScene.Level.Memes;
using GameScene.Enums;
using UnityEngine;

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
        }

        private void FixedUpdate()
        {
            playerMoveRoad = 0;
            
            if (Input.GetKeyUp(KeyCode.Space))
            {
                Jump();
            }

            if (Input.GetAxisRaw("Horizontal") == -1)
            {
                MoveToLeft();
            } else if (Input.GetAxisRaw("Horizontal") == 1)
            {
                MoveToRight();
            }
            
            DoSideSteps();
        }

        private void MoveToLeft()
        {
            if (roadPosition > -1)
            {
                --roadPosition;
                playerMoveRoad = -1;
            }
        }
        
        private void MoveToRight()
        {
            if (roadPosition < 1)
            {
                ++roadPosition;
                playerMoveRoad = 1;
            }
        }
        
        private void DoPauseAfterFalling()
        {
            _animator.SetTrigger("Fall");
            playerRunPower = 0;
            //Time.timeScale = 0; // Если хотим стопнуть игру
            playerRunPower = 0;
            diedMenu.SetActive(true);
        }

        private void Jump()
        {
            _rigidbody.velocity = new Vector3(0, playerJumpPower, 0);
            _animator.SetTrigger("Jump");
        }

        private void DoSideSteps()
        {
            _rigidbody.velocity = transform.TransformDirection(new Vector3(playerMoveRoad * roadDistance * 50, _rigidbody.velocity.y, playerRunPower));
        }
        
        /**
         * If collider of Player have collision with other colliders
         */
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag.Equals("Block"))
            {
                DoPauseAfterFalling();
            }
        }
    }
}