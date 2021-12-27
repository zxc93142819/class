using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bridge_sensor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.transform.name == "viking_axes"){
            Debug.Log("viking enter");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
