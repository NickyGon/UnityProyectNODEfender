using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    Slider healthBar;
    antenaScript antena;

    // Start is called before the first frame update
    void Start()
    {
        antena= GameObject.FindGameObjectWithTag("Antena").GetComponent<antenaScript>();
        healthBar = GetComponent<Slider>();
        healthBar.maxValue = antena.health;
        healthBar.value = antena.health;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetHealth(int hp)
    {
        healthBar.value = hp;
    }
}
