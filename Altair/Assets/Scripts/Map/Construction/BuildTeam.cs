using UnityEngine;

namespace Assets.Scripts.Map.Construction
{

    public class BuildTeam : MonoBehaviour
    {

        public bool busy = false;
        public enum Mode { BUILD, DESTROY, MOVE, NONE };
        public Mode mode = Mode.NONE;

        public void StartBuildMode()
        {
            if (mode != Mode.NONE || busy) return;
            TowerBuildSite.StartBuildMode(this);
            this.mode = Mode.BUILD;
        }

        public void CancelJob()
        {
            this.mode = Mode.NONE;
            TowerConstructionHandler.cancelMove();
        }

        public void EndJob()
        {
            this.mode = Mode.NONE;
            this.busy = false;
        }

        public void StartMoveMode()
        {
            this.mode = Mode.MOVE;
            TowerConstructionHandler.MoveMode(this);
            TowerBuildSite.StartMoveMode(this);
        }
        public void StartDestroyMode()
        {
            this.mode = Mode.DESTROY;
            TowerConstructionHandler.DestructionMode(this);
        }
        public void BeginConstruction(TowerConstructionHandler construction)
        {
            busy = true;
            EndJob();
        }
        
        
    }
}
