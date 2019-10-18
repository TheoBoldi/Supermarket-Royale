using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public AudioSource paper;
    public AudioSource buzzWave;
    public AudioSource item;
    public AudioSource bootGenerator;
    public AudioSource accessGranted;
    public AudioSource accessDenied;
    public AudioSource doorOpen;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PickUpPaper()
    {
        paper.Play();
    }

    public void PickUpItem()
    {
        item.Play();
    }

    public void BootGenerator()
    {
        bootGenerator.Play();
    }

    public void AccessDenied()
    {
        accessDenied.Play();
    }

    public void AccessGranted()
    {
        accessGranted.Play();
    }

    public void Opendoor()
    {
        doorOpen.Play();
    }

}
