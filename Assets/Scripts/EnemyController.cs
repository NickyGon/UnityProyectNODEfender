using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour

{
    Rigidbody2D rb;
    GameObject target;
    float moveSpeed;
    Vector2 directionToTarget;
    private Animator anim;
    
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("antena");
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        moveSpeed = Random.Range(3f, 8f);

    }

    // Update is called once per frame
    void Update()
    {
        MoveEnemy();
    }

    void MoveEnemy()
    {
        if (target != null)
        {
            directionToTarget = (target.transform.position - transform.position).normalized;
            rb.velocity = new Vector2(directionToTarget.x * moveSpeed, directionToTarget.y * moveSpeed);

        } else
        {
            rb.velocity = Vector2.zero;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Antena")
        {
            antenaScript antena = other.GetComponent<antenaScript>();
            if (antena != null)
            {
                antena.takeDamage((int)Random.Range(antena.health * 0.05f, antena.health * 0.1f));
                takeDamage();
                target = null;
            }
           
            
        }
    }

    public void takeDamage()
    {
        anim.SetTrigger("Death");
    }
}
