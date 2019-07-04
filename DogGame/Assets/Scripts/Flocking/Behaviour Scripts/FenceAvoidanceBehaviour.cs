using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behaviour/Fence Avoidance")]
public class FenceAvoidanceBehaviour : FlockBehaviour
{

    public float fenceAvoidanceRadius = 2f;

    public override Vector3 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock, Vector3 currentTotalMove)
    {

        List<Transform> fences = GameObject.FindGameObjectsWithTag("Fence").Select(GO => GO.transform).ToList();
        fences = fences.Where(fence => Vector3.Distance(agent.transform.position, 
                                                        fence.GetComponent<Collider>().ClosestPointOnBounds(agent.transform.position))
                                                        < fenceAvoidanceRadius).ToList();

        if (fences.Count == 0)
            return Vector3.zero;

        Vector3 avoidanceMove = new Vector3(fences.Average(fence => agent.transform.position.x - fence.GetComponent<Collider>().ClosestPointOnBounds(agent.transform.position).x),
                                           fences.Average(fence => agent.transform.position.x - fence.GetComponent<Collider>().ClosestPointOnBounds(agent.transform.position).y),
                                           fences.Average(fence => agent.transform.position.x - fence.GetComponent<Collider>().ClosestPointOnBounds(agent.transform.position).z));

        avoidanceMove.y = 0;
        return avoidanceMove;

    }
}
