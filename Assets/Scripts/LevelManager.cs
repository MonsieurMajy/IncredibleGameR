using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{   
    public static int availableLevels = 5;
    public GameObject quitMenu;
    public GameObject creditsMenu;

    void Start()
    {
        quitMenu.SetActive(false);
        creditsMenu.SetActive(false);
    }
     void Update()
    {   
        if (Input.GetKeyDown(KeyCode.Escape) || (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.Q)))
        {   
            quitMenu.SetActive(true);
        }
    }

    public void backToMenu(){
        quitMenu.SetActive(false);
        creditsMenu.SetActive(false);
    }
}
