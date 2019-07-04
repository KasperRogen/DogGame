using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName = "Dog/Behaviour/Lie Down")]
public class LieDown : DogCommand
{
    public override string commandName => "Lie Down";
    public override string commandDescription => "Stop and lie down";
    public override dogCommands commandType => dogCommands.LIE_DOWN;

    public override void CalculateMove(GameObject dog)
    {
        dog.GetComponent<NavMeshAgent>().destination = dog.transform.position + dog.transform.forward;
    }
    
}
