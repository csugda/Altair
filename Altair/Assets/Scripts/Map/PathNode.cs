using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Map
{
    public class PathResetEvent : UnityEvent { }

    public class PathNode : MonoBehaviour
    {
        public static PathResetEvent resetPath = new PathResetEvent();

        bool visited = false;

        // Use this for initialization
        void Start()
        {
            resetPath.AddListener(this.ResetPath);
        }
        // Update is called once per frame
        void Update()
        {

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

        /// <summary>
        /// The F-value for this PathNode to the goal. 
        /// </summary>
        /// <param name="g">G-value for the pathfinding algorithim so far</param>
        /// <param name="goal">PathNode target</param>
        /// <returns>F-value for this node</returns>
        internal int FValue(int g, PathNode goal)
        {
            return g + this.Heuristic(goal);
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
        public void SetNextNode(PathNode next)
        {
            return;
        }

        /// <summary>
        /// Defines a value that is an estimate for the distance left form the curent PathNode to a goal. 
        /// This estimate must always be <= the actual distance. 
        /// </summary>
        /// <param name="goal">The PathNode to calculate the huristic for</param>
        /// <returns></returns>
        public int Heuristic(PathNode goal)
        {
            return 0;
        }

        /// <summary>
        /// Returns all valid neighbors to this node. 
        /// A valid neighbor is one that is adjecient and does not have a tower on it. 
        /// </summary>
        /// <returns>Array of PathNodes containing 0-4 nighbors</returns>
        public PathNode[] GetNeighbors()
        {
            return new PathNode[0];
        }
    }
}