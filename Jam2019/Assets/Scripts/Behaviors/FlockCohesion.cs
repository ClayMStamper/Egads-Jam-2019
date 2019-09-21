using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Behavior/Flock/Cohesion")]
public class FlockCohesion : FlockBehavior {
    
    private Vector3 velocity;

    public float agentSmoothTime = 0.5f;//how quickly movement smooths
    
    public override Vector3 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock) {
        
        //no neighbors means no adjustment
        if (context.Count == 0)
            return Vector3.zero;
        
        //add all points together and average
        Vector3 cohesionMove = Vector3.zero;
        foreach (Transform item in context) {
            cohesionMove += item.position;
        }

        cohesionMove /= context.Count;
        
        //create offset froma gent position
        cohesionMove -= agent.transform.position;
        
        //smooth 
        cohesionMove = Vector3.SmoothDamp(agent.transform.forward, cohesionMove, ref velocity, agentSmoothTime);
        
        return cohesionMove;

    }
}
