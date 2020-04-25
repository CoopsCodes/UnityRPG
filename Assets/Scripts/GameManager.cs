using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public CharStats[] playerStats;

    public bool gameMenuOpen, fadingBetweenAreas, dialogueActive;

    public string[] itemsHeld;
    public int[] noOfItems;
    public Item[] referenceItems;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if(gameMenuOpen || fadingBetweenAreas || dialogueActive)
        {
            PlayerController.instance.canMove = false;
        }
        else
        {
            PlayerController.instance.canMove = true;
        }

        if(Input.GetKeyDown(KeyCode.K))
        {
            AddItem("Mana Potion");

            RemoveItem("Silver Armour");
        }
    }

    public Item GetItemDetails(string itemToGrab)
    {
        for(int i = 0; i < referenceItems.Length; i++)
        {
            if(referenceItems[i].itemName == itemToGrab)
            {
                return referenceItems[i];
            }
        }

        return null;
    }

    public void SortItems()
    {
        // using a while loop to increment and loop thorugh the inventory and move all the items into an empty space
        bool itemAfter = true;

        while(itemAfter == true)
        {
            itemAfter = false;

            for(int i = 0; i < itemsHeld.Length - 1; i++)
            {
                if(itemsHeld[i] == "")
                {
                    itemsHeld[i] = itemsHeld[i + 1];
                    itemsHeld[i + 1] = "";

                    noOfItems[i] = noOfItems[i + 1];
                    noOfItems[i + 1] = 0;

                    if(itemsHeld[i] != "")
                    {
                        itemAfter = true;
                    }
                }
            }
        }
    }

    public void AddItem(string itemToAdd)
    {
        int newItemPosition = 0;
        bool foundSpace = false;

        for(int i = 0; i < itemsHeld.Length; i++)
        {
            if(itemsHeld[i] == "" || itemsHeld[i] == itemToAdd)
            {
                newItemPosition = i;
                i = itemsHeld.Length; // this line is used to break the for loop, as were setting the condition to the end (only use if there can be only one item in a slot?)
                foundSpace = true;


            }
        }
        if(foundSpace)
        {
            bool itemExists = false;
            for(int i = 0; i < referenceItems.Length; i++)
            {
                if(referenceItems[i].itemName == itemToAdd)
                {
                    itemExists = true;

                    i = referenceItems.Length; // break out of the loop
                }
            }

            if(itemExists)
            {
                itemsHeld[newItemPosition] = itemToAdd;
                noOfItems[newItemPosition]++; 
            }
            else
            {
                Debug.LogError( "Cannot add " + itemToAdd);
            }

        }

        GameMenu.instance.ShowItems();
    }

    public void RemoveItem(string itemToRemove)
    {
        int itemPosition = 0;
        bool foundItem = false;

        for(int i = 0; i < itemsHeld.Length; i++)
        {
            if(itemsHeld[i] == itemToRemove)
            {
                foundItem = true;
                itemPosition = i;

                i = itemsHeld.Length; // breaks out of loop
            }
        }

        if(foundItem)
        {
            noOfItems[itemPosition]--;

            if(noOfItems[itemPosition] <= 0)
            {
                itemsHeld[itemPosition] = "";
            }

            GameMenu.instance.ShowItems();
        }
        else
        {
            Debug.LogError("Cannot remove " + itemToRemove);
        }
    }
}
