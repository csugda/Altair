using System;

namespace Assets.Scripts.Map
{
    public class AStar
    {
        public static bool FindPath(PathNode start, PathNode end)
        {
            return AStarRecurse(start, end, 0);
        }

        private static bool AStarRecurse(PathNode cur, PathNode goal, int pathLength)
        {
            if (cur.Equals(goal))
            {
                return true;
            }
            PathNode[] nodes = cur.GetNeighbors();
            Array.Sort(nodes, delegate (PathNode x, PathNode y) {
                return x.FValue(pathLength, goal).CompareTo(y.FValue(pathLength, goal));
            });
            foreach (PathNode next in nodes)
            {
                if (next.IsVisited())
                    continue;
                next.Visit();
                if (AStarRecurse(next, goal, pathLength+1))
                {
                    cur.SetNextNode(next);
                    return true;
                }
                return false;
            }

            return true;
        }
    }
}