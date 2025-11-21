using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFeel : MonoBehaviour
{
    public static GameFeel instance;

    public float cameraShakeTime = 0f;
    public float flashRedTime = 0f;

    Vector3 originalPosition;

    void Awake()
    {
        if (instance) Destroy(this);
        else instance = this;

        originalPosition = Camera.main.transform.position;

        Camera.main.backgroundColor = Color.grey;
    }

    public static void AddCameraShake(float time)
    {
        if (instance)
        {
            instance.cameraShakeTime = time;
        }
    }

    public static void AddFlashRed(float time)
    {
        if (instance)
        {
            instance.flashRedTime = time;

            Camera.main.backgroundColor = Color.red;
        }
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (cameraShakeTime > 0f)
        {
            cameraShakeTime -= Time.deltaTime;
            Vector3 newCameraPosition = new Vector3();
            newCameraPosition.x = Random.Range(-0.1f, 0.1f);
            newCameraPosition.y = Random.Range(-0.1f, 0.1f);
            newCameraPosition.z = -10;
            Camera.main.transform.position = newCameraPosition;
        } */

        if (flashRedTime > 0f)
        {
            flashRedTime -= Time.deltaTime;
        }
        else 
        {
            Camera.main.backgroundColor = Color.blue;
        }
    }
}
