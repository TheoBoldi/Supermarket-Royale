using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public AudioSource backgroundMusic;
    public AudioSource pickupSound;

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
}
