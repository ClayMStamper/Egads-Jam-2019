using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Behavior/Flock/Avoidance")]
public class FlockAvoidance : FlockBehavior
{
    public override Vector3 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock) {
        
        //no neighbors means no adjustment
        if (context.Count == 0)
            return Vector3.zero;
        
        //add all points together and average
        int avoidCount = 0;
        Vector3 avoidance = Vector3.zero;
        foreach (Transform item in context) {
            if (Vector3.SqrMagnitude(item.position - agent.transform.position) < flock.squareAvoidanceRadius) {
                avoidCount++;
                avoidance += agent.transform.position - item.position; //offset
            }
        }

        if (avoidCount > 0)
            avoidance /= avoidCount;
        
        return avoidance;

    }
}
