using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resume_controller : MonoBehaviour
{
    public GameObject PauseMenuUI ;
    // Update is called once per frame
    public void OnDownBtn()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        Pause.GameIsPause = false;
    }
}
