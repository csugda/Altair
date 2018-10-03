using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Map.Pathfinding
{
    public class PathChangeEvent : UnityEvent<bool> { }
    class EnemyPathRegen : MonoBehaviour
    {
        public static PathChangeEvent UpdateEnemyPaths = new PathChangeEvent();
        private UnitController myController;
        private void Start()
        {
            myController = this.gameObject.GetComponent<UnitController>();
            UpdateEnemyPaths.AddListener(this.CheckMyPath);
        }

        private void CheckMyPath(bool updatePath)
        {
            PathNode myLocation = myController.NextPathNode();
            PathType MyPath = myController.GetPathType();
            if (updatePath)
                AStar.GeneratePath(myLocation, MyPath);
            else
                AStar.FindPath(myLocation, MyPath);
        }

        private void OnDestroy()
        {
            UpdateEnemyPaths.RemoveListener(this.CheckMyPath);
        }
    }
}
