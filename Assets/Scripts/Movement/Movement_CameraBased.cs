using UnityEngine;
using UnityEngine.InputSystem;

public class Movement_CameraBased : MonoBehaviour
{
    [SerializeField] private float speed = 3;
    [SerializeField] private float jumpHeight = 2;
    [SerializeField] private float gravity = -9.8f;

    private CharacterController controller;
    Vector2 moveInput;
    Vector3 moveOutput;
    Vector3 velocity;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }
    
    public void OnMove(InputAction.CallbackContext context) 
    {
        moveInput = context.ReadValue<Vector2>();

        //move inputs
        float horizontalInput = moveInput.x;
        float verticalInput = moveInput.y;

        //Camera direction vectors
        Vector3 forward = Camera.main.transform.forward;
        Vector3 right = Camera.main.transform.right;
        forward.y = 0;
        right.y = 0;
        forward = forward.normalized;
        right = right.normalized;

        Vector3 forwardVerticalInput = verticalInput * forward;
        Vector3 rightHorizontalInput = horizontalInput * right;

        moveOutput = forwardVerticalInput + rightHorizontalInput;
    }
    public void OnJump(InputAction.CallbackContext context)
    {
        if(context.performed && controller.isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }

    private void Update()
    {
        //Vertical&horizontal movement
        controller.Move(moveOutput * speed * Time.deltaTime);

        //Jumping
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
