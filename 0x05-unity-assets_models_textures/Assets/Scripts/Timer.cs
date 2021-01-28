using UnityEngine;
using UnityEngine.UI;


public class Timer : MonoBehaviour
{
    public Text TimerText;
    float timer;
    float milliseconds;
    float seconds;
    float minutes;

    void Start()
    {
        timer = 0;
    }

    void Update()
    {
        StopWatchCalcul();
    }

    void StopWatchCalcul()
    {
        timer += Time.deltaTime;
        Debug.Log(timer);
        minutes = (int)(timer / 60);
        seconds = (int)(timer % 60);
        milliseconds = (int)((timer - seconds) * 100) % 100;
        TimerText.text = $"{minutes.ToString("0")}:{seconds.ToString("00")}:{milliseconds.ToString("00")}";
    }


}
