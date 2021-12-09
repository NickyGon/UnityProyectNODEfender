using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;

public class CutsceneScript : MonoBehaviour
{
    public Animator fadeInAnim;
    public Animator buttonsAnim;
    public PlayableDirector director;
    private bool fix = false;
    private bool isPlaying = true;

    private void Start()
    {
        Time.timeScale = 1f;
        director.Play();
    }
    void Update()
    {
        if (isPlaying)
        {
            StartCoroutine(waitForEnd());
        }
        else
        {
            StartCoroutine(LoadScene());
        }
    }

    // Start is called before the first frame update
    public void ButtonSkip()
    {
        StartCoroutine(LoadScene());
    }
    
    IEnumerator waitForEnd()
    {

        yield return new WaitUntil(() =>director.state==PlayState.Paused && !fix);
        isPlaying = false;
    }

    public void ButtonMenu()
    {
        SceneManager.LoadScene(0);
    }

    IEnumerator LoadScene()
    {
            buttonsAnim.SetBool("end", true);
            fadeInAnim.SetBool("EndOfCutscene", true);
            yield return new WaitForSeconds(1f);
        if (SceneManager.GetActiveScene().buildIndex + 1 < 8)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        } else {
            SceneManager.LoadScene(0);
        }
            
    }
}
