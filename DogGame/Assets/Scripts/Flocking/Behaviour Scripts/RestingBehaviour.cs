using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behaviour/Resting")]
public class RestingBehaviour : FlockBehaviour
{
    public float targetDensity = 1f;
    public float searchDistance = 5f;
    public override Vector3 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock, Vector3 currentTotalMove)
    {
        //If no neighbors, dont adjust movement.
        if (context.Count == 0)
            return Vector3.zero;

        List<Transform> neighbors = context.Where(c => Vector3.Distance(c.position, agent.transform.position) < searchDistance).ToList();

        if (neighbors.Count == 0)
            return Vector3.zero;

        if(neighbors.Count / searchDistance > targetDensity)
        {
            Debug.DrawLine(Vector3.zero, agent.transform.position);
            return -currentTotalMove;
        } else
        {
            return Vector3.zero;
        }

    }
}
