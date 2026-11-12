using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class gameTimerScript : MonoBehaviour
{
    public float timeLeft;
    public bool TimerOn;
    public TextMeshProUGUI GameTimer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        TimerOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(TimerOn)
        {
            if (timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
                UpdateTimer(timeLeft);
            }
            else
            {
                timeLeft = 0;
                TimerOn = false;
                UpdateTimer(timeLeft);
            }
        }
    }
    void UpdateTimer(float currentTime)
    {
        currentTime += 1;

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);
        
        GameTimer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
