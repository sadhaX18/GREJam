using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    Timer timer;
    Text clock;
    // Start is called before the first frame update
    void Start()
    {
        timer = GetComponent<Timer>();
        clock = GameObject.FindGameObjectWithTag("Clock").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        DisplayTime(timer.GetTime());
    }
    void DisplayTime(float timeToDisplay)
    {
        if (timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }

        int minutes = Mathf.FloorToInt(timeToDisplay / 60);
        int seconds = Mathf.FloorToInt(timeToDisplay % 60);

        clock.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

}
