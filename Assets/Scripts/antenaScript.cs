using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class antenaScript : MonoBehaviour
{

    public GameOverScript gameOverCommander;
    public int health;

    int currenthealth;
    public HealthBar healthBar;

    // Start is called before the first frame update
    public void takeDamage(int damage)
    {
       currenthealth -= damage;
       healthBar.SetHealth(currenthealth); 
        if (currenthealth <= 0)
        {
            gameOverCommander.gameOver();
        }
    }
    

    void Start()
    {
        currenthealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
