using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    public bool isGameOver = false;

    // Update is called once per frame
    public void gameOver()
    {
        isGameOver = true;
        Time.timeScale = 0f;
    }

    public void ToMenu()
    {
        isGameOver = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void Retry()
    {
        isGameOver = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
