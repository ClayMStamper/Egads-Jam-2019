using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Behavior/FlockManager/Alignment")]
public class FlockAlignment : FlockBehavior
{
    public override Vector3 CalculateMove(FlockAgent agent, List<Transform> context, FlockManager flockManager) {
        
        //no neighbors means maintain heading
        if (context.Count == 0)
            return agent.transform.forward;
        
        //add all points together and average
        Vector3 alignmentMove = Vector3.zero;
        foreach (Transform item in context) {
            alignmentMove += item.transform.forward;
        }
        alignmentMove /= context.Count;
        
        return alignmentMove;

    }
}
