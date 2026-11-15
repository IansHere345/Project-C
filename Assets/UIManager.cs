using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI Player1HealthText;
    public TextMeshProUGUI Player2HealthText;
    public TextMeshProUGUI Player1PointsText;
    public TextMeshProUGUI Player2PointsText;
    public TextMeshProUGUI Player1SpeedBoostText;
    public TextMeshProUGUI Player2SpeedBoostText;
    public playerHealth Player1Health;
    public playerHealth Player2Health;
    public pointsScript Player1Points;
    public pointsScript Player2Points;
    public playerMovement Player1SpeedBoost;
    public playerMovement Player2SpeedBoost;
    void Update()
    {
        UpdateHealth();
        UpdatePoints();
        UpdateSpeedBoost();
    }
    void UpdateHealth()
    {
        if (Player1HealthText != null)
        {
            if (Player1Health != null)
            {
                Player1HealthText.text = "Health: " + Player1Health.CurrentHealth;
            }
            else
            {
                Player1HealthText.text = "Health: 0";
            }
        }

        if (Player2HealthText != null)
        {
            if (Player2Health != null)
            {
                Player2HealthText.text = "Health: " + Player2Health.CurrentHealth;
            }
            else
            {
                Player2HealthText.text = "Health: 0";
            }
        }
    }
    void UpdatePoints()
    {
        if (Player1PointsText != null)
        {
            if (Player1Points != null)
            {
                Player1PointsText.text = "Score: " + Player1Points.currentPoints;
            }
            else
            {
                Player1PointsText.text = "Score: 0";
            }
        }

        if (Player2PointsText != null)
        {
            if (Player2Points != null)
            {
                Player2PointsText.text = "Score: " + Player2Points.currentPoints;
            }
            else
            {
                Player2PointsText.text = "Score: 0";
            }
        }
    }
    void UpdateSpeedBoost()
    {
        if (Player1SpeedBoostText != null)
        {
            if (Player1SpeedBoost != null)
            {
                Player1SpeedBoostText.text = "Speed: " + Player1SpeedBoost.speed;
            }
            else
            {
                Player1SpeedBoostText.text = "Speed: 0";
            }
        }

        if (Player2SpeedBoostText != null)
        {
            if (Player2SpeedBoost != null)
            {
                Player2SpeedBoostText.text = "Speed: " + Player2SpeedBoost.speed;
            }
            else
            {
                Player2SpeedBoostText.text = "Speed: 0";
            }
        }
    }
}
