using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.MagicLeap;

public class Gun : MonoBehaviour {

    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform axis;

    private void Start() {
        MLInput.OnTriggerDown += OnTriggerDown;
    }

    private void OnTriggerDown(byte controllerId, float value) {
        Debug.Break();
    }
    
    void Update()
    {
        
    }
}
