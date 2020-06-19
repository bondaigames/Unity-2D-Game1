using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

[Serializable]
public class ShopItem
{
    public string itemName;
    //public Sprite icon;
    public int baseCoin;
    public int coin = 0;
    public int level = 0;
    public int star = 0;
    public bool isBuy = false;
    public bool selected = false;

    public void UpdatedNextLevel()
    {
        level += 1;
        star += 1;
        isBuy = true;
        coin = (int)((Mathf.Log10(level) * level * baseCoin) + baseCoin);
    }

}
