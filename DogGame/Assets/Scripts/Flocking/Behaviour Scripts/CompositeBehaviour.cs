using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behaviour/Composite")]
public class CompositeBehaviour : FlockBehaviour
{
    public List<FlockBehaviour> behaviours;
    public List<float> weights;

    public override Vector3 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock, Vector3 currentTotalMove)
    {
        //Handle data mismatch
        if(behaviours.Count != weights.Count)
        {
            Debug.LogError("Behaviour count not equal to weight count in " + name, this);
            return Vector3.zero;
        }


        //Set up move
        Vector3 move = Vector3.zero;


        for (int i = 0; i < behaviours.Count; i++)
        {
            Vector3 partialMove = Vector3.zero;

            if(behaviours[i].GetType() == typeof(RestingBehaviour))
            {
                partialMove = behaviours[i].CalculateMove(agent, context, flock, move);
            } else
            {
                partialMove = behaviours[i].CalculateMove(agent, context, flock, move) * weights[i];
            }

            if(partialMove != Vector3.zero && partialMove.sqrMagnitude > weights[i] * weights[i])
            {
                partialMove.Normalize();
                partialMove *= weights[i];
                move += partialMove;
            } else
            {
                move += partialMove;
            }
        }

        move.y = 0;

        

        return move;

    }
}
