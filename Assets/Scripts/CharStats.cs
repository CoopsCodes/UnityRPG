using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharStats : MonoBehaviour
{
    public string charName;
    public int playerLevel = 1;
    public int currentEXP;
    public int[] EXPToNextLevel;
    public int maxLevel = 100;
    public int baseXP = 1000;

    public int currentHP;
    public int maxHP = 100;
    public int currentMP;
    public int maxMP = 30;
    public int[] MPLvlBonus;
    public int strength;
    public int defence;
    public int weaponPWR;
    public int armourPWR;
    public string equippedWeapon;
    public string equippedArmour;
    public Sprite charImage;

    // Start is called before the first frame update
    void Start()
    {
        EXPToNextLevel = new int[maxLevel];
        EXPToNextLevel[1] = baseXP;

        for(int i = 2; i < EXPToNextLevel.Length; i++)
        {
            EXPToNextLevel[i] = Mathf.FloorToInt(EXPToNextLevel[i - 1] * 1.05f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            AddExp(500); 
        }
    }

    public void AddExp(int expToAdd)
    {
        currentEXP += expToAdd;

        if(playerLevel < maxLevel)
        {
            if (currentEXP > EXPToNextLevel[playerLevel])
            {
                currentEXP -= EXPToNextLevel[playerLevel];

                playerLevel++;

                if (playerLevel % 2 == 0)
                {
                    strength++;
                }
                else
                {
                    defence++;
                }

                maxHP = Mathf.FloorToInt(maxHP * 1.05f);
                currentHP = maxHP;

                maxHP += MPLvlBonus[playerLevel];
                currentHP = maxHP;
            }
        }

        if(playerLevel >= maxLevel)
        {
            currentEXP = 0;
        }
    }
}
