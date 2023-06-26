using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ClubState {
    INPUT,
    AWAKE,
    SPLEEPING
}
public enum CLUB_TYPE
{
    PUTTER,
    WEDGE,
    IRON,
}

public class ClubController : MonoBehaviour
{

    [SerializeField]
    private GameObject club_prop;

    [SerializeField]
    public GameObject ball;

    private DragBehaviour dragScript;

    [SerializeField]
    private float init_angle = 0;

    [SerializeField]
    public float angle_aimed = 0;

    [SerializeField]
    private Vector3 pivot_pos = new Vector3(0f, 2.55f, 0f);

    private Vector3 clubToPivotPos;

    [SerializeField]
    private float rotation_speed = 1;

    [SerializeField]
    private float swing_amplitude = 0.8f;

    [SerializeField]
    private float velocityThreshold = 0.001f;

    [SerializeField]
    private CLUB_TYPE clubType;

    [SerializeField]
    private Material blue;

    [SerializeField]
    private Material green;

    [SerializeField]
    private Material red;

    private float current_angle;
    private float timer;
    private int swings;

    public float global_strengh;

    private Vector3 offset; //Offset with the center of the object
    private Vector3 screenSpacePos; //Position of the object in the screen space
    private StateController stateMachine;
    

    // Start is called before the first frame update
    void Start()
    {
        dragScript = club_prop.GetComponent<DragBehaviour>();
        stateMachine = gameObject.GetComponent<StateController>();
        gameObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        pivot_pos = gameObject.transform.parent.gameObject.transform.position - ball.transform.position;
        clubToPivotPos = gameObject.transform.localPosition;
        swings = 0;
        GameObject.FindGameObjectWithTag("type_text").GetComponent<Text>().text = "PUTTER";
        clubType = CLUB_TYPE.PUTTER;
        reset();
    }

    // Update is called once per frame
    void Update()
    {
        if (stateMachine.isAwake()) {
            //Compute the angle according to pendulum formula
            current_angle = init_angle * Mathf.Cos(timer * rotation_speed);
            timer = timer + Time.deltaTime;

            //Compute the local rotation according to the angle aimed
            float x = -Mathf.Sin(Mathf.Deg2Rad*(angle_aimed))*current_angle;
            float z = Mathf.Cos(Mathf.Deg2Rad*(angle_aimed))*current_angle;

            //Update the global strenght
            global_strengh = init_angle*rotation_speed;

            //Check if it the end of the movement
            if (current_angle < -swing_amplitude*init_angle) {
               stateMachine.changeStateToSleep();
            }
        } else if (stateMachine.isInput()) {
            if (dragScript.isDragging()) {
                init_angle = Mathf.Abs(90 * dragScript.getY()/(0.3f*Screen.width));
                angle_aimed = 360 * (dragScript.getX())/Screen.width;
                current_angle = init_angle; //The initial angle is shown
            } else if(dragScript.isDragUp()) {
                stateMachine.changeStateToAwake();
                timer = 0f;
            } else {
                //Move to the right position ?
                reset();
            }            
        } else if (stateMachine.isSleep()) {
            //Debug.Log(ball.GetComponent<Rigidbody>().velocity.magnitude);
            if (ball.GetComponent<Rigidbody>().velocity.magnitude < velocityThreshold) {
                stateMachine.changeStateToInput();
            }
        }

        //Update the orientation of the object according to the current angle
        Vector3 newRotation = gameObject.transform.rotation.eulerAngles;
        newRotation.x = current_angle;
        gameObject.transform.rotation = Quaternion.Euler(newRotation);
    }

    public void reset() {
        gameObject.transform.parent.gameObject.transform.SetParent(GameObject.FindGameObjectsWithTag("CameraPiv")[0].transform);
        gameObject.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        current_angle = 0;
        gameObject.transform.parent.gameObject.transform.position = ball.transform.position + pivot_pos;
        //Debug.Log(gameObject.transform.localPosition);
    }

    public void show() {
        gameObject.SetActive(true);
    }

    public void hide() {
        gameObject.SetActive(false);
    }

    public void increaseSwings()
    {
        swings++;
        GameObject.FindGameObjectWithTag("Score_text").GetComponent<Text>().text = swings.ToString();
    }

    public void switchClub()
    {
        MeshRenderer meshRenderer = club_prop.GetComponent<MeshRenderer>();
        Material[] materials = meshRenderer.materials;
        
        switch (clubType)
        {
            case CLUB_TYPE.WEDGE:
                clubType = CLUB_TYPE.IRON;
                materials[1] = red;
                break;
            case CLUB_TYPE.IRON:
                clubType = CLUB_TYPE.PUTTER;
                materials[1] = blue;
                break;
            case CLUB_TYPE.PUTTER:
                clubType = CLUB_TYPE.WEDGE;
                materials[1] = green;
                break;
        }

        meshRenderer.materials = materials;

        GameObject.FindGameObjectWithTag("type_text").GetComponent<Text>().text = clubType.ToString();
    }

    public CLUB_TYPE getClubType()
    {
        return clubType;
    }
}
