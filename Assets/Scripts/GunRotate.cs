using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class GunRotate : MonoBehaviour
{
    public PlayableDirector director;
    [SerializeField] PauseMenu pause;
    [SerializeField] GameOverScript gameOver;
    [SerializeField] GameSuccessScript gameSucess;
    private bool fix = false;

    public float limitRotate;
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {

        if (!(director.state == PlayState.Playing && !fix) && !pause.paused && !gameOver.isGameOver && !gameSucess.isSucess)
        {
            Vector3 mousepos = Input.mousePosition;
            Vector3 gunposition = Camera.main.WorldToScreenPoint(transform.position);
            mousepos.x = mousepos.x - gunposition.x;
            mousepos.y = mousepos.y - gunposition.y;
            float gunangle = Mathf.Atan2(mousepos.x, mousepos.y) * Mathf.Rad2Deg;
            float gunangleOf = -gunangle + 90;
            if (gunangleOf < limitRotate && gunangleOf > -limitRotate)
            {
                transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, gunangleOf));
            }
        } 
        
    }
}
