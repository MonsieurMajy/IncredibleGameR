using UnityEngine;


public class LogicScript : MonoBehaviour
{
    public GameObject restartScreen;
    public GameObject quitMenu;
    private bool isInPitHole = false;
    private float counter = 0;
    public float winDelay = 0.3f;

    [SerializeField] private AudioSource winSound;
    // Update is called once per frame
    
    void Start(){
        Time.timeScale = 1;
    }
    void Update()
    {   
        if (Input.GetKeyDown(KeyCode.Escape) || (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.Q)))
        {   
            Time.timeScale = 0;
            quitMenu.SetActive(true);
        }      

        if(counter > winDelay) {
            restartScreen.SetActive(true);
            counter = 0;
            Time.timeScale = 0;
        }
    }


// for the pit hole collider
    public void OnTriggerEnter(Collider collider) {
        if (collider.CompareTag("Ball"))
        {
            if(SoundButton.noisesAudioActivated){ winSound.Play(); }
            //this.GetComponent<Renderer>().material.SetColor("_Color", UnityEngine.Random.ColorHSV(0f,1f,0.7f,1f,0.7f,1f));
            isInPitHole = true;
            StartCounter();
        }
        
       
    }

    public void OnTriggerExit(Collider collider) {
        isInPitHole = false;
        StopCounter();
    }

    private void StartCounter()
    {
        InvokeRepeating("IncrementCounter", 0f, 0.1f);
    }

    private void StopCounter()
    {
        CancelInvoke("IncrementCounter");
        counter = 0;
    }

    private void IncrementCounter()
    {
        counter += Time.deltaTime;
        //Debug.Log(counter);
    }
}
