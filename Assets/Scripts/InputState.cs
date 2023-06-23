using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputState : IState
{
    //fields
    ClubController clubController;

    [SerializeField]
    GameObject pivot;

    [SerializeField]
    GameObject club;

    [SerializeField]
    GameObject clubBundle;

    [SerializeField]
    GameObject cameraPiv;

    public void OnEnter(StateController sc)
    { 
        club = GameObject.FindGameObjectsWithTag("Club")[0];
        pivot = GameObject.FindGameObjectsWithTag("Pivot")[0];
        clubBundle = GameObject.FindGameObjectsWithTag("ClubBundle")[0];
        cameraPiv = GameObject.FindGameObjectsWithTag("CameraPiv")[0];


        clubController = pivot.GetComponent<ClubController>();


        club.GetComponent<MeshRenderer>().enabled = true;
        club.GetComponent<MeshCollider>().enabled = false; //Deactivate the club collider
        club.GetComponent<BoxCollider>().enabled = true;

        clubController.show();
    }
    public void UpdateState(StateController sc)
    {
       //Nothing
    }
    public void OnExit(StateController sc)
    {
        club = GameObject.FindGameObjectsWithTag("Club")[0];

        clubBundle.transform.SetParent(null);
        club.GetComponent<MeshCollider>().enabled = true;
        club.GetComponent<BoxCollider>().enabled = false;
        club.GetComponent<BallController>().activate();
    }
}