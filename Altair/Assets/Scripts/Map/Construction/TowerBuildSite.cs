using Assets.Scripts.Map.Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Map.Construction
{

    public class TowerBuildSite : MonoBehaviour
    {
        private static bool buildMode = false;
        private static bool moveMode = false;
        private static BuildTeam activeTeam;
        PrefabSet towers;
        public bool towerExists = false;
        public GameObject previewPrefab;
        private GameObject preview;
        private bool buildable;

        public static void StartBuildMode(BuildTeam team)
        {
            buildMode = true;
            activeTeam = team;
        }
        public static void EndBuildMode()
        {
            buildMode = false;
            activeTeam = null;
        }

        public static void StartMoveMode(BuildTeam team)
        {
            moveMode = true;
            activeTeam = team;
        }
        public static void EndMoveMode()
        {
            moveMode = false;
            activeTeam = null;
        }

        private void Start()
        {
            AStar.PathNotFound.AddListener(this.PreviewError);
            towers = GameObject.Find("TowerSet").GetComponent<PrefabSet>();
        }

        private void PreviewError()
        {
            if (preview == null) return;
            this.buildable = false;
            preview.GetComponent<Renderer>().material.color = Color.red;
        }
        public void OnMouseEnter()
        {
            if (!buildMode) return;
            //Debug.Log("MouseEnter: " + this.gameObject.transform.parent.name);
            if (towerExists || preview != null || EventSystem.current.IsPointerOverGameObject()) return;
            this.gameObject.transform.parent.GetComponentInChildren<PathNode>().impassable = true;
            this.buildable = true;
            preview = Instantiate(previewPrefab, this.gameObject.transform.parent);
            EnemyPathRegen.UpdateEnemyPaths.Invoke(false);
            AStar.FindPath();
        }
        
        private void OnMouseExit()
        {
            //Debug.Log("MouseExit: " + this.gameObject.transform.parent.name);
            if (!towerExists)
                this.gameObject.transform.parent.GetComponentInChildren<PathNode>().impassable = false;
            if (preview == null) return;
            Destroy(preview);
            preview = null;
        }

        public void OnMouseUp()
        {
            if (moveMode && TowerConstructionHandler.selectedMoveTower != null)
            {
                StartCoroutine(TowerConstructionHandler.selectedMoveTower.MoveTower(activeTeam, this));
                return;
            }
            if (!buildMode) return;
            if (towerExists || !this.buildable || EventSystem.current.IsPointerOverGameObject()) return;
            BuildTeam team = activeTeam;
            //maybe not pass this, but pass the construction site. that really makes more sense.

            //TODO this should do something else to handle the construction site. 
            TowerConstructionHandler tower = Instantiate(towers.RandomPrefab(), this.gameObject.transform.parent).GetComponent<TowerConstructionHandler>();

            team.BeginConstruction(tower);

            StartCoroutine(tower.ConstructTower(team, this));
        }

        public void BuildTower()
        {
            this.gameObject.transform.parent.GetComponentInChildren<PathNode>().impassable = true;
            EnemyPathRegen.UpdateEnemyPaths.Invoke(true);
            AStar.GeneratePath();
            this.towerExists = true;
            this.OnMouseExit();
            EndBuildMode();
            EndMoveMode();
        }

        public void RemoveTower()
        {
            this.gameObject.transform.parent.GetComponentInChildren<PathNode>().impassable = false;
            EnemyPathRegen.UpdateEnemyPaths.Invoke(true);
            AStar.GeneratePath();
            this.towerExists = false;
            this.OnMouseExit();
        }
    }
}