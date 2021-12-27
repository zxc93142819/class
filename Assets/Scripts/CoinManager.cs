using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    public GameObject Coin;
    bool coinSet1, coinSet2, coinSet3, coinSet4, coinSet5, coinSet6, coinSet7, coinSet8, coinSet9
        , coinSet10, coinSet11, coinSet12, coinSet13;
    public int coins = 0;
    private void Start()
    {
        coinSet1 = false;
        coinSet2 = false;
        coinSet3 = false;
        coinSet4 = false;
        coinSet5 = false;
        coinSet6 = false;
        coinSet7 = false;
        coinSet8 = false;
        coinSet9 = false;
        coinSet10 = false;
        coinSet11 = false;
        coinSet12 = false;
        coinSet13 = false;
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
        if (coins > 300 && !coinSet6)
        {
            Time.timeScale = 2.7f;
            coinSet6 = true;
        }
        if (coins > 400 && !coinSet7)
        {
            Time.timeScale = 3.0f;
            coinSet7 = true;
        }
        if (coins > 500 && !coinSet8)
        {
            Time.timeScale = 3.3f;
            coinSet8 = true;
        }
        if (coins > 600 && !coinSet9)
        {
            Time.timeScale = 3.6f;
            coinSet9 = true;
        }
        if (coins > 700 && !coinSet10)
        {
            Time.timeScale = 3.9f;
            coinSet10 = true;
        }
        if (coins > 800 && !coinSet11)
        {
            Time.timeScale = 4.2f;
            coinSet11 = true;
        }
        if (coins > 900 && !coinSet12)
        {
            Time.timeScale = 4.5f;
            coinSet12 = true;
        }
        if (coins > 1000 && !coinSet13)
        {
            Time.timeScale = 5f;
            coinSet13 = true;
        }
        Coin.GetComponent<Text>().text = coins + "";
    }
}
