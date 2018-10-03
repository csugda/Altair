using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Map.Pathfinding
{
    public class PathingTest : MonoBehaviour
    {
        public PathNode start, g1, g2, g3;
        // Use this for initialization
        public void FindPath()
        {
            
        }
        private void Start()
        {
            AStar.SetStart(start);
            AStar.SetGoal(PathType.A, g1);
            AStar.SetGoal(PathType.B, g2);
            AStar.SetGoal(PathType.C, g3);
            AStar.GeneratePath();
        }

    }
}
