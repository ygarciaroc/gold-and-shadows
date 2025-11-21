using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public List<GameObject> inventory = new List<GameObject>();
    public List<Image> inventoryImages = new List<Image>();

    public Image weaponImage;
    public GameObject weapon;
    public Sprite defaultImage;

    public Text itemDescription;

    public void SetItemDescription(Image image)
    {
        if(image == weaponImage)
        {
            itemDescription.text = weapon.GetComponent<Collectible>().description;
            return;
        }
        for (int i = 0; i < inventory.Count; i++)
        {
            Collectible itemData = inventory[i].GetComponent<Collectible>();
            if (image.sprite == itemData.image)
            {
                itemDescription.text = itemData.description;
            }
        }
    }

    public void AddToInventory(GameObject item)
    {
        if(inventory.Count < 6)
        {
            inventory.Add(item);

            Renderer itemRender = item.GetComponent<Renderer>();
            Collider collider = itemRender.GetComponent<Collider>();
            Collectible itemData = item.GetComponent<Collectible>();

            UpdateItemDisplay(item, itemData, false);

            itemRender.enabled = false;
            collider.enabled = false;
            print("ADD");
        }
    }

    void UpdateItemDisplay(GameObject item, Collectible itemData, bool resetDisplay)
    {
        for(int i = 0; i < inventoryImages.Count-1; i++)
        {
            if (inventoryImages[i].sprite == null)
            {
                inventoryImages[i].sprite = itemData.image;
                print("Image");
                break;
            }
            else if (inventoryImages[i].sprite == itemData.image && resetDisplay)
            {
                inventoryImages[i].sprite = null;
                break;
            }
        }
    }

    public void RemoveFromInventory(GameObject item)
    {
        Renderer itemRender = item.GetComponent<Renderer>();
        Collectible itemData = item.GetComponent<Collectible>();
        Collider collider = itemRender.GetComponent<Collider>();

        itemRender.enabled = true;
        collider.enabled = true;

        //UpdateItemDisplay(item, itemData, true);

        inventory.Remove(item);
    }

    public void SetAsWeapon(GameObject item)
    {
        Collectible itemData = item.GetComponent<Collectible>();

        //UpdateItemDisplay(item, itemData, true);

        inventory.Remove(item);

        weaponImage.sprite = itemData.image;
        weapon = item;

    }
    public void RemoveAsWeapon(GameObject item)
    {
        if(inventory.Count < 6)
        {
            inventory.Add(item);
            Collectible itemData = item.GetComponent<Collectible>();

            weaponImage.sprite = null;
            weapon = null;
            UpdateItemDisplay(item, itemData, false);
        }
    }
}
