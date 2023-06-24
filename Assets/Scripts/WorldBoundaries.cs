using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldBoundaries : MonoBehaviour
{
    public GameObject gameOverMenu;
    public void OnTriggerExit(Collider collider){
        Debug.Log("player exited world!");
        if (collider.CompareTag("Ball"))
        {
            Time.timeScale = 0;
            gameOverMenu.SetActive(true);
        }
    }

    public void RestartLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        gameOverMenu.SetActive(false);
    }

    public void ExitGame() {
        Application.Quit();
    }
}
