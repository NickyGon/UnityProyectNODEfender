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
    public AudioSource laserShot;
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
        laserShot.Play();
        laser.shootIt = true;
        charge = 0;
    }

    public void scoreUp(int amount)
    {
        StartCoroutine(scoreRegulator(amount));

    }
   
    IEnumerator scoreRegulator(int amount)
    {
        Debug.Log("charge: " + charge + "amount: " + amount);
        charge += amount;
        yield return new WaitForSeconds(1f);

    }
}
