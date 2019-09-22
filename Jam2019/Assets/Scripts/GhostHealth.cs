using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostHealth : MonoBehaviour, ITakeDamage {
    
    [SerializeField]
    private float health = 100;
    [SerializeField] 
    private float destroyAfter;
        
    
    public void TakeDamage(float damage) {

        health -= damage;
        
        if (health <= 0)
            Explode();
        
        
    }

    private void Explode() {
        GetComponent<SpawnEffect>().enabled = true;
        Destroy(gameObject, destroyAfter);
        
    }
    
}
