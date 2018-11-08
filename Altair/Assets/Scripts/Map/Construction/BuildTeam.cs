using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Map.Construction
{

    public class BuildTeam : MonoBehaviour
    {

        public bool busy = false, buildMode = false;

        public void StartBuildMode()
        {
            if (buildMode || busy) return;
            TowerBuildSite.StartBuildMode(this);
            this.buildMode = true;
        }

        public void EndBuildMode()
        {
            TowerBuildSite.EndBuildMode();
            this.buildMode = false;
        }

        public void BeginConstruction(TowerBuildSite site)
        {
            this.busy = true;
            this.EndBuildMode();
        }

        public void FinishConstruction()
        {
            this.busy = false;
        }
    }
}
