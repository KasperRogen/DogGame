using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogCommandPicker : MonoBehaviour
{

    public List<DogCommand> commands;
    private GameObject dog;

    // Start is called before the first frame update
    void Start()
    {
        dog = GameObject.FindGameObjectWithTag("Dog");

       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("LAY");
            commands.Find(command => command.commandType == DogCommand.dogCommands.LIE_DOWN).CalculateMove(dog);
        }
    }
}
