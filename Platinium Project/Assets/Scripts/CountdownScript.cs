using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountdownScript : MonoBehaviour
{
    public AudioSource Countdown;

    public void PlayCountdown()
    {
        Countdown.Play();
    }
}
