using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class playerHealth : MonoBehaviour
{
    public int maxHealth = 5;
    private int currentHealth;
    public int CurrentHealth => currentHealth;
    public bool Player1;
    public bool Player2;
    //each player is assigned a value to determine who dies.
    private Vector3 respawnPoint;
    void Start()
    {
        currentHealth = maxHealth; //Players start at 5 health, though it can go higher when in-game.
        respawnPoint = transform.position;
    }
    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0f) //Triggers when health is 0.
        {
            if (Player2)
            {
                transform.position = new Vector3(0.0f, 10.0f, 0.0f);
                currentHealth = maxHealth;
                GetComponent<pointsScript>().Decrease1Point(10);
                //Player 2 dies and respawns at starting position with max health (5)
            }
            if (Player1)
            {
                transform.position = new Vector3(0.0f, 10.0f, 0.0f);
                currentHealth = maxHealth;
                GetComponent<pointsScript>().Decrease1Point(10);
                //Player 1 dies and respawns at starting position with max health (5)
            }
        }
    }
    public void FixedUpdate()
    {
        if (transform.position.y < -50f) //Used for when players fall off the map.
        {
                transform.position = new Vector3(0.0f, 10.0f, 0.0f);
                currentHealth = maxHealth;
                GetComponent<pointsScript>().Decrease1Point(10);
        }
    } 
    public void Heal(int amount)
    {
        currentHealth += amount;
    }
    public void DecreaseHealth(int amount)
    {
        TakeDamage(amount);
    }
}
//Source Used: https://www.youtube.com/watch?v=Mic9ERhr0HA&t=103s
