using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class score_zone_script : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider collider) {
        this.GetComponent<Renderer>().material.SetColor("_Color", Random.ColorHSV(0f,1f,0.7f,1f,0.7f,1f));
    }
}
