using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.MagicLeap;

public class Gun : MonoBehaviour
{
    public Transform bullet;
    public Transform spawn;
    [SerializeField] private Transform axis;
    [SerializeField] private float bulletLifetime = 2;

    private void Start() {
        MLInput.OnTriggerDown += OnTriggerDown;
    }

    private void OnTriggerDown(byte controllerId, float value) {
        Destroy(Instantiate(bullet, axis.position, axis.rotation), bulletLifetime);
    }

}