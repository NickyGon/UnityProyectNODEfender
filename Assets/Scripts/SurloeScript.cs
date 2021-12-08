using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class SurloeScript : MonoBehaviour

{
    //Para asegurarse que no repita por frames
    private bool fix = false;

    //Animadores del sprite
    public Animator anim;

    [SerializeField] GameObject pause;
    public LaserPowerUp laser;

    //Del timeline de animacion
    public PlayableDirector director;
    public PowerUpButton buttonPowerUp;

    //Para las balas (Surloe es un personaje de pocas acciones (dispara y se anima, NUNCA se mueve), por lo que aquí puedo utilizar muchos comandos)
    public GameObject bullet;
    public Transform start;
    public float reloadCountdown=2.5f;
    bool isShot;


    //Indicar que la cutscene esta pasando, y que SURLOE no haga nada durante la cutscene
    bool cutscene=true;


    // Start is called before the first frame update
    void Start()
    {
        isShot = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (director.state == PlayState.Playing && !fix)
        {
            cutscene = true;
        }
        else
        { 
            cutscene = false;
        }
        changeCutsceneAnim(cutscene);
        enableshoot(cutscene);
        
    
       
    }


    void changeCutsceneAnim(bool isCutscene)
    {
        if (isCutscene)
        { 
            anim.SetBool("Cutscene", true);
        }
        else
        {
            anim.SetBool("Cutscene", false);
        }
    }

    void enableshoot(bool isCutscene)
    {
        if (!isCutscene && !pause.activeSelf && !laser.shootIt)
        {
            Vector3 gunpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                
              if (Input.GetMouseButtonDown(0) && !isShot)
              {
                    StartCoroutine(shooting());  
              }    
        }
    }

    IEnumerator shooting()
    {
        isShot = true;
        GameObject shoot = Instantiate(bullet, start.position, start.rotation);
        Bullet bullet1 = shoot.GetComponent<Bullet>();
        bullet1.buttonPower = buttonPowerUp;
        yield return new WaitUntil(()=>shoot==null);
        isShot = false;
    }

}
