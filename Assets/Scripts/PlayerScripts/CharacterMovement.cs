using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    // PlayerSpeed is the speed at which the character will move.
    public float playerSpeed = 4.0f;
    
    // RotationSpeed is the speed at which the character will rotate.
    // public float rotationSpeed = 6.0f;

    // We create an entry for the character's collider.
    public CharacterController character;

    
    // Start is called before the first frame update
    void Start()
    {
        // At the start of the game we GET the collider component from the character.
        character = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Movement() is called on Update().
        Movement();
    }

    // "Movement" is the function that allow us to get all make the logic of the movement.
    void Movement()
    {
        // Based on the Z Axis we get the vertical movement and multiply it by Time.deltaTime.
        float zValue = Input.GetAxis("Horizontal") * Time.deltaTime;

        // Based on the X Axis we get the horizontal movement and multiply it by Time.deltaTime.
        float xValue = Input.GetAxis("Vertical") * Time.deltaTime;

        // With the values of the Z and X Axis, we transform.Translate which will move the player forward/backwards and left/right.
        transform.Translate(zValue * playerSpeed, 0f, xValue * playerSpeed);


        // The following lines have been commented because they don't work with the camera movement. BUT they can be use on another script for another type of game.
        

        // In order to rotate, we have to get the rotation on the Y Axis and multiply it by the rotationSpeed.
        // float rotationY = Input.GetAxis("Horizontal") * rotationSpeed;

        // The rotation of the Y Axis is multiply by Time.deltaTime.
        //rotationY *= Time.deltaTime;

        // Rotate around our Y Axis.
        // transform.Rotate(0, rotationY, 0);

    }


}
