using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //movement speed
    [SerializeField]float speed = 3f;
    //interval between attacks (in seconds)
    [SerializeField] float attackInterval = 1.5f;
    //Damage it can deal to player
    [SerializeField] int damage = 1;

    //reference to player to get its position
    GameObject player;
    //reference to player health to reduce it
    Health playerHealth;

    //Controls whether to continue attacking
    //when player is within attack range or not
    Coroutine attack;

    //whether player is withing attack range
    //used to control whether to move toward player
    bool rangeOfPlayer = false;

    void Awake()
    {
        //Gets reference to player object and its health
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<Health>();
    }

    void Update()
    {
        //Moves towards player if not within attack range
        if(!rangeOfPlayer)
        {
            transform.position = Vector3.MoveTowards
                (transform.position, player.transform.position, speed * Time.deltaTime);
        }
    }

    //Start attacking player when within attack range
    //and stop moving toward it
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            attack = StartCoroutine(Attack());
            rangeOfPlayer = true;
        }
    }
    //Stop attacking when player exits attack range
    //and continue moving towards it
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
    //reduces player health every so few time units
    //determined by attackInterval's value
    IEnumerator Attack() 
    {
        //Other methods controls whether coroutine
        //runs or not so we can use conditional true
        //to have it run until those methods
        //send signal to stop
        while(true)
        {
            //if player is not within a menu (timescale would be 0 in that case)
            //and player has a health component
            if(Time.timeScale > 0f && playerHealth)
            {
                //reduce player health
                playerHealth.TakeDamage(damage);
            }

            //continue after attackInterval's value in time units
            yield return new WaitForSecondsRealtime(attackInterval);
        }
    }
}
