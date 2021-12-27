using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Die : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject score;
    [SerializeField] GameObject Coininscore;
    [SerializeField] GameObject scoreboard;
    [SerializeField] GameObject Coin;
    [SerializeField] GameObject Obstacle;
    [SerializeField] GameObject fall;
    [SerializeField] GameObject caught;
    [SerializeField] GameObject Pause;

    // Start is called before the first frame update
    void Start()//0 = fall , 1 = hit obstacle, 2 = caught by enemy, -1 = none
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Coininscore.GetComponent<Text>().text = Coin.GetComponent<Text>().text;

        if (player.GetComponent<Player>().dieBecause == -1)
        {
            return;
        }
        if(player.GetComponent<Player>().dieBecause == 0)
        {
            int scoreTemp = int.Parse(Coininscore.GetComponent<Text>().text);
            int result = 0;
            int scale = 10;
            while (scoreTemp > 0)
            {
                result += (scoreTemp % 10) * scale;
                scoreTemp /= 10;
                scale *= 17;
            }
            Pause.GetComponent<Button>().interactable = false;
            Pause.GetComponent<Button>().enabled = false;

            score.GetComponent<Text>().text = result + "";
            fall.SetActive(true);
        }else if (player.GetComponent<Player>().dieBecause == 1)
        {
            int scoreTemp = int.Parse(Coininscore.GetComponent<Text>().text);
            int result = 0;
            int scale = 10;
            while (scoreTemp > 0)
            {
                result += (scoreTemp % 10) * scale;
                scoreTemp /= 10;
                scale *= 17;
            }
            Pause.GetComponent<Button>().interactable = false;
            Pause.GetComponent<Button>().enabled = false;

            score.GetComponent<Text>().text = result + "";
            Obstacle.SetActive(true);
        }
        else if (player.GetComponent<Player>().dieBecause == 2)
        {
            int scoreTemp = int.Parse(Coininscore.GetComponent<Text>().text);
            int result = 0;
            int scale = 10;
            while (scoreTemp > 0)
            {
                result += (scoreTemp % 10) * scale;
                scoreTemp /= 10;
                scale *= 17;
            }
            Pause.GetComponent<Button>().interactable = false;
            Pause.GetComponent<Button>().enabled = false;

            score.GetComponent<Text>().text = result + "";
            caught.SetActive(true);
        }
    }
    public void CheckPoint()
    {
        gameObject.SetActive(false);
        scoreboard.SetActive(true);
    }
}
