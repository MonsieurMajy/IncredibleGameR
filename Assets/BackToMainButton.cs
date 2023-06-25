using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BackToMainButton : MonoBehaviour
{
   public GameObject creditsPanel;

   public void OnClick(){
    creditsPanel.SetActive(false);
   }
}
