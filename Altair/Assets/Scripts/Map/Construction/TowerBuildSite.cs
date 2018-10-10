using Assets.Scripts.Map.Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Map.Construction
{

    public class TowerBuildSite : MonoBehaviour
    {
        PrefabSet towers;
        bool towerExists = false;
        public GameObject previewPrefab;
        private GameObject preview;
        private bool buildable;
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
            //Debug.Log("MouseEnter: " + this.gameObject.transform.parent.name);
            if (towerExists || preview != null) return;
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

        public void OnMouseDown()
        {
            if (towerExists || !this.buildable) return;
            this.gameObject.transform.parent.GetComponentInChildren<PathNode>().impassable = true;
            EnemyPathRegen.UpdateEnemyPaths.Invoke(true);
            AStar.GeneratePath();
            Instantiate(towers.RandomPrefab(), this.gameObject.transform.parent);
            this.towerExists = true;
            this.OnMouseExit();

        }
    }
}