using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

[CreateAssetMenu(menuName = "Behavior/Goto")]
public class GoTowards : FlockBehavior {

    private Transform flockAgentTarget;
    

    public override Vector3 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock) {
        
        Vector3 targetDir = (agent.target.position - agent.transform.position).normalized;
        
        return targetDir;

    }
    
    
    
    
}
