using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Map
{
    public class PathingTest : MonoBehaviour
    {
        public PathNode start, g1, g2, g3;
        // Use this for initialization
        public void FindPath()
        {
            AStar.FindPath(start, g1, PathType.A);
            AStar.FindPath(start, g2, PathType.B);
            AStar.FindPath(start, g3, PathType.C);
        }
       
        
    }
}
