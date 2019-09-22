using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class GameRunner : MonoBehaviour {
    
    [SerializeField] private FlockManager _flockManager;

    private bool running;
    private float timeElapsed;

    [SerializeField]
    private int lives = 10;
    
    public void RunGame()
    {
        _flockManager.Setup();
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

        //_flockManager.Run();

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
