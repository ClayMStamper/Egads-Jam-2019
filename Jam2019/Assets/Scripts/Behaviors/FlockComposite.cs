using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Behavior/Flock/Composite")]
public class FlockComposite : FlockBehavior {

    public FlockBehavior[] behaviors;
    public float[] weights;

    public override Vector3 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock) {
        
        //setup move
        Vector3 move = Vector3.zero;
        
        //iterate through behaviors
        for (int i = 0; i < behaviors.Length; i++) {
            
            Vector3 partialMove = behaviors[i].CalculateMove(agent, context, flock) * weights[i];
            
            if (partialMove != Vector3.zero) {
                
                if (partialMove.sqrMagnitude > weights[i] * weights[i]) {
                    partialMove.Normalize();
                    partialMove *= weights[i];
                }

                move += partialMove;
            }
        }

        return move;

    }
}
