using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [Header("Item Type")] // defining the types of items
    public bool isItem;
    public bool isWeapon;
    public bool isArmour;

    [Header("Item Details")]
    public string itemName;
    public string itemDescription;
    public int itemValue;
    public Sprite itemSprite;

    [Header("Item Details")]
    public int amountToChange; // the value of what the item impacts, ie health increase, weapon boost etc
    public bool affectHP, affectMP, affectSRT;

    [Header("Weapon/Armour Details")]
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
