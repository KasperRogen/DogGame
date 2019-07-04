using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behaviour/Alignment")]
public class AlignmentBehaviour : FlockBehaviour
{

    public override Vector3 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock, Vector3 currentTotalMove)
    {
        //If no neighbors, dont adjust movement.
        if (context.Count == 0)
            return agent.transform.forward;


        Vector3 alignmentMove = new Vector3(context.Average(c => c.forward.x),
                                           context.Average(c => c.forward.y),
                                           context.Average(c => c.forward.z));

        return alignmentMove;

    }
}
