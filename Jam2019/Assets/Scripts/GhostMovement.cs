using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMovement : MonoBehaviour {

    public List<GhostBehavior> behaviors;
    [SerializeField] private float speed = 1;
   
    public void Move() {

      //  Vector3 targetPos = behaviors[1].GetDesiredDestination(transform);
        //transform.position = Vector3.MoveTowards(transform.position, targetPos, Time.deltaTime * speed);

    }
   
}
