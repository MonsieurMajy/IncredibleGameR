using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class FinishMenuScript : MonoBehaviour
{
    public GameObject restartScreen;

    public void restartGame()
    {  
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        restartScreen.SetActive(false);
    }
}
