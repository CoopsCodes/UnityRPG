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

    public void Use(int charToUseOn)
    {
        CharStats selectedChar = GameManager.instance.playerStats[charToUseOn];

        if(isItem)
        {
            if(affectHP)
            {
                selectedChar.currentHP += amountToChange;

                if (selectedChar.currentHP > selectedChar.maxHP)
                {
                    selectedChar.currentHP = selectedChar.maxHP;
                }
            }

            if(affectMP)
            {
                selectedChar.currentMP += amountToChange;

                if (selectedChar.currentMP > selectedChar.maxMP)
                {
                    selectedChar.currentMP = selectedChar.maxMP;
                }
            }

            if(affectSRT)
            {
                selectedChar.strength += amountToChange;
            }

        }

        if(isWeapon)
        {
            if(selectedChar.equippedWeapon != "")
            {
                GameManager.instance.AddItem(selectedChar.equippedWeapon);
            }

            selectedChar.equippedWeapon = itemName;
            selectedChar.weaponPWR = weaponStrength;
        }

        if(isArmour)
        {
            if(selectedChar.equippedArmour != "")
            {
                GameManager.instance.AddItem(selectedChar.equippedArmour);
            }

            selectedChar.equippedArmour = itemName;
            selectedChar.armourPWR = armourStrength;
        }

        GameManager.instance.RemoveItem(itemName);
    }
}
