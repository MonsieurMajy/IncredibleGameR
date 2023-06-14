using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelectorScript : MonoBehaviour
{   
    public static int levelSelected;
    public int levelIndex;
    public Toggle levelButton;
    public Button playButton;
    public Text levelText;

    // Start is called before the first frame update
    void Start()
    {
        levelText.text = levelIndex.ToString();
        if(levelIndex > LevelManager.availableLevels) {
            levelButton.interactable = false;
        }
    }

    public void selectLevel(bool b)
    {
        SceneManager.LoadScene("Level_" + levelIndex);
    }
}
