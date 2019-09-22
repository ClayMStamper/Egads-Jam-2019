using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Flock : MonoBehaviour {

    public FlockAgent agentPrefab;
    List<FlockAgent> agents = new List<FlockAgent>();
    public FlockBehavior behavior;

    private const float DENSITY = 0.08f;
    [Range(10, 500)] public int startingCount = 250;
    [Range(.01f, 100f)] public float speed = 10f;
    [Range(.01f, 100f)] public float maxSpeed = 5f;
    [Range(1f, 10f)] public float neighborRadius = 1.5f;
    [Range(0f, 1f)] public float avoidanceRadiusMultiplier = 0.5f;

    private float squareMaxSpeed;
    private float squareNeightborRadius;
    public float squareAvoidanceRadius { get; private set; }

    private float timePerSeperation = 5f;
    private float elapsed;
    

    private void Start() {
        
        squareMaxSpeed = maxSpeed * maxSpeed;
        squareNeightborRadius = neighborRadius * neighborRadius;
        squareAvoidanceRadius = squareNeightborRadius * avoidanceRadiusMultiplier * avoidanceRadiusMultiplier;

        //instantiate flock
        for (int i = 0; i < startingCount; i++) {
            
            FlockAgent newAgent = Instantiate(
                agentPrefab,
                Random.insideUnitSphere * startingCount * DENSITY,
                Quaternion.Euler(Vector3.forward * Random.Range(0f, 360f)),
                transform);

            newAgent.name = "Droid " + i;
            agents.Add(newAgent);
        }
    }

    private void Update() {

        elapsed += Time.deltaTime;
        
        foreach (FlockAgent agent in agents) {
                       
            List<Transform> context = GetNearbyObjects(agent);
            Vector3 move = behavior.CalculateMove(agent, context, this);
            move *= speed;
            if (move.sqrMagnitude > squareMaxSpeed) { //reset ot max speed when exceeding
                move = move.normalized * maxSpeed;
            }
            agent.Move(move);
        }
        
        //seperation
        if (elapsed > timePerSeperation)
        {
            FlockAgent agent = agents.Random();
            agent.Separate();
            agents.Remove(agent);
            elapsed = 0f;
        }
        
    }

    private List<Transform> GetNearbyObjects(FlockAgent agent) {
        
        List<Transform> context = new List<Transform>();
        Collider[] contextColliders = Physics.OverlapSphere(agent.transform.position, neighborRadius);
        foreach (Collider c in contextColliders) {
            if (c == agent.collider) //current collider
                continue;
            context.Add(c.transform);
        }

        return context;

    }

    
}