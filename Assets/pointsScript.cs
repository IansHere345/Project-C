using UnityEngine;

public class pointsScript : MonoBehaviour
{
    public int currentPoints;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentPoints = 0;
    }
    public void Add1Point(int amount)
    {
        currentPoints += amount;
    }
    public void Add3Point(int amount)
    {
        currentPoints += amount;
    }
    public void Decrease1Point(int amount)
    {
        currentPoints -= amount;
    }
    public void Decrease3Point(int amount)
    {
        currentPoints -= amount;
    }
    public void Respawn(int amount)
    {
        currentPoints -= amount;
    }
    
}
