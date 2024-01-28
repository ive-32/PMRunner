using UnityEngine;

namespace GameScene.Extensions
{
    public static class GameObjectExtension
    {
        private static GameObject CreateEmptyChildContainer(this Transform transform, string containerName)
            => new GameObject(containerName)
            {
                transform =
                {
                    parent = transform,
                    position = Vector3.zero
                }
            };
    }
}