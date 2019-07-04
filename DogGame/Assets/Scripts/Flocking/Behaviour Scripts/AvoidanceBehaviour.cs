using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behaviour/Avoidance")]
public class AvoidanceBehaviour : FlockBehaviour
{
    public override Vector3 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock, Vector3 currentTotalMove)
    {
        //If no neighbors, dont adjust movement.
        if (context.Count == 0)
            return Vector3.zero;

        List<Transform> toAvoid = context.Where(c => Vector3.SqrMagnitude(c.position - agent.transform.position) < flock.SquareAvoidanceRadius).ToList();

        int nAvoid = toAvoid.Count();

        if (toAvoid.Count == 0)
            return Vector3.zero;

        Vector3 avoidanceMove = new Vector3(toAvoid.Average(c => agent.transform.position.x - c.position.x),
                                           toAvoid.Average(c => agent.transform.position.y - c.position.y),
                                           toAvoid.Average(c => agent.transform.position.z - c.position.z));
        avoidanceMove.y = 0;
        return avoidanceMove;

    }
}
