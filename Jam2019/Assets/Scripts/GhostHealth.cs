using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostHealth : MonoBehaviour, ITakeDamage {
    
    [SerializeField]
    private float health = 100;
    [SerializeField] 
    private GameObject explosionPrefab;
    
    public void TakeDamage(float damage) {

        health -= damage;
        
        if (health <= 0)
            Explode();
        
        
    }

    private void Explode() {
        Destroy(Instantiate(explosionPrefab, transform.position, transform.rotation), 3f);
        Destroy(gameObject);
        
    }
    
}
