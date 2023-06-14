using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepState : IState
{
    //fields


    public void OnEnter(StateController sc)
    { 
        GameObject.FindGameObjectsWithTag("Pivot")[0].GetComponent<ClubController>().reset();
        GameObject.FindGameObjectsWithTag("Club")[0].GetComponent<MeshRenderer>().enabled = false;
    }
    public void UpdateState(StateController sc)
    {
       //TODO: implement me!
    }
    public void OnExit(StateController sc)
    {
        //TODO: implement me!
    }
}