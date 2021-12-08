using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;


public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    public Animator anim;
    public Animator anim2;
    public bool isPaused=false;

    void Start()
    {

    }


    // Start is called before the first frame update


    public void Pause()
    {
        anim.SetTrigger("PauseOpen");
        anim.SetTrigger("UIClose");

        anim2.SetTrigger("");
        Time.timeScale = 0f;

    }


    public void Resume()
    {

        Time.timeScale = 1f;

    }
   
    public void Home(int SceneID)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneID);
    }



}
