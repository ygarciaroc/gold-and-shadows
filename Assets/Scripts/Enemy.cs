using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]float speed = 3f;
    GameObject player;
    Health playerHealth;

    Coroutine attack;

    bool rangeOfPlayer = false;
    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!rangeOfPlayer)
        {
            transform.position = Vector3.MoveTowards
                (transform.position, player.transform.position, speed * Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            attack = StartCoroutine(Attack());
            rangeOfPlayer = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if(other.gameObject == player)
        {
            if(attack != null)
            {
                StopCoroutine(attack);
            }
            rangeOfPlayer = false;
        }
    }
    IEnumerator Attack() 
    {
        while (true)
        {
            if(Time.timeScale > 0f && playerHealth)
            {
                playerHealth.TakeDamage(1);
            }

            yield return new WaitForSecondsRealtime(1.5f);
        }
    }
}
