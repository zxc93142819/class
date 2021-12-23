using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{

    public GameObject player;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            player.GetComponent<Player>().isGameStart = true;
            player.transform.eulerAngles = new Vector3(0f,0f,0f);
            player.transform.position = new Vector3(0f,1f,6f);
        }
    }
}
