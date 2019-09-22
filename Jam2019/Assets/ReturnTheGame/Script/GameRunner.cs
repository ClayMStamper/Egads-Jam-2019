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
        if (!_flockManager)
        {
            _flockManager.Setup();
        }

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

        if (_flockManager != null)
        {
            _flockManager.Run();
        }

    }

    public void LoseLife() {
        
        lives -= 1;
        if (lives <= 0) {
            running = false;
        }
        
        
    }
}
