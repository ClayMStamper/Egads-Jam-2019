using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroRunner : MonoBehaviour
{
    private bool running = false;
    private float timeElapsed = 0.0f;

    public float IntroTime = 3.0f;
    public float FadeOutTime = 1.0f;

    private bool fadeOut = false;

    public Image splashImage; 
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void RunIntro()
    {
        running = true;
        timeElapsed = 0.0f;
        splashImage.gameObject.SetActive(true);
        splashImage.color = Color.white;
    }

    public bool IsRunning()
    {
        return running;
    }

    // Update is called once per frame
    void Update()
    {
        if (!running)
        {
            return;
        }

        timeElapsed += Time.deltaTime;
        if (!fadeOut && timeElapsed > IntroTime)
        {
            fadeOut = true;
            timeElapsed = 0.0f;
        }

        if (fadeOut){
            if (timeElapsed > FadeOutTime)
            {
                Debug.Log("Faded out");
                fadeOut = false;
                running = false;
                splashImage.gameObject.SetActive(false);
            }

            splashImage.color = new Color(splashImage.color.r, splashImage.color.g, splashImage.color.b,
                1.0f - (timeElapsed / FadeOutTime));
        }
    }
}
