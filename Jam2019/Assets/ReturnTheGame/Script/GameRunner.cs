using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRunner : MonoBehaviour {
    
    [SerializeField] private Flock flock;

    private bool running;
    private float timeElapsed;

    [SerializeField]
    private int lives = 10;
    
    public void RunGame()
    {
        running = true;
        timeElapsed = 0.0f;
    }

    public bool IsRunning()
    {
        return running;
    }

    // Update is called once per frame
    void Update()
    {
        if (!running)
            return;

        timeElapsed += Time.deltaTime;

        flock.Run();

    }

    public void Play() {
        running = true;
    }

    public void LoseLife() {
        
        lives -= 1;
        if (lives <= 0) {
            running = false;
        }
        
        
    }
}
