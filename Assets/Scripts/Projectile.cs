using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float lifeTime = 7f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Enemy>() != null) 
        {
            other.gameObject.GetComponent<Health>().TakeDamage(2);
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if(lifeTime >= 0f)
        {
            lifeTime -= Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
