using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ClubState {
    INPUT,
    AWAKE,
    SPLEEPING
}

public class ClubController : MonoBehaviour
{

    [SerializeField]
    private GameObject club_prop;

    private DragBehaviour dragScript;

    [SerializeField]
    private float init_angle = 45;

    [SerializeField]
    public float angle_aimed = 0;

    [SerializeField]
    private Vector3 pivot_pos = new Vector3(0f, 2.55f, 0f);

    [SerializeField]
    private float rotation_speed = 1;

    [SerializeField]
    private float swing_amplitude = 0.8f;

    private float current_angle;
    private Transform clubMesh;

    public float global_strengh;

    private Vector3 offset; //Offset with the center of the object
    private Vector3 screenSpacePos; //Position of the object in the screen space
    private StateController stateMachine;
    

    // Start is called before the first frame update
    void Start()
    {
        dragScript = club_prop.GetComponent<DragBehaviour>();
        clubMesh = gameObject.transform.GetChild(0);
        stateMachine = gameObject.GetComponent<StateController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (stateMachine.isAwake()) {
            //Compute the angle according to pendulum formula
            current_angle = init_angle * Mathf.Sin(Time.time * rotation_speed);

            //Compute the local rotation according to the angle aimed
            float x = -Mathf.Sin(Mathf.Deg2Rad*(angle_aimed))*current_angle;
            float z = Mathf.Cos(Mathf.Deg2Rad*(angle_aimed))*current_angle;

            //Update the global strenght
            global_strengh = init_angle*rotation_speed;

            //Check if it the end of the movement
            if (current_angle > -swing_amplitude*init_angle) {
                stateMachine.changeStateToSleep();
            }
        } else if (stateMachine.isInput() && dragScript.isDragging()) {

            init_angle = Mathf.Abs(90 * dragScript.getY()/Screen.width);
            angle_aimed = 360 * (dragScript.getX())/Screen.width;
            current_angle = init_angle; //The initial angle is shown

        }

        //Update the orientation of the object according to the current angle
        gameObject.transform.localRotation = Quaternion.Euler(0f, 0f, current_angle);
    }

    public void reset() {
        gameObject.transform.rotation = Quaternion.identity;
    }

    public void show() {
        gameObject.SetActive(true);
    }

    public void hide() {
        gameObject.SetActive(false);
    }

    public void moveTo(Vector3 position) {
        gameObject.transform.position = position - pivot_pos;
    }
}
