using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public GameObject player;
    public bool isGameStart = false;
    public bool isGamePause = false;
    [SerializeField] GameObject GameStartHint;
    private void Update()
    {
        if (Input.GetKey(KeyCode.W) && !isGameStart && !isGamePause)
        {
            GameStartHint.SetActive(false);
            isGameStart = true;
            player.transform.eulerAngles = new Vector3(0f, 0f, 0f);
            player.transform.position = new Vector3(0f, 1f, 6f);
        }
    }
}
