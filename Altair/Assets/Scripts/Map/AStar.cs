using System;
using System.Collections.Generic;

namespace Assets.Scripts.Map
{
    public class AStar
    {
        /// <summary>
        /// A class to serve as a structure for the pathfinding algorithim. 
        /// </summary>
        private class PathNodeStruct
        {
            public PathNode node;
            public int gValue;
            public PathNodeStruct parent;

            public PathNodeStruct(PathNode n, int g, PathNodeStruct p)
            {
                node = n;
                gValue = g;
                parent = p;
            }
        }

        public static bool FindPath(PathNode start, PathNode goal, PathType path)
        {
            return AStarSearch(start, goal, path);
        }

        /// <summary>
        /// A* based pathing algorithim for finding the shortest path through a linked set of PathNodes. 
        /// There does not need to be a path between the two PathNodes. 
        /// </summary>
        /// <param name="start">PathNode to start at.</param>
        /// <param name="goal">PathNode that is the goal.</param>
        /// <returns>True if a path was found and the PathNodes are set with the correct NextNode values, false otherwise.</returns>
        private static bool AStarSearch(PathNode start, PathNode goal, PathType path)
        {
            PathNode.resetPath.Invoke(); // mark all path nodes as unexplored

            List<PathNodeStruct> unexplored = new List<PathNodeStruct>();
            start.Visit();
            unexplored.Add(new PathNodeStruct(start, 0, null));

            int pathLength = 0;
            while (unexplored.Count > 0) // while there are unexplored nodes
            {
                /*
                 * Each cycle should check the node with the best F value and explore from it. 
                 * this does ignore the possibility that there is a better way to get to an already-explored node
                 * but I dont think that should come up in a square grid. 
                 */
                PathNodeStruct cur = unexplored[0];
                unexplored.RemoveAt(0);

                if (cur.node.Equals(goal))
                {
                    //backtrack up the nodes and set their pointers for nextNode
                    PathNodeStruct node = cur;
                    while (node.parent != null) //the start node has a null parent
                    {
                        
                        node.parent.node.SetNextNode(node.node, path);
                        node = node.parent;
                    }
                    return true; //found a path
                }

                foreach(PathNode p in cur.node.GetNeighbors())
                {
                    if (p.IsVisited()) continue;
                    //add all unexplored neighbors as path nodes wth the curent distance as the g value. 
                    unexplored.Add(new PathNodeStruct(p, pathLength, cur));
                    p.Visit();
                }
                unexplored.Sort(delegate (PathNodeStruct x, PathNodeStruct y)
                {
                    return (x.node.Heuristic(goal) + x.gValue).CompareTo(y.node.Heuristic(goal) + y.gValue);
                });

                ++ pathLength;
            }
            return false; // no path was found.
        }
    }
}