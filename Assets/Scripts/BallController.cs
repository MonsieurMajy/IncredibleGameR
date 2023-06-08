using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public bool active;

    [SerializeField]
    private float magnitude_scale = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        active = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter (Collider collider) {
        GameObject otherGobj = collider.gameObject;

        Debug.Log("Collision detected ! " + otherGobj);

        //Check if it is the club
        if (otherGobj.CompareTag("Ball") & active)
        {
            active = false; //deactive the action of the club
            ClubController pivot_script = GameObject.FindGameObjectsWithTag("Pivot")[0].GetComponent<ClubController>();
            Vector3 direction = new Vector3(0, 0, 1);
            direction = Quaternion.Euler(0, pivot_script.angle_aimed, 0) * direction;

            Vector3 force = pivot_script.global_strengh * magnitude_scale * direction;
            Debug.Log(force);
            otherGobj.GetComponent<Rigidbody>().AddForce(force, ForceMode.Impulse);
            }
        }
}
