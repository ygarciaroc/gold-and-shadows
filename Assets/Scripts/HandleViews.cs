using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleViews : MonoBehaviour
{
    public List<Camera> cameras = new List<Camera>();

    int index = 0;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (index == (cameras.Count - 1))
            {
                cameras[index].enabled = false;

                index = 0;

                cameras[index].enabled = true;
            }
            else
            {
                cameras[index].enabled = false;

                index++;

                cameras[index].enabled = true;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (index == 0)
            {
                cameras[index].enabled = false;

                index = (cameras.Count - 1);

                cameras[index].enabled = true;
            }
            else
            {
                cameras[index].enabled = false;

                index--;

                cameras[index].enabled = true;
            }
        }
    }
}
