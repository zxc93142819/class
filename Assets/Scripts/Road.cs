using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour//three kinds of Road straight ,right ,left
{
    public GameObject[] rm;
    public Collider bound;
    public GameObject player;
    float time;
    bool isDead = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            Die();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Copy();
        }
    }
    void Copy()
    {//Use RoadManager to Maintain the multi Roads
        int r = Random.Range(0,rm.Length);
        GameObject go = rm[r];
        time = Time.time+5f;
        Vector3 pos;
        Debug.Log(player.GetComponent<Player>().isX);
        if (!player.GetComponent<Player>().isX)
        {
            if (player.GetComponent<Player>().isRight)
            {
                float length = bound.bounds.extents.z * 2;
                pos = transform.position + new Vector3(0, 0, length);
            }
            else
            {
                float length = bound.bounds.extents.z * 2;
                pos = transform.position + new Vector3(0, 0, -length);
            }
        }
        else
        {
            if (player.GetComponent<Player>().isRight)
            {
                float length = bound.bounds.extents.x * 2;
                pos = transform.position + new Vector3(length, 0, 0);
            }
            else
            {
                float length = bound.bounds.extents.x * 2;
                pos = transform.position + new Vector3(-length, 0, 0);
            }
        }
        Instantiate(go, pos, transform.rotation);
        //isDead = true;*********************//if test over you should turn on
    }
    void Die()
    {
        if(Time.time > time)
        {
            Destroy(gameObject);
            //isDead = false;
        }
    }
}
