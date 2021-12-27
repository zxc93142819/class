using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Destroy : MonoBehaviour
{
    [SerializeField]float time = 50;
    [SerializeField] float delay = 0;
    [SerializeField] bool IsGameStart = false;
    [SerializeField] bool isGamePause = false;
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
        else if (transform.parent.name == "RoadManager" && !IsGameStart)
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
