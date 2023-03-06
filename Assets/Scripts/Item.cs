using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

    [Header("Item Type")]
    public bool isItem;
    public bool isWeapon;
    public bool isArmor;

    [Header("Item Details")]
    public string itemName;
    public string description;
    public int value;
    public Sprite itemSprite;

    [Header("Item Details")]
    public int amountToChange;
    public bool affectHP, affectMP, affectStr;

    [Header("Weapon/Armor Details")]
    public int weaponStrength; 

    public int armorStrength; 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Use (int charToUseOn)
    {
        CharStats selectedChar = GameManager.instance.playerStats[charToUseOn]; 

        if (isItem)
        {
            if (affectHP)
            {
                selectedChar.currentHP += amountToChange; 

                if (selectedChar.currentHP > selectedChar.maxHP)
                {
                    selectedChar.currentHP = selectedChar.maxHP; 
                }

                AudioManager.instance.PlaySFX(4); 
            }

            if (affectMP)
            {
                selectedChar.currentMP += amountToChange; 

                if (selectedChar.currentMP > selectedChar.maxMP)
                {
                    selectedChar.currentMP = selectedChar.maxMP; 
                }

                AudioManager.instance.PlaySFX(4);
            }

            if (affectStr)
            {
                selectedChar.strength += amountToChange;

                AudioManager.instance.PlaySFX(4);
            }
        }

        if (isWeapon)
        {
            if (selectedChar.equippedWpn != "")
            {
                GameManager.instance.AddItem(selectedChar.equippedWpn); 
            }

            selectedChar.equippedWpn = itemName;
            selectedChar.wpnPwr = weaponStrength;

            AudioManager.instance.PlaySFX(5);
        }

        if (isArmor)
        {
            if (selectedChar.equippedArmr != "")
            {
                GameManager.instance.AddItem(selectedChar.equippedArmr); 
            }

            selectedChar.equippedArmr = itemName;
            selectedChar.armrPwr = armorStrength;

            AudioManager.instance.PlaySFX(5);
        }

        GameManager.instance.RemoveItem(itemName); 
    }
}
