using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{

    public GameObject bullet;
    public Transform start;

    // Update is called once per frame
    void Update()
    {
        Vector2 gunpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (gunpos.x < transform.position.x)
        {
            transform.eulerAngles = new Vector2(transform.rotation.x, 180f);
        } else
        {
            transform.eulerAngles = new Vector2(transform.rotation.x, 0f);
        }
        
        if (Input.GetMouseButtonDown(0))
        {
            shooting();
        }
    }

    void shooting()
    {
        GameObject shoot = Instantiate(bullet, start.transform.position, start.transform.rotation);
        Destroy(shoot,.5f);
    }
}
