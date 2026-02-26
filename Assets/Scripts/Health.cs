using UnityEngine;
public class Health : MonoBehaviour
{
    public int hp = 5;

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
