using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class antenaScript : MonoBehaviour
{

    public GameOverScript gameOverCommander;
    public int health;
    public Animator anim;
    public AudioSource audio;
    int currenthealth;
    public HealthBar healthBar;

    // Start is called before the first frame update
    public void takeDamage(int damage)
    {
       currenthealth -= damage;
       healthBar.SetHealth(currenthealth); 
        if (currenthealth <= 0)
        {
            audio.Stop();
            anim.SetBool("GameOver", true);
            anim.SetBool("Paused", false);
            anim.SetTrigger("UIClose");
            gameOverCommander.gameOver();
        }
    }
    

    void Start()
    {
        anim.SetBool("GameOver", false);
        currenthealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
