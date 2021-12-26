using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadManager : MonoBehaviour
{
    public GameObject[] rm;
    public GameObject player;
    public int CornerCount = 0;
    public int Obstacle = 0;
    public float nowRotate = 0;
    public bool isGameStart = false;
    public bool isGamePause = false;
    public GameObject[] rotate;
    private void Update()
    {
        if (isGamePause)
        {
            isGamePause = transform.parent.GetComponent<StartGame>().isGamePause;
        }
        if (!isGameStart)
        {
            isGameStart = transform.parent.GetComponent<StartGame>().isGameStart;
        }
    }
}
