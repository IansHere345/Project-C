using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class menuTimerScript : MonoBehaviour
{
    public float timeLeft;
    public bool TimerOn;
    public TextMeshProUGUI MenuTimerText;
    public string LevelTransitionName = "Level1Scene";
    //private bool isLoadingScene = false;
    public GameObject ControlsButton;
    public GameObject GuideButton;
    public GameObject OptionsButton;
    public GameObject CreditsButton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MenuTimerText.enabled = false;
        //hides the text when the game starts.
    }

    // Update is called once per frame
    void Update()
    {
        if (TimerOn)
        {
            ControlsButton.SetActive(false);
            GuideButton.SetActive(false);
            OptionsButton.SetActive(false);
            CreditsButton.SetActive(false);
            MenuTimerText.enabled = true;
            //enables the text once players ready up.
            if (timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
                updateTimer(timeLeft);
            }
            else
            {
                timeLeft = 0;
                TimerOn = false;
                //isLoadingScene = true;
                SceneManager.LoadScene(LevelTransitionName);
            }
        }
    }
    void updateTimer(float currentTime)
    {
        currentTime += 1;

        float seconds = Mathf.FloorToInt(currentTime % 60);

        MenuTimerText.text = string.Format("{0}", seconds);
    }
}
//Source Used: https://youtube.com/shorts/hxpUk0qiRGs?si=C1-azELwIE4sN_g0

//The Colored text on the title screen is done using <color=insert color here>Insert word here
//The Source for that: https://www.youtube.com/watch?v=kWAd7Qtn_Tw&t=68s