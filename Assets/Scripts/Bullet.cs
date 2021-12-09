using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
    public float firespeed;
    public Rigidbody2D rb;
    public PowerUpButton buttonPower;


    // Start is called before the first frame update

    void Start()
    {
        rb.velocity = transform.right * firespeed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        EnemyController enemy = hitInfo.gameObject.GetComponent<EnemyController>();
        if (enemy != null)
        {
            buttonPower.scoreUp((int)Random.Range(4f,7f));
            enemy.takeDamage();

        }
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        

    }
}
