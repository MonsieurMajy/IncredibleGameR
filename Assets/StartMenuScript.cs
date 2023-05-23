using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartMenuScript : MonoBehaviour
{   
    void Start()
    {
        Cursor.visible = true;
    }
    void Update()
    {        
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }

    }
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
