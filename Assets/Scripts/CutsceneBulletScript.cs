using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CutsceneBulletScript : MonoBehaviour
{
    // Start is called before the first frame update
    public PlayableDirector director;
    public bool goOff;
    private bool fix = false;
    // Start is called before the first frame update
    void Start()
    {
        goOff = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!(director.state == PlayState.Playing && !fix))
        {
            goOff = true;
        }
        else
        {
            goOff = false;
        }
        sendOff(goOff);

    }

    void sendOff(bool yes)
    {
        if (yes)
        {
            Destroy(gameObject);
        }
    }
}
