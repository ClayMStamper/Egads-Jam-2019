using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class FlockAgent : MonoBehaviour {
    
    public Collider collider { get; private set; }

    private void Start() {
        collider = GetComponent<Collider>();
    }

    public void Move(Vector3 velocity) {

        transform.forward = velocity;
        transform.position += velocity * Time.deltaTime;

    }
    
}
