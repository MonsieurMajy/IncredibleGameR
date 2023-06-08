using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwakeState : IState
{
    //fields
    //[SerializeField]
    //GameObject club;

    public void OnEnter(StateController sc)
    { 
        //TODO: implement me!
    }
    public void UpdateState(StateController sc)
    {
       //TODO: implement me!
    }
    public void OnExit(StateController sc)
    {
        club.GetComponent<MeshCollider>().enabled = false;
    }
}
