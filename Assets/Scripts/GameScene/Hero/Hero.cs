using UnityEngine;

namespace GameScene.Hero
{
    public class Hero : MonoBehaviour
    {
        private int _targetPositionX = 1;
        private const float PlayerSpeed = 4;
        
        private void Update()
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

    }
}