using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    // defining the types of items
    public bool isItem;
    public bool isWeapon;
    public bool isArmour;

    public string itemName;
    public string itemDescription;
    public int itemValue;
    public Sprite itemSprite;

    public int amountToChange; // the value of what the item impacts, ie health increase, weapon boost etc
    public bool affectHP, affectMP, affectSRT;

    public int weaponStrength;
    public int armourStrength;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
