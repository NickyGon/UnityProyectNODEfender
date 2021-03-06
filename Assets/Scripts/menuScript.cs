using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuScript : MonoBehaviour
{
    public Animator fadeOutAnim;
    public Animator fadeInAnim;

    public void Start()
    {
        Time.timeScale = 1f;
        fadeOutAnim.Play("FadeOut",0);
    }
    public void ButtonStart()
    {
        StartCoroutine(LoadScene());
    }

    public void ButtonQuit()
    {
        Application.Quit();
    }

    IEnumerator LoadScene()
    {
        fadeInAnim.SetBool("end", true);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("LevelSelectScene");

    }
}
