using Assets.Scripts.Map.Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Map
{
    [ExecuteInEditMode]
    public class MapGenerator : MonoBehaviour {
        public GameObject prefab;

        [ContextMenu("Generate Map")]
        void GenerateMap()
        {
            for (int i = this.transform.childCount-1; i >= 0; --i)
            {
                DestroyImmediate(this.transform.GetChild(i).gameObject);
            }
            
            for (int i = 0; i <= 20; ++i)
            {
                for (int j = 0; j <= 20; ++j)
                {
                    GameObject temp = Instantiate(prefab, new Vector3(i, 0, j), Quaternion.identity, this.gameObject.transform);
                    temp.name = i + " " + j;
                    temp.GetComponentInChildren<PathNode>().SetXY(i, j);
                }
            }
            for (int i = 0; i <= 20; ++i)
            {
                for (int j = 0; j <= 20; ++j)
                {
                    PathNode temp = GameObject.Find(i + " " + j).GetComponentInChildren<PathNode>();
                    List<PathNode> neighbors = new List<PathNode>();
                    if (i > 0)
                        neighbors.Add(GameObject.Find((i - 1) + " " + j).GetComponentInChildren<PathNode>());
                    if (j > 0)
                        neighbors.Add(GameObject.Find(i + " " + (j - 1)).GetComponentInChildren<PathNode>());
                    if (i < 20)
                        neighbors.Add(GameObject.Find((i + 1) + " " + j).GetComponentInChildren<PathNode>());
                    if (j < 20)
                        neighbors.Add(GameObject.Find(i + " " + (j + 1)).GetComponentInChildren<PathNode>());
                    temp.SetNeighbors(neighbors.ToArray());
                }
            }
        }
    }
}