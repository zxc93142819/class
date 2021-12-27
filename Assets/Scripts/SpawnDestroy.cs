using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDestroy : MonoBehaviour
{
    [SerializeField] GameObject gameStart;
    float time = 50f;
    float count = 0f;
    // Start is called before the first frame update
    void Start()
    {
        if (gameStart.GetComponent<StartGame>().isGameStart&& gameStart.GetComponent<StartGame>().isGamePause)
        {
            time = 50f;
            count = 0f;
        }    
    }

    // Update is called once per frame
    void Update()
    {
        count += Time.deltaTime;
        if(count >= time)
        {
            Destroy(gameObject);
        }
    }
}
