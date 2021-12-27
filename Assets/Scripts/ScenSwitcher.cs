using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ScenSwitcher : MonoBehaviour, IPointerClickHandler
{
    public int SceneIndexDestination = 0;
    public Scene scene ;
    public Canvas previous_canvas ;

    public void OnPointerClick(PointerEventData eventData)
    {
        SceneManager.LoadScene(SceneIndexDestination);
    }
}
