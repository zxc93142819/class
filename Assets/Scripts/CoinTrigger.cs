using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinTrigger : MonoBehaviour
{
    [SerializeField] float time = 10;
    [SerializeField] float delay = 0;

    [SerializeField] bool IsGameStart = false;
    [SerializeField] bool isGamePause = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            transform.parent.GetComponent<CoinManager>().coins++ ;
            Destroy(gameObject);
        
        }
    }
    private void Start()
    {
        time = 10;
    }
    private void Update()
    {
            IsGameStart = transform.parent.parent.GetComponent<StartGame>().isGameStart;
            isGamePause = transform.parent.parent.GetComponent<StartGame>().isGamePause;
        
        if (IsGameStart && !isGamePause)
        {
            Die();
        }
    }
    void Die()
    {
        delay += Time.deltaTime;
        if (delay >= time)
        {
            Destroy(gameObject);
        }
    }
}
