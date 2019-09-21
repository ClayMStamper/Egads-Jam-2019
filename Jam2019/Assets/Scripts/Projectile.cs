using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{
    public GameObject projectileObject;
    
    public float speed = .2f;
    public float lifeInSeconds = 5f;

    private Collider col;
    private Rigidbody rb;

    private void Start ()
    {
        col = GetComponent<Collider>();
        col.isTrigger = false;
        
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = false;
        rb.useGravity = false;
        
        StartCoroutine( nameof(Lifetime) );
    }
    
    private void Update ()
    {
        transform.Translate(Vector3.forward * speed, Space.Self);
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log(this + " Collision with " + other);
        
        if (other is null) return;
        
        Destroy(gameObject);
        
        other.gameObject.SendMessage("TakeDamage", 0,  SendMessageOptions.RequireReceiver);
    }

    private IEnumerator Lifetime ()
    {
        yield return new WaitForSeconds( lifeInSeconds );
        Destroy( gameObject );
    }
}
