using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Droid Behavior/Float")]
public class FloatBehavior : GhostBehavior {

    public float range = 3;
    private Vector3 target, traveled;
    
    public override Vector3 GetDesiredDestination(Transform transform) {

        if (target == Vector3.zero)
            target = Random.insideUnitSphere * range;
        
        Vector3 step = Vector3.MoveTowards(transform.position, target, Time.deltaTime);
        traveled += step;
        
        return new Vector3();
    }
}
