using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    
    public Vector3 gravity = new Vector3(0,-10,0);
    public Vector3 jumpPower = new Vector3(0,10,0);
    public float moveSpeed = 5;

    private Vector3 velocity;
    private Rigidbody rb;
    
    public delegate void OnJumpedCallback();
    public OnJumpedCallback OnJumped;

    private void Start() {
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.layer == 9) {
            if (transform.position.y > other.transform.position.y) {
                velocity = jumpPower;
                OnJumped.Invoke();
            }

        }
    }

    void Update() {

        velocity = Vector3.Lerp(velocity, gravity, Time.deltaTime);

        
        if (Input.GetKey(KeyCode.LeftArrow))
            velocity.x = -moveSpeed;
        
        if (Input.GetKey(KeyCode.RightArrow))
            velocity.x = moveSpeed;
        

        rb.velocity = velocity;
        
        
        
    }
}
