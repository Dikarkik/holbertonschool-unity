using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text TimerText;
    float timer;
    float milliseconds;
    float seconds;
    float minutes;
    bool timerActive = true;

    void Start()
    {
        timer = 0;
    }

    void Update()
    {
        if (timerActive)
            StopWatchCalcul();
    }

    void StopWatchCalcul()
    {
        timer += Time.deltaTime;
        minutes = (int)(timer / 60);
        seconds = (int)(timer % 60);
        milliseconds = (int)((timer - seconds) * 100) % 100;
        TimerText.text = $"{minutes.ToString("0")}:{seconds.ToString("00")}:{milliseconds.ToString("00")}";
    }

    public void StopTimer()
    {
        timerActive = false;
        TimerText.color = Color.green;
        TimerText.fontSize = 60;
    }
}
