using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LevelSelection : MonoBehaviour
{

    public Button[] lvlButtons;
    // Start is called before the first frame update
    void Start()
    {
        int levelReached = PlayerPrefs.GetInt("levelAt",2);

        for (int i = 0; i < lvlButtons.Length; i++)
        {
            if (i + 2 > levelReached)
            {
                lvlButtons[i].interactable = false;
            }    
        }
    }

    public void goToLevel(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
