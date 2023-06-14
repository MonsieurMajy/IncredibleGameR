using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ExitMenuScript : MonoBehaviour
{
    public GameObject exitMenu;
    public void confirmExit() {
        Application.Quit();
    }

    public void backToGame(){
        exitMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void goToMainMenu(){
        SceneManager.LoadScene("Level Menu");
    }

    void Update()
    {   
        if (Input.GetKeyDown(KeyCode.Escape))
        {   
            backToGame();
        }     
    }
}
