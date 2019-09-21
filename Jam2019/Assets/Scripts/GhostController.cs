using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostController : MonoBehaviour {

    public GhostHealth health;
    public GhostMovement move;

    private void Update() {
        move.Move();
    }
    
}
