using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPivotBehaviour : MonoBehaviour
{
    [SerializeField]
    public GameObject ball;

    [SerializeField]
    private GameObject clubPivot;

    private StateController stateMachine;
    private ClubController clubController;

    // Start is called before the first frame update
    void Start()
    {
        stateMachine = clubPivot.GetComponent<StateController>();
        clubController = clubPivot.GetComponent<ClubController>();
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = ball.transform.position;

        if (stateMachine.isInput()) {
            gameObject.transform.rotation = gameObject.transform.localRotation = Quaternion.Euler(0f, clubController.angle_aimed, 0f);
        }
    }
}
