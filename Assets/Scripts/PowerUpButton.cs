using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpButton : MonoBehaviour
{
    // Start is called before the first frame update
    public int charge;
    Button powerUpButton;
    public LaserPowerUp laser;

    // Update is called once per frame

    void Start()
    {
        powerUpButton = GetComponent<Button>();
        charge = 0;
    }
    void Update()
    {
        if (charge >= 100)
        {
            powerUpButton.interactable = true;
            
        } else{
            powerUpButton.interactable = false;
        }
    }

    public void ShootLaser()
    {
        laser.shootIt = true;
        charge = 0;
    }

    public void scoreUp(int amount)
    {
        charge += amount;
    }

   
}
