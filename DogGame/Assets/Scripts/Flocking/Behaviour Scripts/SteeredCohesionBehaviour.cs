using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behaviour/Steered Cohesion")]
public class SteeredCohesionBehaviour : FlockBehaviour
{



    public override Vector3 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock, Vector3 currentTotalMove)
    {
        //If no neighbors, dont adjust movement.
        if (context.Count == 0)
            return Vector3.zero;


        Vector3 cohesionMove = new Vector3(context.Average(c => c.position.x),
                                           context.Average(c => c.position.y),
                                           context.Average(c => c.position.z));
        


        cohesionMove -= agent.transform.position;

        cohesionMove.y = 0;
        
        return cohesionMove;

    }
}
