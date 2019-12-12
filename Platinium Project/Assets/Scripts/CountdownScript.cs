using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountdownScript : MonoBehaviour
{
    public AudioSource Countdown;
    public AudioSource backgroundMusic;

    public GameObject UIJ1;
    public GameObject UIJ2;
    public GameObject UIJ3;
    public GameObject UIJ4;

    public AudioClip background2;

    public void PlayCountdown()
    {
        Countdown.Play();
    }

    public void HideUI()
    {
        UIJ1.SetActive(false);
        UIJ2.SetActive(false);
        UIJ3.SetActive(false);
        UIJ4.SetActive(false);
    }

    public void ChangeBackground()
    {
        backgroundMusic.clip = background2;
        backgroundMusic.Play();
    }
}
