using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwakeState : IState
{
    //fields
    [SerializeField]
    GameObject club;

    public void OnEnter(StateController sc)
    { 

    }
    public void UpdateState(StateController sc)
    {
       //TODO: implement me!
    }
    public void OnExit(StateController sc)
    {
        club = GameObject.FindGameObjectsWithTag("Club")[0];

        club.GetComponent<MeshCollider>().enabled = false;
    }
}
