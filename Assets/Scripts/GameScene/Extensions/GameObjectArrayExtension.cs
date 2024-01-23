using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GameScene.Extensions
{
    public static class GameObjectArrayExtension
    {
        public static GameObject GetObjectByName(this IEnumerable<GameObject> source, string name)
        {
            return source.FirstOrDefault(g => g.name == name);
        }
    }
}