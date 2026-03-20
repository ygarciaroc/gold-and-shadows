using UnityEngine;
using UnityEngine.InputSystem;

public class Movement_CameraBased : MonoBehaviour
{
    //movement speed
    [SerializeField] private float speed = 3;
    //jump height multiplier
    [SerializeField] private float jumpHeight = 2;
    //gravity multiplier
    [SerializeField] private float gravity = -9.8f;

    //reference to movement controller
    private CharacterController controller;

    //stores move input, output, and current velocity
    Vector2 moveInput;
    Vector3 moveOutput;
    Vector3 velocity;

    void Start()
    {
        //Gets reference to movement controller
        controller = GetComponent<CharacterController>();
    }
    
    //When method is called after pressing the button associated
    //with the method in the input controller component of player
    public void OnMove(InputAction.CallbackContext context) 
    {
        //Get the movement input
        moveInput = context.ReadValue<Vector2>();

        //Store the horizontal and vertical inputs separately
        //(forward/right inputs)
        float horizontalInput = moveInput.x;
        float verticalInput = moveInput.y;

        //Get the camera direction vectors
        //and clean the data to only leave
        //respective horizontal and vertical vectors
        //(forward/right vectors)
        Vector3 forward = Camera.main.transform.forward;
        Vector3 right = Camera.main.transform.right;
        forward.y = 0;
        right.y = 0;
        forward = forward.normalized;
        right = right.normalized;

        //Get the directions the player should move related
        //to the direction the camera is currently facing
        Vector3 forwardVerticalInput = verticalInput * forward;
        Vector3 rightHorizontalInput = horizontalInput * right;

        //Store the movement output
        moveOutput = forwardVerticalInput + rightHorizontalInput;

        if (context.performed)
        {
            transform.rotation = Quaternion.LookRotation(moveOutput);
        }
    }
    //When method is called after pressing the button associated
    //with the method in the input controller component of player
    public void OnJump(InputAction.CallbackContext context)
    {
        //if the player is in the ground and button was pressed
        if(context.performed && controller.isGrounded)
        {
            //modify velocity y vector to simulate a jump
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }

    private void Update()
    {
        //Makes the player move in the designated direction
        //relative to the camera's direction and the rate of
        //movement every second
        controller.Move(moveOutput * speed * Time.deltaTime);

        //Reduces the player's velocity to simulate a fall
        velocity.y += gravity * Time.deltaTime;

        //Modifies the player's vertical velocity
        //according to changes made to it
        controller.Move(velocity * Time.deltaTime);
    }
}
