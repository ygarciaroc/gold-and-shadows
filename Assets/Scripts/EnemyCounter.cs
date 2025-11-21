using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCounter : MonoBehaviour
{
    public static int enemyCount;
    // Start is called before the first frame update
    void Start()
    {
        enemyCount = this.transform.childCount;
    }

    public static void EnemyDestroyed() 
    {
        enemyCount--;
        if(enemyCount <= 0)
        {
            GameManager.LoadScene(0);
        }
    }
}
