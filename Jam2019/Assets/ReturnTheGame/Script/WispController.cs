using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WispController : MonoBehaviour {

    private const string GRAVE_TAG = "grave";
    
    private Camera _camera;
    public GameObject WispTarget;
    public GameObject WispStart;
    private Vector3 WispMoveVelocity;
    public float MaxWispVelocity = 1.0f;
    public float WispAcceleration = 0.15f;
    
        
    // Start is called before the first frame update
    void Start()
    {
        ResetStart();
        _camera = Camera.main;
    }

    void Awake()
    {
        ResetStart();
        _camera = Camera.main;
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
        
        var lookPos = _camera.transform.position - transform.position;
        lookPos.y = 0;
        var rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = rotation;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag(GRAVE_TAG)) {
            FindObjectOfType<GameRunner>().LoseLife();
        }
    }
}
