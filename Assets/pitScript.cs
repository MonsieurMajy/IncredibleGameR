using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class pitScript : MonoBehaviour
{
    public GameObject restartScreen;
    // Update is called once per frame
    void Update()
    {   
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
        
    }

    public void OnTriggerEnter(Collider collider) {
        this.GetComponent<Renderer>().material.SetColor("_Color", Random.ColorHSV(0f,1f,0.7f,1f,0.7f,1f));
        restartScreen.SetActive(true);
    }
}
