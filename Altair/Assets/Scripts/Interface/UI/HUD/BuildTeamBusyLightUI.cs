using Assets.Scripts.Map.Construction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildTeamBusyLightUI : MonoBehaviour {

    public BuildTeam team;
    public Sprite normal, busy;
    public bool activiteOnInstruction;
    private void Update()
    {
        if (activiteOnInstruction)
            this.GetComponent<Image>().sprite = team.mode!=BuildTeam.Mode.NONE ? busy : normal;
        else
            this.GetComponent<Image>().sprite = team.busy ? busy : normal;
    }
}
