using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public GameObject restartScreen;
    public GameObject quitMenu;
    // Update is called once per frame
    void Update()
    {   
        if (Input.GetKeyDown(KeyCode.Escape) || (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.Q)))
        {   
            Time.timeScale = 0;
            quitMenu.SetActive(true);
        }      
    }


// for the pit hole collider
    public void OnTriggerEnter(Collider collider) {
        this.GetComponent<Renderer>().material.SetColor("_Color", Random.ColorHSV(0f,1f,0.7f,1f,0.7f,1f));
        restartScreen.SetActive(true);
    }
}
