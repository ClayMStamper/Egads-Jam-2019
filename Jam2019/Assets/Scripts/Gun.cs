using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.MagicLeap;

<<<<<<< Updated upstream
public class Gun : MonoBehaviour {
=======
public class Gun : MonoBehaviour
{
    public Transform bullet;
    public Transform spawn;

    // Start is called before the first frame update
    void Start()
    {

    }

    
>>>>>>> Stashed changes

    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform axis;
    [SerializeField] private float bulletLifetime = 2;

    private void Start() {
        MLInput.OnTriggerDown += OnTriggerDown;
    }

<<<<<<< Updated upstream
    private void OnTriggerDown(byte controllerId, float value) {
        Destroy(Instantiate(bullet, axis.position, axis.rotation), bulletLifetime);
=======
    void Update()
    {

>>>>>>> Stashed changes
    }

}