﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SceneSwicher : MonoBehaviour , IPointerClickHandler
{           //scene轉換器，不只是menu轉game
    public int SceneIndexDestination = 0;

    public void OnPointerClick(PointerEventData e)
    {
        //load a new scene
        SceneManager.LoadScene(SceneIndexDestination);
    }
}
