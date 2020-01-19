using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LapTimeScript : MonoBehaviour
{
    public GameObject currentTime;
    public GameObject lastLapTime;
    private Text currentTimeText;
    private Text lastLapTimeText;
    private float timer = 0;
    private int elapsedTime = 0;
    private string timeFormatted;
    private int lastTime = 0;

    void Start()
    {
        currentTimeText = currentTime.gameObject.GetComponent<Text>();
        lastLapTimeText = lastLapTime.gameObject.GetComponent<Text>();
}
   
    void FixedUpdate()
    {
        int currentTimeSeconds;
        int currentTimeMinutes;
        timer += Time.deltaTime;
           if(timer >= 1)
           {
                elapsedTime += 1;
               timer = 0;
            }
           currentTimeSeconds = elapsedTime % 60;
           currentTimeMinutes = elapsedTime / 60;
           currentTimeText.text = "Time: " + timeCalc(currentTimeSeconds, currentTimeMinutes);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")){
            int lapTime = elapsedTime - lastTime;
            int lapTimeSeconds = lapTime % 60;
            int lapTimeMinutes = lapTime / 60;
            lastLapTimeText.text = "Last Lap: " + timeCalc(lapTimeSeconds, lapTimeMinutes);
            lastTime = elapsedTime;
        }
    }

    private string timeCalc(int timeSeconds, int timeMinutes)
    {
        string minutesString;
        string secondsString;
        if (lastTime > 0)
        {
            
        }
        if (timeMinutes < 10)
        {
            minutesString = "0" + timeMinutes;
        }
        else {
            minutesString = "" + timeMinutes;
        }
        if (timeSeconds < 10)
        {
            secondsString = "0" + timeSeconds;
        }
        else { secondsString = "" + timeSeconds; }

        return minutesString + ":" + secondsString;
    }
}
