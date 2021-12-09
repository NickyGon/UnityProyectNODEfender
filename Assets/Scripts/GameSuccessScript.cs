using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSuccessScript : MonoBehaviour
{
    // Start is called before the first frame update

    public bool isSucess = false;
    public int nextSceneLoad;
    public AudioSource music;
    public bool levelToCutscene = true;

   
    private void Start()
    {
       nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
    }

    public void NextLevel()
    {

        isSucess = false;
        Time.timeScale = 1f;
        if (SceneManager.GetActiveScene().buildIndex < 8)
        {
            SceneManager.LoadScene(nextSceneLoad);

            if (nextSceneLoad-1 > PlayerPrefs.GetInt("levelAt"))
            {
                PlayerPrefs.SetInt("levelAt", nextSceneLoad-1);
            } 
           
        }
        
        

    }

    public void makeSucess()
    {
        PlayerPrefs.SetInt("levelReached",nextSceneLoad-1);
        isSucess = true;
        Time.timeScale = 0f;
        music.Stop();
    }
   

    public void Retry()
    {
        Time.timeScale = 1f;
        isSucess = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }


    public void Home()
    {
        isSucess = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

}
