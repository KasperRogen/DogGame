using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DogCommand : ScriptableObject
{
    public enum dogCommands
    {
        LIE_DOWN,
        WALK_ON,
        RECALL,
        COME_BY,
        AWAY
    }

    public abstract string commandName { get; }
    public abstract string commandDescription { get; }
    public abstract dogCommands commandType { get; }
    

    public abstract void CalculateMove(GameObject dog);
    
}
