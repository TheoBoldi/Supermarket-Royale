using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    private int next;

    public GameObject fondusortie;

    // Start is called before the first frame update
    void Start()
    {
        next = SceneManager.GetActiveScene().buildIndex + 1;
    }


    public void NextS()
    {
        //if (Input.GetKeyDown(KeyCode.Joystick1Button0))
        //{
            fondusortie.SetActive(true);
            Invoke("nextSS", 1);
        //}
            
    }
    private void nextSS()
    {
        SceneManager.LoadScene(next);
    }
    
}
