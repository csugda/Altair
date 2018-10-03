using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Map.Pathfinding
{
    public class NoPathFoundEvent : UnityEvent { }
    public class PathChangedEvent : UnityEvent { }

    public class AStar
    {
        public static NoPathFoundEvent PathNotFound = new NoPathFoundEvent();
        public static PathChangedEvent PathChanged = new PathChangedEvent();

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
        private static PathNode goalA, goalB, goalC, start;

        public static void SetStart(PathNode node)
        {
            start = node;
        }

        public static void SetGoal(PathType type, PathNode goal)
        {
            switch (type)
            {
                case PathType.A:
                    goalA = goal;
                    break;
                case PathType.B:
                    goalB = goal;
                    break;
                case PathType.C:
                    goalC = goal;
                    break;
            }
        }

        private static PathNode PathNodeFromPathType(PathType type)
        {
            switch (type)
            {
                case PathType.A:
                    return goalA;
                case PathType.B:
                    return goalB;
                case PathType.C:
                    return goalC;
            }
            throw new Exception("PathType does not exist. How did you even manage that?");
        }

        public static bool GeneratePath()
        {
            return (AStarSearch(start, goalA, PathType.A, true) &&
                AStarSearch(start, goalB, PathType.B, true) &&
                AStarSearch(start, goalC, PathType.C, true));
        }
        public static bool GeneratePath(PathNode begining, PathType path)
        {
            return AStarSearch(begining, PathNodeFromPathType(path), path, true);
        }


        public static bool FindPath()
        {
            return (AStarSearch(start, goalA, PathType.A, false) &&
                AStarSearch(start, goalB, PathType.B, false) &&
                AStarSearch(start, goalC, PathType.C, false));
        }
        public static bool FindPath(PathNode begining, PathType path)
        {
            return AStarSearch(begining, PathNodeFromPathType(path), path, false);
        }

        /// <summary>
        /// A* based pathing algorithim for finding the shortest path through a linked set of PathNodes. 
        /// There does not need to be a path between the two PathNodes. 
        /// </summary>
        /// <param name="start">PathNode to start at.</param>
        /// <param name="goal">PathNode that is the goal.</param>
        /// <returns>True if a path was found and the PathNodes are set with the correct NextNode values, false otherwise.</returns>
        private static bool AStarSearch(PathNode start, PathNode goal, PathType path, bool updateWorldPath)
        {
            //TODO: This algorithim is wrong. It doesnt update a node if it finds a better way to get there. 
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
                    if (!updateWorldPath) return true; //If we just want to know if there is a path we are done now.
                    //backtrack up the nodes and set their pointers for nextNode
                    PathNodeStruct node = cur;
                    while (node.parent != null) //the start node has a null parent
                    {
                        
                        node.parent.node.SetNextNode(node.node, path);
                        node = node.parent;
                    }
                    PathChanged.Invoke();
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
            Debug.Log("No path found from " + start + " to " + goal);
            PathNotFound.Invoke();
            return false; // no path was found.
        }
    }
}