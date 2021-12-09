using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseController : MonoBehaviour
{
    // Start is called before the first frame update

    public Button pause;
    // Update is called once per frame

    private void Awake()
    {
        Button btn = pause.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }


    void TaskOnClick()
    {
        Debug.Log("Pausing");
        GameState currentGameState = GameStateManager.Instance.CurrentGameState;
        GameState newGameState = currentGameState == GameState.Gameplay ? GameState.Paused : GameState.Gameplay;
        GameStateManager.Instance.SetState(newGameState);
    }
}
