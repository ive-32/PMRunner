using System.Collections.Generic;
using UnityEngine;

namespace GameScene.Level
{
    public abstract class BaseItemGenerator : MonoBehaviour, IIntersectable
    {
        protected float TimeToNextItem = 0.5f;
        
        protected virtual void Update()
        {
            if (TimeToNextItem <= 0)
            {
                GenerateItem();
                SetTimeToNextItem();
            }

            TimeToNextItem -= Time.deltaTime;
        }

        protected abstract void GenerateItem();

        protected virtual void SetTimeToNextItem()
        {
            TimeToNextItem = Random.Range(0.3f, 1f);
        }
        
        public List<GameObject> GetNearestObjects(Vector3 position, float radius = 1)
        {
            var childCount = transform.childCount; 
            var nearestObjects = new List<GameObject>(childCount);
            
            for (var i = 0; i < childCount; i++)
            {
                var obj = transform.GetChild(i);
                if ((obj.transform.position - position).magnitude <= radius)
                    nearestObjects.Add(obj.gameObject);
            }

            return nearestObjects;
        }

    }
}