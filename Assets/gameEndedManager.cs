using UnityEngine;
using TMPro;

public class gameEndedManager : MonoBehaviour
{
    public static string winner;
    public static int winnerID;
    public GameObject bluePlayer;
    public GameObject orangePlayer;

    void Start()
    {
        bluePlayer.SetActive(false);
        orangePlayer.SetActive(false);
        TextMeshProUGUI winnerText = GameObject.Find("WinnerText").GetComponent<TextMeshProUGUI>();
        if (winnerText != null)
        {
            winnerText.text = winner;
        }
        if (winnerID == 1)
        {
            bluePlayer.SetActive(true);
            orangePlayer.SetActive(false);
        }
        else if (winnerID == 2)
        {
            bluePlayer.SetActive(false);
            orangePlayer.SetActive(true);
        }
        else if (winnerID == 3)
        {
            bluePlayer.SetActive(false);
            orangePlayer.SetActive(false);
        }
    }
}
