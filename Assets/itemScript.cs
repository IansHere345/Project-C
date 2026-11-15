using UnityEngine;

public class itemScript : MonoBehaviour
{
    public bool pointIncrease;
    public bool largePointIncrease;
    public bool pointDecrease;
    public bool largePointDecrease;
    public bool speedPowerUp;
    public bool healthPowerUp;
    public bool skullPowerUp;
    public bool activeFiringMode;
    public int healthIncreaseAmount = 1;
    public int healthDecreaseAmount = 1;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (pointIncrease)
            {
                other.GetComponent<pointsScript>().Add1Point(1);
            }
            else if (largePointIncrease)
            {
                other.GetComponent<pointsScript>().Add3Point(3);
            }
            else if (pointDecrease)
            {
                other.GetComponent<pointsScript>().Decrease1Point(1);
            }
            else if (largePointDecrease)
            {
                other.GetComponent<pointsScript>().Decrease3Point(3);
            }
            else if (speedPowerUp)
            {
                other.GetComponent<playerMovement>().ActiveSpeedBoost();
            }
            else if (healthPowerUp)
            {
                other.GetComponent<playerHealth>().Heal(healthIncreaseAmount);
            }
            else if (skullPowerUp)
            {
                other.GetComponent<playerHealth>().DecreaseHealth(healthDecreaseAmount);
            }
            //else if (fireRatePowerUp)
            {
                //other.GetComponent<>().ActiveFireRateBoost();
            }
            Destroy(gameObject);
        }
    }
}
