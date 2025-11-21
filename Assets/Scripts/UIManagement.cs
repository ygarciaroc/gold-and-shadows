using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIManagement : MonoBehaviour
{
    Canvas canvas;
    Inventory inventory;
    GraphicRaycaster raycaster;
    PointerEventData pointerEventData;
    EventSystem eventSystem;
    // Start is called before the first frame update
    void Awake()
    {
        canvas = GetComponent<Canvas>();
        inventory = FindObjectOfType<Inventory>();
        raycaster = GetComponent<GraphicRaycaster>();
        eventSystem = FindObjectOfType<EventSystem>();
        canvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            canvas.enabled = !canvas.enabled;
            if (canvas.enabled)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }
        }
        if (!canvas.enabled) return;

        if (Input.GetMouseButtonDown(0))
        {
            pointerEventData = new PointerEventData(eventSystem);
            pointerEventData.position = Input.mousePosition;

            List<RaycastResult> results = new List<RaycastResult>();

            raycaster.Raycast(pointerEventData, results);
            //UI is in layer mask #5
            if (results[0].gameObject != null)
            {
                GameObject hit = results[0].gameObject;
                if (hit.transform.CompareTag("InventorySlot") && inventory.weapon == null)
                {
                    int hitIndex = 0;
                    foreach (var image in inventory.inventoryImages)
                    {
                        if (image.gameObject == hit.transform.gameObject && inventory.inventory.Count - 1 >= hitIndex)
                        {

                            for (int i = 0; i < inventory.inventory.Count; i++)
                            {
                                Collectible itemData = inventory.inventory[i].GetComponent<Collectible>();
                                if (image.sprite == itemData.image)
                                {
                                    inventory.SetAsWeapon(inventory.inventory[i]);
                                    image.sprite = null;
                                }
                            }

                        }
                    }
                }
                else if (hit.transform.CompareTag("WeaponSlot") && inventory.weapon != null)
                {
                    inventory.RemoveAsWeapon(inventory.weapon);
                }
            }
        }
        else if (Input.GetMouseButtonDown(1))
        {
            pointerEventData = new PointerEventData(eventSystem);
            pointerEventData.position = Input.mousePosition;

            List<RaycastResult> results = new List<RaycastResult>();

            raycaster.Raycast(pointerEventData, results);
            //UI is in layer mask #5
            if (results[0].gameObject != null)
            {
                GameObject hit = results[0].gameObject;
                if (hit.transform.CompareTag("InventorySlot"))
                {
                    int hitIndex = 0;
                    foreach (var image in inventory.inventoryImages)
                    {
                        if (image.gameObject == hit.transform.gameObject && inventory.inventory.Count - 1 >= hitIndex)
                        {
                            for (int i = 0; i < inventory.inventory.Count; i++)
                            {
                                Collectible itemData = inventory.inventory[i].GetComponent<Collectible>();
                                if (image.sprite == itemData.image)
                                {
                                    inventory.RemoveFromInventory(inventory.inventory[i]);
                                    image.sprite = null;
                                }
                            }
                        }
                    }
                }
            }
        }
        else if (Input.GetMouseButtonDown(2))
        {
            pointerEventData = new PointerEventData(eventSystem);
            pointerEventData.position = Input.mousePosition;

            List<RaycastResult> results = new List<RaycastResult>();

            raycaster.Raycast(pointerEventData, results);
            //UI is in layer mask #5
            if (results[0].gameObject != null && 
                (results[0].gameObject.CompareTag("InventorySlot") || results[0].gameObject.CompareTag("WeaponSlot")))
            {
                Image image = results[0].gameObject.GetComponent<Image>();
                inventory.SetItemDescription(image);
            }
        }
    }
}
