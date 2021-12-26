using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameIntroduction : MonoBehaviour
{
    [SerializeField] GameObject intro;
    [SerializeField] GameObject menu;
    [SerializeField] GameObject landScape;
    [SerializeField] GameObject GameStartHint;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        landScape.GetComponent<StartGame>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Time.timeScale = 1;
            landScape.GetComponent<StartGame>().enabled = true;
            intro.SetActive(false);
            GameStartHint.SetActive(true);
            menu.GetComponent<Button>().interactable = true;
        }
    }
}
