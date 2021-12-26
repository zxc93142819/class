using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    float time = 50;
    float delay = 0;
    bool IsGameStart = false;
    bool isGamePause = false;
    // Start is called before the first frame update
    void Start()
    {
        time = Time.deltaTime * 1000;
    }
    // Update is called once per frame
    void Update()
    {
        
        if (transform.parent.name == "landscapes"&&!IsGameStart)
        {
          IsGameStart = transform.parent.GetComponent<StartGame>().isGameStart;
          
        }
        else if(transform.parent.name == "RoadManager"&&!IsGameStart)
        {
          IsGameStart = transform.parent.GetComponent<RoadManager>().isGameStart;
        }
        if (transform.parent.name == "landscapes" && isGamePause)
        {
            isGamePause = transform.parent.GetComponent<StartGame>().isGamePause;

        }
        else if (transform.parent.name == "RoadManager" && isGamePause)
        {
            isGamePause = transform.parent.GetComponent<RoadManager>().isGamePause;
        }
        if (IsGameStart&&!isGamePause)
        {
            Die();
        }
        
    }
    void Die()
    {
        delay+=Time.deltaTime;
        if (delay >= time)
        {
            Destroy(gameObject);
        }
    }
}
