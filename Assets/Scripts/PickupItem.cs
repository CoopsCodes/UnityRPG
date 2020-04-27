using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{

    private bool canPickup;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canPickup && Input.GetButtonDown("Fire1") && PlayerController.instance.canMove) // triggering the grab item if the item can be picked up and the user clicks the fire button, and the player is active in the scene.
        {
            GameManager.instance.AddItem(GetComponent<Item>().itemName); // this calls the AddItem action to place the item in the inventory, and parses in the item name of component that the script is attached to.
            Destroy(gameObject); // this removes the object from the world.
            
        }

        GameManager.instance.SortItems();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            canPickup = true; // setting the item to be grabbable in the radious
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            canPickup = false; 
        }
    }
}
