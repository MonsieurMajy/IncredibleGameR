using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitMenuScript : MonoBehaviour
{
    public GameObject quitMenu;
    public void confirmExit() {
        Application.Quit();
    }

    public void cancelExit(){
        quitMenu.SetActive(false);
        Time.timeScale = 1;
    }

    void Update()
    {   
        if (Input.GetKeyDown(KeyCode.Escape))
        {   
            cancelExit();
        }     
    }
}
