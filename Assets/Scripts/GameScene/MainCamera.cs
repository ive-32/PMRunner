using UnityEngine;

namespace GameScene
{

    public class IcwCamera : MonoBehaviour
    {
        private Camera _mainCamera;

        public void Awake()
        {
            _mainCamera = this.GetComponent<Camera>();
            SetUpCameraAngle();
            SetUpCameraPosition();
        }

        private void SetUpCameraAngle()
        {
            _mainCamera.orthographicSize = (float) Game.LevelSize.y / 2;
        }

        private void SetUpCameraPosition()
        {
            transform.localPosition = new Vector3(Game.LevelSize.x / 2.0f - 0.5f, Game.LevelSize.y / 2.0f - 0.5f, -50);
        }
    }

}
