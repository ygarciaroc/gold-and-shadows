using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject projectile;

    public float projectileSpeed = 10f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit)) 
            {
                Vector3 endpoint = hit.point;
                Vector3 direction = (endpoint - transform.position).normalized;

                GameObject newProjectile = Instantiate(projectile, transform.position, Quaternion.identity);

                newProjectile.GetComponent<Rigidbody>().velocity = direction * projectileSpeed;
            }

            
        }
    }
}
