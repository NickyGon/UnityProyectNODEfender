using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class UIScript : MonoBehaviour
{

    public PlayableDirector director;
    [SerializeField] GameObject pause;
    [SerializeField] GameObject gameOver;
    [SerializeField] GameObject ui;
    [SerializeField] GameSuccessScript success;
    public AudioSource music;

    private bool fix = false;
    private bool isActive;
    private bool isChecking=true;
    public Animator anim;

    // Start is called before the first frame update


    // Update is called once per frame

    private void Start()
    {
        director.Play();
        music.Play();
        Time.timeScale = 1f;
        anim.SetBool("GameFinished", false);
    }

    void Update()
    {
       if (!(director.state == PlayState.Playing && !fix))
        {
           isActive = true;
       }
       else
       {
        isActive = false;
       }
       ui.SetActive(isActive);
       activate(isActive);
    }

    void activate(bool isActive1)
    {
       
        if (isActive1 && isChecking)
        {
            anim.SetTrigger("UIOpen");
            isChecking = false;
        }
    }

    public void animateEnd()
    {
        anim.SetBool("GameFinished", true);
        anim.SetBool("Paused", false);
        anim.SetTrigger("UIClose");
        success.makeSucess();
    }

}
