using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Map.Construction
{
    class PrefabSet : MonoBehaviour
    {
        public GameObject[] prefabs;

        public GameObject RandomPrefab()
        {
            return prefabs[(int)(UnityEngine.Random.Range(0, 1) * prefabs.Length)];
        }
    }
}
