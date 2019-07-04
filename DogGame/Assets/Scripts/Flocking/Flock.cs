using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Flock : MonoBehaviour
{

#region setup

    public FlockAgent agentprefab;
    List<FlockAgent> agents = new List<FlockAgent>();
    public FlockBehaviour behaviour;

    [Range(3, 50)]
    public int startingCount = 3;
    const float AgentDensity = 1f;

    [Range(1f, 100f)]
    public float driveFactor = 10f;
    [Range(1f, 100f)]
    public float maxSpeed = 5f;
    [Range(1f, 50f)]
    public float neighborRadius = 10f;
    [Range(0f, 1f)]
    public float avoidanceRadiusMultiplier = 0.5f;

    float squareMaxSpeed;
    float squareNeighborRadius;
    float squareAvoidanceRadius;
    public float SquareAvoidanceRadius { get { return squareAvoidanceRadius; } }

#endregion

    // Start is called before the first frame update
    void Start()
    {
        squareMaxSpeed = maxSpeed * maxSpeed;
        squareNeighborRadius = neighborRadius * neighborRadius;
        squareAvoidanceRadius = squareNeighborRadius * avoidanceRadiusMultiplier * avoidanceRadiusMultiplier;

        for(int i = 0; i < startingCount; i++)
        {
            Vector3 spawnLocation = UnityEngine.Random.insideUnitSphere * startingCount * AgentDensity;
            spawnLocation.y = 1;

            FlockAgent newAgent = Instantiate(
                agentprefab,
                spawnLocation,
                Quaternion.Euler(Vector3.up * UnityEngine.Random.Range(0, 360)),
                this.transform
                );
            newAgent.name = "Agent " + i;
            agents.Add(newAgent);
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach(FlockAgent agent in agents)
        {
            List<Transform> context = GetNearbyObjects(agent);
            Vector3 move = behaviour.CalculateMove(agent, context, this, Vector3.zero);
            move *= driveFactor;
            if(move.sqrMagnitude > squareMaxSpeed)
            {
                move = move.normalized * maxSpeed;
            }
            agent.Move(move);
        }
    }

    private List<Transform> GetNearbyObjects(FlockAgent agent)
    {
        return Physics.OverlapSphere(agent.transform.position, neighborRadius)
            .Where(c => c != agent.AgentCollider && c.tag == "Sheep")
            .Select(c => c.transform).ToList();
    }
}
