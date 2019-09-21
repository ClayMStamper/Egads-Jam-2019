using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

[CreateAssetMenu(menuName = "Behavior/FlockPlayerChase")]
public class FlockPlayerChase : FlockBehavior
{

    [SerializeField] int exp =  2;
    [SerializeField] int numBase = 2;
    [SerializeField] private float lowerLimit = -5000000;
    [SerializeField] private float upperLimit = 5000000;
    
    public override Vector3 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
    {

        Vector3 targetDistance = (Camera.main.transform.position - agent.transform.position);
        
        Vector3 targetMove = targetDistance.normalized;
        
        targetMove *= Mathf.Clamp(Mathf.Pow(numBase, targetDistance.magnitude * exp), lowerLimit, upperLimit);
        
        return targetMove;

    }
    
    
    
    
}
