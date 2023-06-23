using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSwitcher : MonoBehaviour
{

    public GameObject[] balls;
    private int index = 0;
    private int max;
    private GameObject currentBall;


    private void Start()
    {
        currentBall = balls[0];
        max = balls.Length;
        for(int i=0; i<balls.Length; i++)
        {
            if (i != index)
            {
                balls[i].SetActive(false);
            }

        }
    }

    public void OnButtonClick()
    {
        // Switch ball

        currentBall.SetActive(false);
        int  prevIndex = index;
        index = ( prevIndex + 1 )% max;
        Debug.Log("index,"+index+" prevIndex, "+prevIndex+"max, "+max);
        UpdateReferences(balls[prevIndex], balls[index]);
        balls[index].transform.position = currentBall.transform.position;
        currentBall = balls[index];
        currentBall.SetActive(true);
    }

    private void UpdateReferences(GameObject oldBall, GameObject newBall)
    {
        // Find objects referencing the old ball
        GameObject camera = GameObject.FindGameObjectWithTag("CameraPiv");
        CameraPivotBehaviour cameraScript = camera.GetComponent<CameraPivotBehaviour>();
        if (cameraScript.ball == oldBall)
        {
            cameraScript.ball = newBall;
        }

        GameObject pivot = GameObject.FindGameObjectWithTag("Pivot");
        ClubController clubScript = pivot.GetComponent<ClubController>();
        if (clubScript.ball == oldBall)
        {
            clubScript.ball = newBall;
        }
        
        
    }
}

