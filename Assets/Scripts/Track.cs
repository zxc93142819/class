using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Track : MonoBehaviour
{
    public GameObject obj;
    public GameObject tracker;
    Vector3 diretion;
    public float speed = 5f;
    

    // Update is called once per frame
    void Update()
    {
        diretion = obj.transform.position- tracker.transform.position;
        
        tracker.transform.Translate(diretion * speed * Time.deltaTime);
    }
}
