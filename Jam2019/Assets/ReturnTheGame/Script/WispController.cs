using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WispController : MonoBehaviour
{

    public GameObject WispTarget;
    public GameObject WispStart;
    private Vector3 WispMoveVelocity;
    public float MaxWispVelocity = 1.0f;
    public float WispAcceleration = 0.15f;
        
    // Start is called before the first frame update
    void Start()
    {
        ResetStart();
    }

    void ResetStart()
    {
        transform.position = WispStart.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // move towards the wisp target    
        Vector3 direction = Vector3.Normalize(WispTarget.transform.position - transform.position);
        WispMoveVelocity += WispAcceleration * direction * Time.deltaTime;
        if (WispMoveVelocity.magnitude > MaxWispVelocity)
        {
            WispMoveVelocity = Vector3.Normalize(WispMoveVelocity) * MaxWispVelocity;
        }
        transform.position = transform.position + WispMoveVelocity;
    }
}
