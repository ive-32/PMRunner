using System.Collections.Generic;
using UnityEngine;

namespace GameScene.Level
{
    public interface IIntersectable
    {
        public List<GameObject> GetNearestObjects(Vector3 position, float radius = 1);
    }
}