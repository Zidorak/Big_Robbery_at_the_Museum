using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    // PlayerSpeed is the speed at which the character will move.
    public float playerSpeed = 4.0f;

    // We create an entry for the character's collider.
    public CharacterController character;

    private float gravity = -9.81f;

    public Transform groundCheck;
    public float groundDistance = 0.1f;
    private bool isGrounded;
    public LayerMask floorMask;

    Vector3 velocity;

    
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
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, floorMask);

        if (isGrounded == true && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        // Based on the Z Axis we get the vertical movement.
        float zValue = Input.GetAxis("Horizontal");

        // Based on the X Axis we get the horizontal movement.
        float xValue = Input.GetAxis("Vertical");

        /* We make a new Vector3 move which will be equal to the 
           transform right and forward and multiply them with the correspondent Axis. */
        Vector3 move = transform.right * zValue + transform.forward * xValue;

        // We multiply "move" with the speed and Time.deltaTime.
        character.Move(move * playerSpeed * Time.deltaTime);

        // We apply gravity by constantly adding the value of velocity.y and multiply by Time.deltaTime.
        velocity.y += gravity * Time.deltaTime;

        // We multiply the velocity by Time.deltaTime.
        character.Move(velocity * Time.deltaTime);
    }


}
