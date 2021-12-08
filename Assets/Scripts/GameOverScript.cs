using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{

    public GameObject gameOverPanel;

    // Start is called before the first frame update
    void Start()
    {
        gameOverPanel.SetActive(false);
    }

    // Update is called once per frame
    public void gameOver()
    {     
            gameOverPanel.SetActive(true);
            Time.timeScale = 0f;
    }

    public void ToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
