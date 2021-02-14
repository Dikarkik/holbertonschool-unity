using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;
    public Text finalTimeText;
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
        timerText.text = $"{minutes.ToString("0")}:{seconds.ToString("00")}:{milliseconds.ToString("00")}";
    }

    public void StopTimer()
    {
        timerActive = false;
        timerText.color = Color.green;
        timerText.fontSize = 60;
    }

    public void Win()
    {
        finalTimeText.text = timerText.text;
        timerText.gameObject.SetActive(false);
        FindObjectOfType<CameraController>().CameraDisabled = true;
        FindObjectOfType<PlayerController>().enabled = false;
        Cursor.visible = true;
    }
}
