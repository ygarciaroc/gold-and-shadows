using UnityEngine;
public class Health : MonoBehaviour
{
    //amount of current health
    [SerializeField] int hp = 5;

    //reduces object's health by input damage value
    //and if this object is a player and it no longer
    //has any health, go back to title screen or end run
    public void TakeDamage(int damage)
    {
        hp -= damage;

        if (gameObject.CompareTag("Player"))
        {
            print("Player took " + damage + " damage!");
        }
        if (hp <= 0)
        {
            if (gameObject.CompareTag("Player"))
            {
                print("player's been defeated");
                //GameManager.LoadScene(0);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
