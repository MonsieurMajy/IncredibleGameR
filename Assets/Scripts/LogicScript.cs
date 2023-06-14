using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class LogicScript : MonoBehaviour
{
    public GameObject restartScreen;
    public GameObject quitMenu;
    // Update is called once per frame
    
    void Start(){
        Time.timeScale = 1;
    }
    void Update()
    {   
        if (Input.GetKeyDown(KeyCode.Escape) || (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.Q)))
        {   
            Console.WriteLine("pressed exit");
            Time.timeScale = 0;
            quitMenu.SetActive(true);
        }      
    }


// for the pit hole collider
    public void OnTriggerEnter(Collider collider) {
        Debug.Log("victory!");
        this.GetComponent<Renderer>().material.SetColor("_Color", UnityEngine.Random.ColorHSV(0f,1f,0.7f,1f,0.7f,1f));
        restartScreen.SetActive(true);
       
    }
}
