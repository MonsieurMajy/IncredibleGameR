using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditsButton : MonoBehaviour
{

    public Text creditsText;
    public GameObject creditsPanel;

    private void Start()
    {
        // Disable the credits text initially
        creditsText.gameObject.SetActive(false);
    }

    public void OnHoverEnter()
    {
        // Enable and display the credits text
        creditsText.gameObject.SetActive(true);
        creditsText.text = "Credits";
    }

    public void OnHoverExit()
    {
        // Disable the credits text when the hover is exited
        creditsText.gameObject.SetActive(false);
    }

    public void OnClick() {
        creditsPanel.SetActive(true);
    }

}
