using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("YOu Die!");
            Time.timeScale = 0;

            other.GetComponent<Animator>().enabled = false;
        }
    }
}
