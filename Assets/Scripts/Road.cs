using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    GameObject player;
    float dis;
    bool isTread = false;
    bool isSpawn = false;
    // Start is called before the first frame update
    void Start()
    {
        player = transform.parent.GetComponent<RoadManager>().Player;
    }

    // Update is called once per frame
    void Update()
    {
        dis = Vector3.Distance(transform.position, player.transform.position);
        if(gameObject&&isTread&&dis > 5)
        {
            transform.parent.GetComponent<RoadManager>().SpawnRoad(transform.position+new Vector3(0,0,5));
            isTread = false;
            isSpawn = true;
        }
        else
        {
            if (isSpawn&&dis > 10)
            {
                Destroy(gameObject);
            }
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isTread = true;
        }
    }
}
