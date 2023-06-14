using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{   
    public float maxSpeed;
    public float minSpeed;
    public float airCoefficient;
    public Rigidbody ballBody;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
       if (ballBody.velocity.magnitude > maxSpeed)
       {
            ballBody.velocity = ballBody.velocity.normalized * maxSpeed;
       }
       else if(ballBody.velocity.magnitude < minSpeed)
       {
            ballBody.velocity = ballBody.velocity * 0;
       }
       else {
            ballBody.velocity = airCoefficient*ballBody.velocity;
       }
    }
}
