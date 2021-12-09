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
    public AudioSource bang;

    public bool shootSetter=true;
    public LaserPowerUp laser;

    //Del timeline de animacion
    public PlayableDirector director;
    public PowerUpButton buttonPowerUp;

    [SerializeField] PauseMenu pause;
    [SerializeField] GameOverScript gameOver;
    [SerializeField] GameSuccessScript gameSucess;


    //Para las balas (Surloe es un personaje de pocas acciones (dispara y se anima, NUNCA se mueve), por lo que aquí puedo utilizar muchos comandos)
    public GameObject bullet;
    public Transform start;
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
        if (!isCutscene)
        {
            Vector3 gunpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
              

              if (Input.GetMouseButtonDown(0) && !isShot && !laser.shootIt && !pause.paused && !gameOver.isGameOver && !gameSucess.isSucess)
              {
                    StartCoroutine(shootingWithDelay());  
              }    
        }
    }

    IEnumerator shootingWithDelay()
    {
        bang.Play();
        isShot = true;
        GameObject shoot = Instantiate(bullet, start.position, start.rotation);
        Bullet bullet1 = shoot.GetComponent<Bullet>();
        bullet1.buttonPower = buttonPowerUp;
        if (shootSetter)
        {
            yield return new WaitUntil(() => shoot == null);
        } else
        {
            yield return null;
        }
        isShot = false;
    }

}
