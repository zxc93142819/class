using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpingmusiccontroller : MonoBehaviour
{
    private static AudioSource jumping_music;
    private static GameObject jumpingmusic;

    public static void Start()
    {
        /*
        jumping_music = GameObject.FindGameObjectWithTag("Jumping Music").GetComponent<AudioSource>();
        */
        jumping_music.enabled = true;
    }

    public static void OnEnable()
    {
        /*
        jumping_music = GameObject.FindGameObjectWithTag("Jumping Music").GetComponent<AudioSource>();

        jumping_music.Pause();
        jumping_music.enabled = false;
        */
    }

    public static void OnDisable()
    {
        /*
        jumping_music.UnPause();
        */
    }
}
