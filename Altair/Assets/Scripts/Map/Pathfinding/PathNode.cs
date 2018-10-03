using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Map.Pathfinding
{
    public class PathResetEvent : UnityEvent { }

    public class PathNode : MonoBehaviour
    {
        public static PathResetEvent resetPath = new PathResetEvent();

        public bool impassable = false;
        private int x, y;
        bool visited = false;
        public PathNode[] nextNodeArray;
        public PathNode[] neighbors;

        public int X
        {
            get
            {
                return x;
            }
        }

        public int Y
        {
            get
            {
                return y;
            }
        }

        // Use this for initialization
        void Start()
        {
            resetPath.AddListener(this.ResetPath);
            this.nextNodeArray = new PathNode[3];
            nextNodeArray[0] = null;
            nextNodeArray[1] = null;
            nextNodeArray[2] = null;
        }
        // Update is called once per frame
        void Update()
        {

        }
        
        public void SetXY(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public PathNode GetNextNode(PathType path)
        {
            switch (path)
            {
                case PathType.A:
                    return nextNodeArray[0];
                case PathType.B:
                    return nextNodeArray[1];
                case PathType.C:
                    return nextNodeArray[2];
                default:
                    return null;
            }
            
        }

        //called by ResetPath event, marks visited as false.
        private void ResetPath()
        {
            visited = false;
        }

        //Marks visited as true.
        internal void Visit()
        {
            this.visited = true;
        }

        

        //Just a getter for the visited boolean.
        internal bool IsVisited()
        {
            return visited;
        }

        /// <summary>
        /// Sets the next node of the path
        /// </summary>
        /// <param name="next">PathNode to go to next</param>
        public void SetNextNode(PathNode next, PathType path)
        {
            Debug.Log("Setting (" + this.gameObject.name + ") next node to (" + next.gameObject.name + ")");
            Debug.Log(this.nextNodeArray);
            switch (path)
            {
                case PathType.A:
                    nextNodeArray[0] = next;
                    break;
                case PathType.B:
                    nextNodeArray[1] = next;
                    break;
                case PathType.C:
                    nextNodeArray[2] = next;
                    break;
            }
        }

        /// <summary>
        /// Defines a value that is an estimate for the distance left form the curent PathNode to a goal. 
        /// This estimate must always be <= the actual distance. 
        /// </summary>
        /// <param name="goal">The PathNode to calculate the huristic for</param>
        /// <returns></returns>
        public int Heuristic(PathNode goal)
        {
            return Mathf.Abs(this.x - goal.x) + Mathf.Abs(this.y - goal.y);
        }

        public void SetNeighbors(PathNode[] neighbors)
        {
            this.neighbors = neighbors;
        }



        /// <summary>
        /// Returns all valid neighbors to this node. 
        /// A valid neighbor is one that is adjecient and does not have a tower on it. 
        /// </summary>
        /// <returns>Array of PathNodes containing 0-4 nighbors</returns>
        public PathNode[] GetNeighbors()
        {
            List<PathNode> temp = new List<PathNode>();
            foreach (PathNode n in this.neighbors)
            {
                if (n.impassable)
                    continue;
                temp.Add(n);
            }
            return temp.ToArray();
        }

        public override bool Equals(object obj)
        {
            var node = obj as PathNode;
            return node != null &&
                   base.Equals(obj) && true; // Need to implement equals with the cordnates of the node
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}