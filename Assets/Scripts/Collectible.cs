using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectible : MonoBehaviour
{
    public string objectName;
    public Sprite image;

    public Text nameDisplay;

    Inventory inventory;
    bool withinPickRange = false;
    Renderer render;

    public string description = "Holero";

    // Start is called before the first frame update
    void Start()
    {
        if(objectName == "")
        {
            objectName = name;
        }
        inventory = FindObjectOfType<Inventory>();
        render = GetComponent<Renderer>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && withinPickRange && render.enabled)
        {
            inventory.AddToInventory(this.gameObject);
            nameDisplay.text = "";
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        nameDisplay.text = objectName;
        withinPickRange = true;
    }
    private void OnTriggerExit(Collider other)
    {
        nameDisplay.text = "";
        withinPickRange = false;
    }
}
