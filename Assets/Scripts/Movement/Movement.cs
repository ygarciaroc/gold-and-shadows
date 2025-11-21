using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Movement : MonoBehaviour
{
    Rigidbody rb;

    public float speed = 2f;

    public float horizontalInput = 0;
    public float verticalInput = 0;

    public float jumpForce = 3f;

    public Canvas inventoryCanvas;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inventoryCanvas.enabled)
        {
            rb.velocity = Vector3.zero;
            return;
        }

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S)
            || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            EvaluateWASD();
        }
        else
        {
            rb.velocity = Vector3.zero;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump(jumpForce);
        }
    }

    void EvaluateWASD()
    {
        if (Input.GetKey(KeyCode.W))
        {
            verticalInput = 1;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            verticalInput = -1;
        }
        else
        {
            verticalInput = 0;
        }

        if (Input.GetKey(KeyCode.D))
        {
            horizontalInput = 1;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            horizontalInput = -1;
        }
        else
        {
            horizontalInput = 0;
        }

        Move(horizontalInput, verticalInput, speed);
    }
    void Move(float horizontalInput, float verticalInput, float speed)
    {
        
        rb.AddForce(Vector3.forward * verticalInput * speed, ForceMode.Impulse);
        rb.AddForce(Vector3.right * horizontalInput * speed, ForceMode.Impulse);
    }

    void Jump(float jumpForce)
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
}
