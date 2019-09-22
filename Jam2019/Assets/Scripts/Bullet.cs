using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Bullet : MonoBehaviour {
    
    private Collider collider;
        
    private void OnTriggerEnter(Collider other) {
        if (other.GetComponent<GhostHealth>()) {
            other.GetComponent<GhostHealth>().TakeDamage(100);
        }
    }
    
}
