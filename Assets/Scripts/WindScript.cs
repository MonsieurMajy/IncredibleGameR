using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindScript : MonoBehaviour
{
    public Vector3 windForce = new Vector3(0f, 0f, 1f); // Change the values as desired
    private int frameCounter = 0;
    // Start is called before the first frame update
    void Start()
    {
        Time.fixedDeltaTime = 10;
        

    }

    // Update is called once per frame
    void FixedUpdate()
    {
         // Replace "Ball" with the actual tag of your ball object
        if(frameCounter%20 == 0){
            GameObject ball = GameObject.FindWithTag("ball");
            if (ball != null)
            {
                Rigidbody ballRigidbody = ball.GetComponent<Rigidbody>();
                ballRigidbody.AddForce(windForce, ForceMode.Force);
               // ball.GetComponent<Renderer>().material.SetColor("_Color", Random.ColorHSV(0f,1f,0.7f,1f,0.7f,1f));

            }
        }
        frameCounter ++;        
    }

}
