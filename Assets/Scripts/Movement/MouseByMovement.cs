using System.Collections;
using UnityEngine;

public class MouseByMovement : MonoBehaviour
{
    Camera cam;

    Coroutine movement = null;

    public int speed = 4;
    public float jumpForce = 3f;

    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;

        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(movement != null)
            {
                StopCoroutine(movement);
            }
            movement = StartCoroutine(MoveByMouse());
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Jump(jumpForce);
        }
    }

    IEnumerator MoveByMouse()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            while (transform.position.x != hit.point.x
                && transform.position.z != hit.point.z)
            {
                Vector3 targetPosition = new Vector3(hit.point.x, transform.position.y, hit.point.z);

                transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
                yield return null;
            }
        }
    }

    void Jump(float jumpForce)
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
}
