﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    public int itemID;
    public string itemName;
    public string itemDesc;
    public Texture2D itemIcon;
    public ItemType itemType;
    public bool isStackable;
    public int itemQuantity;
    public int attackDamage;
    public int gatherDamage;
    public bool isSolid;
    public List<int> recipe;

    //Itemtypes eg. weapon, consumable, tools etc.
    public enum ItemType
    {
        Resource,
        Block,
        Consumable,
        Tool,
        Weapon,
        Armor //Headgear, chest, leggings?
    }

    public Item()
    {
        itemID = -1;
    }

    public Item(string name, int id, string desc, ItemType type, bool stackable, List<int> recipe, int damage = 1, int gatherdmg = 1)
    {
        itemName = name;
        itemID = id;
        itemDesc = desc;
        itemType = type;
        itemIcon = Resources.Load<Texture2D>("ItemIcons/" + name);
        isStackable = stackable;
        itemQuantity = 1; //TODO: Tell heller inventory for matchende ID. 
        this.recipe = recipe;
        attackDamage = damage;
        gatherDamage = gatherdmg;
    }

    public Item(string myName, int id, ItemType type, bool amISolid, bool stackable, List<int> recipe, int damage = 1, int gatherdmg = 1)
    {
        itemID = id;
        itemName = myName;
        itemIcon = Resources.Load<Texture2D>("ItemIcons/" + myName);
        itemType = type;
        isSolid = amISolid;
        isStackable = stackable;
        itemQuantity = 1;
        this.recipe = recipe;
        attackDamage = damage;
        gatherDamage = gatherdmg;
    }
}