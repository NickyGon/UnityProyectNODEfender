using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public Sprite oneSprite;
    public bool paused=false;
    public Sprite multiSprite;
    public Button switcher;
    public Animator anim;
    public AudioSource music;
    [SerializeField] SurloeScript surloeMode;


    public void boolPause()
    {
        anim.SetBool("Paused", true);
    }
    public void Pause()
    {

        paused = true;
        Time.timeScale = 0f;
        music.Pause();
    }

    public void switchDelay()
    { 
        surloeMode.shootSetter = !surloeMode.shootSetter;
        if (surloeMode.shootSetter)
        {
            switcher.image.sprite = oneSprite;
        } else
        {
            switcher.image.sprite = multiSprite;
        }
    }

    public void Resume()
    {
        paused = false;
        Time.timeScale = 1f;
        music.Play();
    }


    public void Home(int SceneID)
    {
        music.Stop();
        paused = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneID);
    }

    


}
