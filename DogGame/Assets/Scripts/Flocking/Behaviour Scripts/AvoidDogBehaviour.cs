using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behaviour/Dog Avoidance")]
public class AvoidDogBehaviour : FlockBehaviour
{
    public float fleeDistance = 20;
    public override Vector3 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock, Vector3 currentTotalMove)
    {

        GameObject dog = GameObject.FindGameObjectWithTag("Dog");

        Vector3 fleeingVector = agent.transform.position - dog.transform.position;

        return fleeingVector.normalized * (1 / fleeingVector.magnitude);

    }
}
