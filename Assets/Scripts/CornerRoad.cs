using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CornerRoad : MonoBehaviour
{
    public GameObject player;
    private void Start()
    {
    }
    private void OnTriggerEnter(Collider other)
    {
       
        if (other.tag == "Player")
        {

            if (gameObject.tag == "Corner_Road_Right")
            {
                player.GetComponent<Player>().isCorner = true;
                player.GetComponent<Player>().RotateCode = 0;
            }else if(gameObject.tag == "Corner_Road_Left")
            {
                player.GetComponent<Player>().isCorner = true;
                player.GetComponent<Player>().RotateCode = 1;
            }
        }
    }
}
