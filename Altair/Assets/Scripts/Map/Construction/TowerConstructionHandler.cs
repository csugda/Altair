using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Map.Construction
{
    public class TowerConstructionHandler : MonoBehaviour
    {
        public GameObject thisTowerPrefab;
        private enum Mode { NONE, MOVE, DESTROY };
        private static Mode mode;
        private static BuildTeam activeTeam;
        private TowerBuildSite myTile;
        public static TowerConstructionHandler selectedMoveTower;

        public int activationTime, destroyTime;
        private void Start()
        {
            if (activationTime > destroyTime)
                Debug.LogError("Activation time must be shorter then destruction time for activation to work. Errors will occour.");
            
        }

        public static void DestructionMode(BuildTeam team)
        {
            mode = Mode.DESTROY;
            activeTeam = team;
        }
        public static void EndDestructionMode()
        {
            mode = Mode.NONE;
            activeTeam = null;
        }

        public static void MoveMode(BuildTeam team)
        {
            mode = Mode.MOVE;
            activeTeam = team;
        }
        public static void EndMoveMode()
        {
            mode = Mode.NONE;
            activeTeam = null;
        }

        public void OnMouseEnter()
        {
            if (mode != Mode.NONE)
            {
                //Highlight this tower somehow
            }
        }

        public static void cancelMove()
        {
            selectedMoveTower = null;
        }

        public void OnMouseUp()
        {
            switch (mode)
            {
                case Mode.NONE:
                    break;
                case Mode.MOVE:
                    selectedMoveTower = this;
                    break;
                case Mode.DESTROY:
                    StartCoroutine(DestroyTower(activeTeam));
                    break;
            }
        }

        public void OnMouseExit()
        {
            if (mode != Mode.NONE)
            {
                //unHighlight tower somehow
            }
        }

        public void OnDestroy()
        {
            EndDestructionMode();
        }

        public IEnumerator DestroyTower(BuildTeam team)
        {
            if (team != null)
                team.busy = true;
            //disable targeting
            GetComponent<TargetAcquisition>().enabled = false;
            //run animation
            yield return new WaitForSeconds(destroyTime);
            //clear this buildSite
            myTile.RemoveTower();
            //destroy model
            if (team != null)
                team.EndJob();
            Debug.Log("Tower Destroyed");
            Destroy(this.gameObject);


        }

        //TODO: Fix the thing where towers have to be destroied after the new ne is active. 
        public IEnumerator MoveTower(BuildTeam team, TowerBuildSite newSite)
        {
            team.busy = true;
            //save refrence to tower
            //destroy tower
            StartCoroutine(DestroyTower(null));

            //call construction on new site
            TowerConstructionHandler newTower = Instantiate(thisTowerPrefab, newSite.gameObject.transform).GetComponent<TowerConstructionHandler>();
            team.BeginConstruction(newTower);
            StartCoroutine(newTower.ConstructTower(team, newSite));
            yield return new WaitForSeconds(0);
            Debug.Log("Tower Move in progress.");
        }


        //Building Script
        public IEnumerator ConstructTower(BuildTeam team, TowerBuildSite location)
        {
            Debug.Log("Tower Construction in Progress...");
            team.busy = true;
            myTile = location; //for use with deconstruction
            location.BuildTower();

            //disable targeting
            //TODO: run construction animation
            GetComponent<TargetAcquisition>().enabled = false;

            //Wait for it to end
            yield return new WaitForSeconds(activationTime);

            //Reenable the build team and activate targeting.
            team.EndJob();
            GetComponent<TargetAcquisition>().enabled = true;
            Debug.Log("Tower built... Targeting active");
        }
    }
}
