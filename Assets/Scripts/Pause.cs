using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    [SerializeField] GameObject button;
    [SerializeField] GameObject menu;
    [SerializeField] GameObject main;
    public void pause_button()
    {
        main.GetComponent<StartGame>().isGamePause = true;
        button.GetComponent<Button>().enabled = false;
        button.GetComponent<Button>().interactable = false;
        Time.timeScale = 0;
        menu.SetActive(true);
        
    }
    public void continue_button()
    {
        main.GetComponent<StartGame>().isGamePause = false;
        button.GetComponent<Button>().enabled = true;
        button.GetComponent<Button>().interactable = true;
        Time.timeScale = 1;
        menu.SetActive(false);
    }

}
