using System;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace GameScene.Level.Memes
{
    public class MemeItemsGenerator : BaseItemGenerator
    {
        private GameObject _memeItem;
        [FormerlySerializedAs("road")] public GameObject road;

        private void Awake()
        {
            _memeItem = Resources.Load<GameObject>("Memes/MemeItem");
        }

        protected override void GenerateItem()
        {
            var targetStreetNumber = Random.Range(0, road.transform.childCount);
            var targetStreet = road.transform.GetChild(targetStreetNumber);
            var targetStreetPart = Random.Range(0, 3);
            var streetPart = targetStreetPart switch
            {
                0 => targetStreet.Find("Road Lane_01"),
                1 => targetStreet.Find("Road Lane_01 (1)"),
                2 => targetStreet.Find("Road Intersection_01"),
            };

            var pos = Random.insideUnitCircle * 5;
            Instantiate(_memeItem, streetPart.position + new Vector3(pos.x, 0, pos.y), Quaternion.identity, transform);
        }
    }
}