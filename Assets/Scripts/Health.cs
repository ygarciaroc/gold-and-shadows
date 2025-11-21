using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public int hp = 5;

    public void TakeDamage(int damage)
    {
        hp -= damage;

        if(gameObject.CompareTag("Player"))
        {
            GameFeel.AddFlashRed(.5f);
        }

        if (hp <= 0)
        {
            if (gameObject.CompareTag("Player"))
            {
                GameManager.LoadScene(0);
            }
            else
            {
                EnemyCounter.EnemyDestroyed();
                Destroy(gameObject);
            }
        }
    }
}
