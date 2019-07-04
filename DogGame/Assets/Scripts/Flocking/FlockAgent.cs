using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class FlockAgent : MonoBehaviour
{


    Vector3 currentVelocity;
    public float agentSmootTime = 1f;

    Collider agentCollider;
    public Collider AgentCollider { get { return agentCollider; } }

    // Start is called before the first frame update
    void Start()
    {
        agentCollider = GetComponent<Collider>();
    }




    public void Move(Vector3 velocity)
    {
        
        velocity = Vector3.SmoothDamp(transform.forward, velocity, ref currentVelocity, Vector3.Angle(velocity, transform.forward)/180);
        if (velocity.magnitude < 0.7f)
            return;
        transform.forward = velocity;
        transform.position += velocity * Time.deltaTime;
    }

}
