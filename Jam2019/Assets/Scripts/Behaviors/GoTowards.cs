using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Behavior/Goto")]
public class GoTowards : FlockBehavior {

    private Transform target;
    

    public override Vector3 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock) {

        if (!target) 
            GetTarget();

        Vector3 targetDir = (target.position - agent.transform.position).normalized;

        return targetDir;

    }

    private void GetTarget() {
        target = GraveManager.instance.GetTarget();
    }
    
}
