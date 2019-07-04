using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerScript : MonoBehaviour
{
    CharacterController charController;

    [SerializeField]
    private float walkSpeed;
    private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        charController = GetComponent<CharacterController>();
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 MoveinputDir;
        MoveinputDir.x = Input.GetAxis("Horizontal");
        MoveinputDir.y = Input.GetAxis("Vertical");

        Move(MoveinputDir);
    }

    void Move(Vector3 inputDir)
    {
        Vector3 moveDir = transform.TransformDirection(Vector3.right) * inputDir.x +
                  transform.TransformDirection(Vector3.forward) * inputDir.y;

        moveDir *= walkSpeed;

        charController.Move(moveDir);
    }

}
