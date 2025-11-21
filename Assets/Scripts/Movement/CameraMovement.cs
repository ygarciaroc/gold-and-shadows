using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform player;
    public float speed = 2;
    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Mouse X");
        float verticalInput = Input.GetAxis("Mouse Y");

        transform.RotateAround(player.position, Vector3.up, (horizontalInput + verticalInput) * speed * Time.deltaTime);
    }
}
