using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public GameObject player;
    public bool isGameStart = false;
    public bool isGamePause = false;
    [SerializeField] GameObject ground;
    [SerializeField] GameObject enimy;
    [SerializeField] GameObject FirstRoad;
    [SerializeField] GameObject GameStartHint;
    
    private void Update()
    {
        if (Input.GetKey(KeyCode.W)&&!isGameStart&&!isGamePause)
        {
            Instantiate(FirstRoad, player.transform.position, player.transform.rotation, transform.GetChild(0));
            //Instantiate(enimy, transform);
            ground.SetActive(false);
            GameStartHint.SetActive(false);
            isGameStart = true;
            player.GetComponent<Rigidbody>().useGravity = true;
            player.transform.eulerAngles = new Vector3(0f, 0f, 0f);
            player.transform.position = new Vector3(0f, 4f, 5f);
            enimy.SetActive(true);
            //enimy.transform.eulerAngles = new Vector3(0f, 0f, 0f);
            //enimy.transform.position = new Vector3(0f, 6f, 1f);
        }
    }
}
