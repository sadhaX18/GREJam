using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 90;
    private bool timerIsRunning = false;
    private void Start()
    {
        timerIsRunning = true;
        //clock = GetComponent<Text>();
    }
    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
            }
        }
    }

    public void SetRemainingTime(float _timeRemaining)
    {
        if(!timerIsRunning)
        {
            timeRemaining = _timeRemaining;
            timerIsRunning = true;
        }
    }
    public float GetTime() { return timeRemaining; }
    
}
