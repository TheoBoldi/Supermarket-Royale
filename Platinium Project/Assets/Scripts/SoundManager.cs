using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public AudioSource backgroundMusic;
    public AudioSource pickupSound;
    public AudioSource fallSound;
    public AudioClip fall1;
    public AudioClip fall2;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        instance.BackgroundMusic();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void BackgroundMusic()
    {
        backgroundMusic.Play();
    }

    public void PickUpSound()
    {
        pickupSound.Play();
    }

    public void FallSound()
    {
        int rand = Random.Range(0, 2);

        if (rand == 0)
        {
            fallSound.clip = fall1;
        }
        else if (rand == 1)
        {
            fallSound.clip = fall2;
        }

        fallSound.Play();
    }
}
