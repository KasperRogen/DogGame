using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{

    DogMovement dogMovement;

    // Start is called before the first frame update
    void Start()
    {
        dogMovement = GameObject.FindGameObjectWithTag("Dog").GetComponent<DogMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if(Physics.Raycast(Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0)), out hit)){
                dogMovement.SetTargetPosition(hit.point);
            }
        }
    }
}
