using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class FlockAgent : MonoBehaviour
{

    private const string GRAVE_TAG = "grave";
    
    public Transform target { get; set; }
    
    public Collider collider { get; private set; }
    public  List<FlockBehavior> Behaviors;
    public  int [] weights;

    private void Start() {
        collider = GetComponent<Collider>();
    }

    public void Move(Vector3 velocity) {

        transform.forward = velocity;
        transform.position += velocity * Time.deltaTime;

    }

    public void Separate() {
        
        target = GraveManager.instance.GetTarget();
        Debug.Log(transform.name + " has left the flock");
        StartCoroutine(GotoGrave());
    }

    private IEnumerator GotoGrave() {

        while (true)    
        {
            
            //setup move
            Vector3 move = Vector3.zero;
            
            int i = 0;
            foreach (FlockBehavior behavior in Behaviors)
            {
                Vector3 partialMove = behavior.CalculateMove(this, null, null) * weights[i];
                
                if (partialMove != Vector3.zero)
                {

                    if (partialMove.sqrMagnitude > weights[i] * weights[i])
                    {
                        partialMove.Normalize();
                        partialMove *= weights[i];
                    }

                    Move(partialMove);
                }
                i++;
            }

            yield return null;

        }
        
    }
    
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag(GRAVE_TAG)) {
            FindObjectOfType<GameRunner>().LoseLife();
            GetComponent<GhostHealth>().TakeDamage(100);
        }
    }
    
}
