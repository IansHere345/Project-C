using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class gameTimerScript : MonoBehaviour
{
    public float timeLeft;
    public bool TimerOn;
    public TextMeshProUGUI GameTimer;
    public pointsScript pointsScript1;
    public pointsScript pointsScript2;
    public playerMovement player1Movement;
    public playerMovement player2Movement;
    public static int winnerID;
    private bool halfwayPoint = false;
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
                if (timeLeft <= 90 && !halfwayPoint)
                {
                    halfwayPoint = true;
                    player1Movement.speed = 10;
                    player2Movement.speed = 10;
                    //halfway through the game, both players go back to default speed. Speed Boosts can be collected to bring the boost back.
                }
            }
            else
            {
                timeLeft = 0;
                TimerOn = false;
                if (pointsScript1.currentPoints > pointsScript2.currentPoints)
                {
                    gameEndedManager.winner = "Blue Wins!!!";
                    //If player 1 has more points than player 2, player 1 wins.
                    gameEndedManager.winnerID = 1;
                }
                else if (pointsScript2.currentPoints > pointsScript1.currentPoints)
                {
                    gameEndedManager.winner = "Orange Wins!!!";
                    //If player 2 has more points than player 1, player 2 wins.
                    gameEndedManager.winnerID = 2;
                }
                else
                {
                    gameEndedManager.winner = "Wow... You guys both suck! Did you both happen to huff glue before playing this game? Because that would explain a lot.";
                    //If both players have the same amount of points, the game is a tie. (Message is kinda funny)
                    gameEndedManager.winnerID = 3;
                }
                SceneManager.LoadScene("ResultsScene");
            }
        }
    }
    void UpdateTimer(float currentTime)
    {
        currentTime += 1;

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);
        
        GameTimer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        //Time is displayed in minutes then seconds.
    }
}
//Source Used: https://youtube.com/shorts/hxpUk0qiRGs?si=C1-azELwIE4sN_g0
