using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputState : IState
{
    //fields
    Vector3 ball_pos;
    ClubController clubController;

    //[SerializeField]
    //GameObject ball;

    //[SerializeField]
    //GameObject pivot;

    //[SerializeField]
    //GameObject club;

    public void OnEnter(StateController sc)
    { 
        clubController = pivot.GetComponent<ClubController>();
        ball_pos = ball.transform.position;

        club.GetComponent<MeshCollider>().enabled = false; //Deactivate the club collider
        club.GetComponent<BoxCollider>().enabled = true;

        clubController.moveTo(ball_pos);
        clubController.show();
    }
    public void UpdateState(StateController sc)
    {
       //Nothing
    }
    public void OnExit(StateController sc)
    {
        club.GetComponent<MeshCollider>().enabled = true;
        club.GetComponent<BoxCollider>().enabled = false;
    }
}