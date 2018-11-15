using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildTeamInstructionUI : MonoBehaviour {

    [SerializeField]
    private GameObject buttons;

    private void Start()
    {
        buttons.SetActive(false);
    }

    public void MouseEnter()
    {
        buttons.SetActive(true);
        Debug.Log("mouseEnter");
    }

    public void MouseExit()
    {
        buttons.SetActive(false);
        Debug.Log("mouseExit");
    }
}
