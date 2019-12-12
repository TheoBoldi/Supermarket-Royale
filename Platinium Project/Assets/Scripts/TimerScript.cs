using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    public Text timerText;
    private float time = 120;
    private bool _isTimerEnabled = false;

    void StartCoundownTimer()
    {
        if (timerText != null)
        {
            _isTimerEnabled = true;
            time = 120;
            timerText.text = "02:00";
        }
    }

    private void Update()
    {
        if(_isTimerEnabled) UpdateTimer();
    }

    void UpdateTimer()
    {
        if (timerText != null)
        {
            time -= Time.deltaTime;
            if(time < 0f)
            {
                time = 0f;
            }
            string minutes = Mathf.Floor(time / 60f).ToString("00");
            string seconds = (Mathf.Floor(time % 60)).ToString("00");
            timerText.text = minutes + ":" + seconds;
        }
    }
}
