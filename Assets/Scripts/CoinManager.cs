using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    public GameObject Coin;
    bool coinSet1, coinSet2, coinSet3, coinSet4, coinSet5;
    public int coins = 0;
    private void Start()
    {
        coinSet1 = false;
        coinSet2 = false;
        coinSet3 = false;
        coinSet4 = false;
        coinSet5 = false;
        coins = 0;
    }
    // Update is called once per frame
    void Update()
    {
        if(coins > 10&&!coinSet1)
        {
            Time.timeScale = 1.2f;
            coinSet1 = true;
        }
        if (coins > 30&& !coinSet2)
        {
            Time.timeScale = 1.4f;
            coinSet2 = true;
        }
        if (coins > 50&& !coinSet3)
        {
            Time.timeScale = 1.8f;
            coinSet3 = true;
        }
        if (coins > 100 && !coinSet4)
        {
            Time.timeScale = 2f;
            coinSet4 = true;
        }

        if (coins > 200 && !coinSet5)
        {
            Time.timeScale = 2.5f;
            coinSet5 = true;
        }
        Coin.GetComponent<Text>().text = coins + "";
    }
}
