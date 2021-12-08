using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CanvasScript : MonoBehaviour
{  
    
    public CanvasGroup group;
    public bool isFading = false;
    private bool isShowing = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    public void Toggle(bool toggled)
    { 
        if (toggled)
        {
            
            StartCoroutine(FadeFromTo(0f, 1f, true));
        }
        else
        {
            StartCoroutine(FadeFromTo(1f, 0f, false));
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator FadeFromTo(float from, float to,bool showing)
    {
        isFading = true;
        var curve = new AnimationCurve(new Keyframe[] { new Keyframe (0f,from),new Keyframe(1f,to)});
        float time = 0f;
        while (time < 1f)
        {
            group.alpha = curve.Evaluate(time);
            time +=Time.deltaTime;

            yield return null;
        }
        group.alpha = curve.Evaluate(1f);
        isFading = false;
        isShowing = showing;
       

    }

}
