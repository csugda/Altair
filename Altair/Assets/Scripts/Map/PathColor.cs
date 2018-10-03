using Assets.Scripts.Map.Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Map
{
    public class PathColor : MonoBehaviour
    {
        public Material me;

        private void Start()
        {
            me = this.gameObject.GetComponent<Renderer>().material;
        }

        // Update is called once per frame
        void Update()
        {
            Color temp = Color.black;
            if (this.gameObject.GetComponent<PathNode>().GetNextNode(PathType.A))
            {
                temp.r = 255;
            }
            if (this.gameObject.GetComponent<PathNode>().GetNextNode(PathType.B))
            {
                temp.g = 255;
            }
            if (this.gameObject.GetComponent<PathNode>().GetNextNode(PathType.C))
            {
                temp.b = 255;
            }
            if (this.gameObject.GetComponent<PathNode>().impassable)
            {
                temp = Color.magenta;
            }
            me.color = temp;
        }
    }

}