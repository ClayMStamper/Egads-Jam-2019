using System.Collections;
using System.Collections.Generic;
using System.Security.Policy;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class FlockAgent : MonoBehaviour
{

    public Transform target { get; set; }
    
    public Collider collider { get; private set; }
    public FlockBehavior circle, grave;

    private void Start() {
        target = GraveManager.instance.GetTarget();
        collider = GetComponent<Collider>();
    }

    public void Move(Vector3 velocity) {

        transform.forward = velocity;
        transform.position += velocity * Time.deltaTime;

    }

    public void Seperate() {

        List<FlockBehavior> behaviors = new List<FlockBehavior>() {circle, grave};
        StartCoroutine(GotoGrave());

    }

    private IEnumerator GotoGrave() {

        while (true) {

            //loop through new list of behaviors defined in seperate

            yield return null;

        }
        
    }
    
    
}
