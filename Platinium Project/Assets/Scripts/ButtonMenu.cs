using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonMenu : MonoBehaviour
{
    //public GameObject audioManager;
    //public GameObject rulesCanvas;
    public static bool isStart = false;

    private void Start()
    {
        isStart = false;
        //audioManager = GameObject.Find("AudioManager");
    }
    public void OnClickPlay()
    {
        //ScoreScript.scoreIncreasing = true;
        //audioManager.GetComponent<AudioManager>().Stop("theme");
        SceneManager.LoadScene(1);
        isStart = true;
        //FindObjectOfType<AudioManager>().Play("click");
    }

    public void OnClickRestart()
    {
       //ScoreScript.scoreIncreasing = true;
        SceneManager.LoadScene(1);
        //FindObjectOfType<AudioManager>().Play("click");
    }

    public void OnClickMenu()
    {
        //audioManager.GetComponent<AudioManager>().Stop("wind");
        //audioManager.GetComponent<AudioManager>().Play("theme");
        SceneManager.LoadScene(0);
        isStart = false;
        //ScoreScript.scoreIncreasing = true;
        //FindObjectOfType<AudioManager>().Play("click");
    }

    public void OnClickRules()
    {
        //rulesCanvas.SetActive(true);
        //FindObjectOfType<AudioManager>().Play("click");
    }

    public void OnClickRulesQuit()
    {
        //rulesCanvas.SetActive(false);
        //FindObjectOfType<AudioManager>().Play("click");
    }

    public void OnClickQuit()
    {
        Application.Quit();
        //FindObjectOfType<AudioManager>().Play("click");
    }
}
