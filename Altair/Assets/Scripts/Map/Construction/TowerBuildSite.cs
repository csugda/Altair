using Assets.Scripts.Map.Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Map.Construction
{

    public class TowerBuildSite : MonoBehaviour
    {
        PrefabSet towers;
        
        public void CheckBuildTower()
        {
            this.gameObject.transform.parent.GetComponentInChildren<PathNode>().impassable = true;
            EnemyPathRegen.UpdateEnemyPaths.Invoke(false);
            AStar.FindPath();
            this.gameObject.transform.parent.GetComponentInChildren<PathNode>().impassable = false;
        }

        public void BuildTower()
        {
            this.gameObject.transform.parent.GetComponentInChildren<PathNode>().impassable = true;
            EnemyPathRegen.UpdateEnemyPaths.Invoke(false);
            AStar.FindPath();
            Instantiate(towers.RandomPrefab());
        }
    }
}