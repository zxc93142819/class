using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CornerRoad : MonoBehaviour
{
    GameObject player;
    public GameObject trigger;
    private void Start()
    {
        player = transform.parent.parent.GetComponent<RoadManager>().player;
    }
    private void OnTriggerEnter(Collider other)
    {
       
        if (other.tag == "Player")
        {

            Debug.Log("POP!!");
            if (gameObject.tag == "Corner_Road_Right")
            {
                player.GetComponent<Player>().isRight = true;
                player.GetComponent<Player>().isCorner = true;
                trigger.SetActive(false);
                player.GetComponent<Player>().RotateCode = 0;
            }else if(gameObject.tag == "Corner_Road_Left")
            {
                player.GetComponent<Player>().isRight = false;
                player.GetComponent<Player>().isCorner = true;
                trigger.SetActive(false);

                player.GetComponent<Player>().RotateCode = 1;
            }
        }
    }
}
