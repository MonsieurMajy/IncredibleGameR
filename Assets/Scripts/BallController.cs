using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    private bool active;

    [SerializeField]
    private float magnitude_scale = 0.9f;

    // Start is called before the first frame update
    void Start()
    {
        active = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void activate() {
        active = true;
    }

    public bool isActive() {
        return active;
    }

    public void OnTriggerEnter (Collider collider) {
        GameObject otherGobj = collider.gameObject;

        //Debug.Log("Collision detected ! " + otherGobj);

        //Check if it is the club
        if (otherGobj.CompareTag("Ball") & active)
        {
            active = false; //deactive the action of the club
            ClubController pivot_script = GameObject.FindGameObjectsWithTag("Pivot")[0].GetComponent<ClubController>();
            Vector3 direction = new Vector3(0, 0, 1);

            CLUB_TYPE clubType = pivot_script.getClubType();

            if (clubType == CLUB_TYPE.WEDGE)
            {
                direction = Quaternion.Euler(-15f, pivot_script.angle_aimed, 0) * direction;
            }
            else if (clubType == CLUB_TYPE.IRON)
            {
                direction = Quaternion.Euler(-30f, pivot_script.angle_aimed, 0) * direction;
            } else
            {
                direction = Quaternion.Euler(0, pivot_script.angle_aimed, 0) * direction;
            }

            Debug.Log(clubType);

            Vector3 force = pivot_script.global_strengh * magnitude_scale * direction;
            Debug.Log(direction);
            otherGobj.GetComponent<Rigidbody>().AddForce(force, ForceMode.Impulse);

            pivot_script.increaseSwings();
            }

        }

}
