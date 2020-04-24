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
}
