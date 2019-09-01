using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [Range(0, 100)]
    public float rotSpeed;
    
    void Update()
    {
        
        if (Input.GetKey(KeyCode.W))
            transform.Translate(Vector3.forward * Time.deltaTime * 3);
        
        if (Input.GetKey(KeyCode.A))
            transform.Rotate(Vector3.up, Time.deltaTime * -rotSpeed);
        if (Input.GetKey(KeyCode.D))
            transform.Rotate(Vector3.up, Time.deltaTime * rotSpeed);
        
    }
}
